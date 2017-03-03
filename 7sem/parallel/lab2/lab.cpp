#include <mpi.h>
#include <stdlib.h>   
#include <iostream>
#include <unistd.h>
# include <iomanip>

using namespace std;

#define SIZE 6
int _rows;

void fillMatr(double matr[SIZE][SIZE],double b[SIZE]){
	for(int i=0;i<SIZE;i++){
		
		b[i]=rand() % 100 + 1;

		for(int j=0;j<SIZE;j++){
			matr[i][j]=rand() % 100 + 1;//from 1 to 100			
		}
	}	
}

void showMatr(double matr[SIZE][SIZE],double b[SIZE]){
	cout<<"MATRIX"<<endl;
	for(int i=0;i<SIZE;i++){
		cout <<setw(3)<<'|';
		for(int j=0;j<SIZE;j++){
			cout <<setw(15) << matr[i][j];
		}
		cout <<setw(3)<<'|';
		cout<<setw(8)<<b[i];
		cout<<endl;
	}	
}

void showSolution(double x[SIZE]){
	for(int i =0;i<SIZE;i++){
		cout<<"X"<<i+1<<" = "<<setw(4)<<x[i]<<endl;
	}
}

void 	straightGauss(double matr[SIZE][SIZE],double b[SIZE]){
	//цикл по стовбцям
	for(int j=0;j<SIZE-1;j++){
		//цикл по рядочкам
		for(int i=j+1;i<SIZE;i++){
			double d=matr[i][j]/matr[j][j];
			matr[i][j]=0;
			
			for(int p=j+1;p<SIZE;p++){
				matr[i][p]-=d*matr[j][p];
			}

			b[i]-=d*b[j];

		}
	}
	return;
}



void reverseGauss(double matr[SIZE][SIZE],double b[SIZE]
	,double x[SIZE]){
	
	x[SIZE-1]=b[SIZE-1]/matr[SIZE-1][SIZE-1];

	for(int i=SIZE-2;i>=0;i--){
		double s=0.;
		for(int p=i+1;p<SIZE;p++){
			s+=matr[i][p]*x[p];
		}
		x[i]=(b[i]-s)/matr[i][i];
	}

}

double **alloc_2d_double(int rows, int cols) {
    double *data = (double *)malloc(rows*cols*sizeof(double));
    double **array= (double **)malloc(rows*sizeof(double*));
    for (int i=0; i<rows; i++)
        array[i] = &(data[cols*i]);

    return array;
}

void OptimalSearch(double matr[SIZE][SIZE],double b[SIZE],int col){

	double max=abs(matr[col][col]);

	int _i=col;
	int _j=col;
	
	for(int i=col;i<SIZE;i++){
		for(int j=col;j<SIZE;j++){
	
			if(abs(matr[i][j])>max){
				max=matr[i][j];
				_i=i;
				_j=j;				
			}
		}
	}

	//меняет рядок
	if(_i!=col){
		for(int j=0;j<SIZE;j++){
			swap(matr[_i][j],matr[col][j]);			
		}
		swap(b[_i],b[col]);	

	}

	//меняем столюец	
	if(_j!=col){
		for(int i=0;i<SIZE;i++){
			swap(matr[i][_j],matr[i][col]);
		}
	}
}

