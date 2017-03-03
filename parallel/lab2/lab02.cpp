#include <iostream>
#include <time.h>
#include <vector>
#include <mpi.h>
#include <stdlib.h>   

using namespace std;

double random(const int min, const int max)
{
	if (min == max)
		return min;
	return min + rand() % (max - min);
}

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "RUS");
	const int size = 200;

	int size_proc, rank;
	MPI_Status status;
	MPI_Request request;

	MPI_Init(&argc, &argv);
	MPI_Comm_size(MPI_COMM_WORLD, &size_proc);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);

	const int num_iter = 100;

	double matrix[size][size];
	double B[size];
	double E[size][size];

	double segmentM[num_iter][size];
	double segmentE[num_iter][size];

	double segmentMK[size];
	double segmentEK[size];

	double mini_segmentM[num_iter];
	double mini_segmentE[num_iter];

	//заповнення матриць A, B і E
	if (rank == 0)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				matrix[i][j] = random(0, 100);
				if (i == j) E[i][j] = 1.0;
				else E[i][j] = 0.0;
			}
			B[i] = random(0, 100);
		}
	}

	// прямий хід
	double t = clock();

	double div, multi;
	for (int k = 0; k < size; k++)
	{
		if (rank == 0)
		{
			if (matrix[k][k] == 0.0)
			{
				bool changed = false;
				for (int i = k + 1; i < size; i++)
				{
					if (matrix[i][k] != 0)
					{
						swap(matrix[k], matrix[i]);
						swap(E[k], E[i]);
						changed = true;
						break;
					}
				}
				if (!changed)
				{
					cout << endl << "Error: матриця не знайдена" << endl;
					return -1;
				}
			}
			div = matrix[k][k];
		}

		MPI_Scatter(matrix[k], num_iter, MPI_DOUBLE, mini_segmentM, num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Scatter(E[k], num_iter, MPI_DOUBLE, mini_segmentE, num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Bcast(&div, 1, MPI_DOUBLE, 0, MPI_COMM_WORLD);

		for (int j = 0; j < num_iter; j++)
		{
			mini_segmentM[j] /= div;
			mini_segmentE[j] /= div;
		}

		MPI_Gather(mini_segmentM, num_iter, MPI_DOUBLE, matrix[k], num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Gather(mini_segmentE, num_iter, MPI_DOUBLE, E[k], num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);

		if (rank == 0)
		{
			for (int i = 0; i < size; i++)
			{
				segmentMK[i] = matrix[k][i];
				segmentEK[i] = E[k][i];
			}
		}

		MPI_Bcast(segmentMK, size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Bcast(segmentEK, size, MPI_DOUBLE, 0, MPI_COMM_WORLD);

		MPI_Scatter(matrix, num_iter * size, MPI_DOUBLE, segmentM, num_iter * size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Scatter(E, num_iter * size, MPI_DOUBLE, segmentE, num_iter * size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		for (int i = 0; i < num_iter; i++)
		{
			if ((rank * num_iter) + i <= k)
				continue;

			multi = segmentM[i][k];
			for (int j = 0; j < size; j++)
			{
				segmentM[i][j] -= multi * segmentMK[j];
				segmentE[i][j] -= multi * segmentEK[j];
			}
		}

		MPI_Gather(segmentM, size * num_iter, MPI_DOUBLE, matrix, size * num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Gather(segmentE, size * num_iter, MPI_DOUBLE, E, size * num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
	}

	//зворотній хід
	for (int k = size - 1; k > 0; k--)
	{
		if (rank == 0)
		{
			for (int i = 0; i < size; i++)
			{
				segmentMK[i] = matrix[k][i];
				segmentEK[i] = E[k][i];
			}
		}

		MPI_Bcast(segmentMK, size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Bcast(segmentEK, size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Scatter(matrix, num_iter * size, MPI_DOUBLE, segmentM, num_iter * size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Scatter(E, num_iter * size, MPI_DOUBLE, segmentE, num_iter * size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		for (int i = num_iter - 1; i > -1; i--)
		{
			if ((rank * num_iter) + i >= k)
				continue;

			multi = segmentM[i][k];
			for (int j = 0; j < size; j++)
			{
				segmentM[i][j] -= multi * segmentMK[j];
				segmentE[i][j] -= multi * segmentEK[j];
			}
		}

		MPI_Gather(segmentM, size * num_iter, MPI_DOUBLE, matrix, size * num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
		MPI_Gather(segmentE, size * num_iter, MPI_DOUBLE, E, size * num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);
	}
	/*if (rank == 0)
	{
	for (int i = 0; i < size; i++)
	{
	for (int j = 0; j < size; j++)
	cout << E[i][j] << ' ';

	cout << '\n';
	}
	}*/

	double X[size];
	double segmentX[num_iter];

	MPI_Bcast(B, size, MPI_DOUBLE, 0, MPI_COMM_WORLD);
	MPI_Scatter(E, num_iter * size, MPI_DOUBLE, segmentE, num_iter * size, MPI_DOUBLE, 0, MPI_COMM_WORLD);

	// Вычисление X
	for (int i = 0; i < num_iter; i++)
	{
		segmentX[i] = 0;
		for (int j = 0; j < size; j++)
			segmentX[i] += segmentE[i][j] * B[j];
	}

	MPI_Gather(segmentX, num_iter, MPI_DOUBLE, X, num_iter, MPI_DOUBLE, 0, MPI_COMM_WORLD);

	/*if (rank == 0)
	{
	for (int i = 0; i < size; i++)
	{
	for (int j = 0; j < size; j++)
	cout << matrix[i][j] << " ";
	cout << endl;
	}
	}*/

	if (rank == 0)
	{
		cout << "\nThe system of equations:";
		for (int i = 0; i < size; i++)
			cout << "\nx" << i + 1 << " = " << X[i];

		t = (clock() - t) / 1000;
		cout << "\n\nThe time spent on computation: " << t << "s.";
	}
	MPI_Finalize();
	return 0;
}
