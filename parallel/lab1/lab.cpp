#include <mpi.h>
#include <stdlib.h>   
#include <iostream>
# include <iomanip>

using namespace std;

#define SIZE 8

void fillMatr(int matr[SIZE][SIZE]){
	for(int i=0;i<SIZE;i++){
		for(int j=0;j<SIZE;j++){
			matr[i][j]=rand() % 100 + 1;//from 1 to 100			
		}
	}	
}

void showMatr(int matr[SIZE][SIZE]){
	cout<<"MATRIX"<<endl;
	for(int i=0;i<SIZE;i++){
		for(int j=0;j<SIZE;j++){
			cout <<setw(4) << matr[i][j];
		}
		cout<<endl;
	}	
}

int **alloc_2d_int(int rows, int cols) {
    int *data = (int *)malloc(rows*cols*sizeof(int));
    int **array= (int **)malloc(rows*sizeof(int*));
    for (int i=0; i<rows; i++)
        array[i] = &(data[cols*i]);

    return array;
}

int main(int argc, char** argv) {
	
	//cout<<argv[2]<<endl;
	int nproc;
    int rank;
	// Initialize the MPI environment
    MPI_Init(NULL, NULL);
    // Get the number of processes
    MPI_Comm_size(MPI_COMM_WORLD, &nproc);
	// Get the rank of the process
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Status status;

    if(rank){//child process
    	int i,rows;

		MPI_Recv(&rows, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);
		
		int** tmp_mas= alloc_2d_int(rows,SIZE);

		MPI_Recv(&(tmp_mas[0][0]), rows*SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);
		/*for(int k=0;k<SIZE;k++)
			cout<<tmp_mas[0][k]<<endl;*/

		for(int i=0;i<rows;i++){
			for(int j=0;j<SIZE/2;j++){
				tmp_mas[i][j]=tmp_mas[i][SIZE-j-1];
			}
		}

		MPI_Send(&rows,1,MPI_INT,0,1,MPI_COMM_WORLD);
		MPI_Send(&(tmp_mas[0][0]),rows*SIZE,MPI_INT,0,1,MPI_COMM_WORLD);
		

    }
    else{//root process
    	srand(time(NULL));

		int matr[SIZE][SIZE];

		fillMatr(matr);

		showMatr(matr);	

		for(int i=1;i<nproc;i++)
		//цикл по дочерним процессам
		{
			int rows=SIZE%2?SIZE/2+1:SIZE/2;
			rows=rows%(nproc-1) 
				?
					i==nproc-1
					?rows/(nproc-1)
					:rows/(nproc-1)+rows%(nproc-1)
				:rows/(nproc-1);

			
			int** tmp_arr= alloc_2d_int(rows,SIZE);

			for(int j=0;j<rows;j++){
				for(int k=0;k<SIZE;k++){
					tmp_arr[j][k]=matr[j+rows*(i-1)][k];
				}
			}

			MPI_Send(&rows,1,MPI_INT,i,0,MPI_COMM_WORLD);
			MPI_Send(&(tmp_arr[0][0]),SIZE*rows,MPI_INT,i,0,MPI_COMM_WORLD);
			
			delete tmp_arr[0];
			delete [] tmp_arr;
			
		}


		for(int i=1;i<nproc;i++)
		{
			int rows;
			
			MPI_Recv(&rows, 1, MPI_INT, i, 1, MPI_COMM_WORLD, &status);
			int** tmp_arr= alloc_2d_int(rows,SIZE);
			
			MPI_Recv(&(tmp_arr[0][0]), SIZE*SIZE, MPI_INT, i, 1, MPI_COMM_WORLD, &status);
			for(int k=0;k<rows;k++){
				for(int j=0;j<SIZE;j++){

					matr[k+rows*(i-1)][j]=tmp_arr[k][j];
				}
			}
		}
		
		showMatr(matr);
		
    }
    
    MPI_Finalize();   
}