int main(int argc, char** argv){
	int nproc;//кількість процесів
    int rank;//ранг процесу

	// Initialize the MPI environment
    MPI_Init(NULL, NULL);
    // Get the number of processes
    MPI_Comm_size(MPI_COMM_WORLD, &nproc);
	// Get the rank of the process
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Status status;
    int columnNumber=0;



    if(rank){//child process
    	int i,rows;
    	//int counter=0;//столбиков завершено

		MPI_Recv(&rows, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);
		//cout<<"proc num "<<rank<<" rows "<<rows<<endl;
		
		double** tmp_mas= alloc_2d_double(rows,SIZE);
		double b[rows];

		MPI_Recv(&(tmp_mas[0][0]), rows*SIZE, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
		
		MPI_Recv(&b, rows, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);


		while((columnNumber+1)!=rows*rank){
			double elem[SIZE];
			double _b;
			
			MPI_Recv(&(tmp_mas[0][0]), rows*SIZE, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
			MPI_Recv(&elem, SIZE, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
			MPI_Recv(&b, rows, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
			MPI_Recv(&(_b), 1, MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
		
			for(int i=0;i<rows;i++){
				if(columnNumber-i>=(rank-1)*rows)
					continue;
				
				double d=tmp_mas[i][columnNumber]/elem[columnNumber];
				//double d=1;
				
				tmp_mas[i][columnNumber]=0.;
				
				for(int p=columnNumber+1;p<SIZE;p++){
					tmp_mas[i][p]-=d*elem[p];
				}

				b[i]-=d*_b;
			}
			columnNumber++;
			
			MPI_Send(&rows,1,MPI_INT,0,1,MPI_COMM_WORLD);
			MPI_Send(&(tmp_mas[0][0]),rows*SIZE,MPI_DOUBLE,0,1,MPI_COMM_WORLD);
			MPI_Send(&(b),rows,MPI_DOUBLE,0,1,MPI_COMM_WORLD);			
		}

		MPI_Barrier(MPI_COMM_WORLD);
    }
    else{//main process
    	cout.precision(2);
		double matr[SIZE][SIZE];//={{-5,7,1},{2,-6,3},{1,-3,-5}};
		double b[SIZE];//={3,-1,-7};	
		double x[SIZE];
	    srand(time(NULL));
		
		fillMatr(matr,b);
		
		showMatr(matr,b);


		//send data
		for(int chRank=1;chRank<nproc;chRank++)
		//цикл по дочерним процессам
		{
			//підраховуємо кількість рядків на кожен процес
			int rows=SIZE/(nproc-1);
			_rows=rows;
			

			if(SIZE%(nproc-1) && chRank==(nproc-1)){
				//добавляем все оставщиеся рядки
				rows+=SIZE%(nproc-1);
			}

			
			double** tmp_arr= alloc_2d_double(rows,SIZE);

			//копіюємо окрему частину матриці
			for(int j=0;j<rows;j++){
				for(int k=0;k<SIZE;k++){
					tmp_arr[j][k]=matr[j+rows*(chRank-1)][k];
				}
			}

			double __b[rows];
			for(int i=0;i<rows;i++){
				__b[i]=b[i+rows*(chRank-1)];
			}

			//передаємо кількість рядків
			MPI_Send(&rows,1,MPI_INT,chRank,0,MPI_COMM_WORLD);
			//передаємо фрагмент матриці
			MPI_Send(&(tmp_arr[0][0]),SIZE*rows,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);
			
			
			MPI_Send(&(__b),rows,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);
			
			delete tmp_arr[0];
			delete [] tmp_arr;			
		}

		//контролюємо процес прямого гауса
		for(int i=0;i<SIZE;i++){
			//переставити рядочки та стовпці місцями (вибір найбільшого елемента по всьому полю!)
			OptimalSearch(matr,b,i);
			//sleep(3);
			//showMatr(matr,b);
			//отправляем контрольный столбец
			for(int chRank=1;chRank<nproc;chRank++){
				if((i+1)>=_rows*chRank)
					continue;
				double** tmp_arr= alloc_2d_double(_rows,SIZE);

				//копіюємо окрему частину матриці
				for(int j=0;j<_rows;j++){
					for(int k=0;k<SIZE;k++){
						tmp_arr[j][k]=matr[j+_rows*(chRank-1)][k];
					}
				}

				double __b[_rows];
				for(int l=0;l<_rows;l++){
					__b[l]=b[l+_rows*(chRank-1)];
				}


				//передаємо фрагмент матриці
				MPI_Send(&(tmp_arr[0][0]),SIZE*_rows,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);
				//cout<<"send to "<<chRank<<" element "<<matr[i][i]<<endl;
				MPI_Send(&matr[i],SIZE,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);
				MPI_Send(&(__b),_rows,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);
				MPI_Send(&(b[i]),1,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);

				//sleep(2);
				

			}
			//cout<<"Main process before gathering"<<endl;
			//получаем матрицу
			for(int chRank=1;chRank<nproc;chRank++)
			{
				if((i+1)>=_rows*chRank)
					continue;
				int rows;
				//cout<<"Main inside  gathering "<<chRank<<endl;
				
				MPI_Recv(&rows, 1, MPI_INT, chRank, 1, MPI_COMM_WORLD, &status);
				
				double** tmp_arr= alloc_2d_double(rows,SIZE);
				double _b[rows];
				
				MPI_Recv(&(tmp_arr[0][0]), rows*SIZE, MPI_DOUBLE, chRank, 1, MPI_COMM_WORLD, &status);
				MPI_Recv(&(_b), rows, MPI_DOUBLE, chRank, 1, MPI_COMM_WORLD, &status);

				//cout<<"got parts!"<<endl;
				for(int k=0;k<rows;k++){
					for(int j=0;j<SIZE;j++){
						matr[k+rows*(chRank-1)][j]=tmp_arr[k][j];
					}

					b[k+rows*(chRank-1)]=_b[k];
				}
			}
					
		}

		MPI_Barrier(MPI_COMM_WORLD);
		
		cout<<endl;
		cout<<endl;
		showMatr(matr,b);

		reverseGauss(matr,b,x);
		cout<<endl;
		cout<<endl;
		showSolution(x);

    	MPI_Finalize();   


		return 0;
    }
	
}