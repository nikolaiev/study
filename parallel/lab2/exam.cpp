#include <mpi.h>
#include <stdlib.h>   
#include <iostream>
#include <unistd.h>
# include <iomanip>

using namespace std;

#define SIZE 6

using namespace std;

void fillMatr(/*double matr[SIZE][SIZE],*/double b[SIZE]){
	for(int i=0;i<SIZE;i++){		
		b[i]=rand() % 100 + 1;

		/*for(int j=0;j<SIZE;j++){
			matr[i][j]=rand() % 100 + 1;//from 1 to 100			
		}*/
	}	
}

void showMatr(/*double matr[SIZE][SIZE],*/double b[SIZE]){
	cout<<"MATRIX"<<endl;
	for(int i=0;i<SIZE;i++){
		/*cout <<setw(3)<<'|';
		for(int j=0;j<SIZE;j++){
			cout <<setw(15) << matr[i][j];
		}*/
		//cout <<setw(3)<<'|';
		cout<<setw(8)<<b[i];
		cout<<endl;
	}	
}

int main(int argc, char** argv){
	double matr[SIZE];
	srand(time(NULL));
	
	int nproc;//кількість процесів
    int rank;//ранг процесу

	// Initialize the MPI environment
    MPI_Init(NULL, NULL);
    // Get the number of processes
    MPI_Comm_size(MPI_COMM_WORLD, &nproc);
	// Get the rank of the process
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Status status;


    if(rank){//child process
		int rows=1;
		MPI_Recv(&rows, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);

		double matrPart[rows];
		
		MPI_Recv(&matrPart, rows,MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);
		//cout<<"Child process"<<endl;

		double _min=matrPart[0];
		double index=0;
		for(int i=1;i<rows;i++){
			if(_min>matrPart[i]){
				_min=matrPart[i];
				index=i;
			}
		}
		//sending min element
		MPI_Send(&_min,1,MPI_DOUBLE,0,0,MPI_COMM_WORLD);
		//sending
		MPI_Send(&index,1,MPI_DOUBLE,0,0,MPI_COMM_WORLD);
		//MPI_Barrier(MPI_COMM_WORLD);
    }
    else{//main process

    	fillMatr(matr);
    	showMatr(matr);
    	
		//підраховуємо кількість рядків на кожен процес
		int rows=SIZE/(nproc-1);
		//цикл по дочерним процессам
		for(int chRank=1;chRank<nproc;chRank++){			
			MPI_Send(&rows,1,MPI_INT,chRank,0,MPI_COMM_WORLD);

			double tmp_arr[rows];
			//копіюємо окрему частину матриці
			for(int j=0;j<rows;j++){
				tmp_arr[j]=matr[j+rows*(chRank-1)];			
			}

			MPI_Send(tmp_arr,rows,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD);
		}
		//getting data
		double real_min=matr[0];
		double real_index=0;
		double real_ch_num=1;
		for(int chRank=1;chRank<nproc;chRank++){
			double min_temp=0;	
			double index_temp=0;
			
			MPI_Recv(&min_temp,1,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD, &status);
			MPI_Recv(&index_temp,1,MPI_DOUBLE,chRank,0,MPI_COMM_WORLD, &status);
			if(min_temp<real_min){
				real_min=min_temp;
				real_index=index_temp;
				real_ch_num=chRank;
			}
		}
		cout<<"MINIMUM"<<endl;
		cout<<real_min<<endl;
		real_index=(real_ch_num-1)*rows+real_index;
		cout<<real_index<<endl;

		
    }
    MPI_Barrier(MPI_COMM_WORLD);


	MPI_Finalize();   
}