#include <mpi.h>
#include <stdlib.h>   
#include <iostream>
#include <unistd.h>
# include <iomanip>


using namespace std;

#define SIZE 5
int _rows;

void fillMatr(double matr[SIZE][SIZE+1]){
	srand(time(NULL));	
	for(int i=0;i<SIZE;i++){
		for(int j=0;j<SIZE+1;j++){
			matr[i][j]=rand() % 100 + 1;//from 1 to 100			
		}
	}	
}

void showMatr(double matr[SIZE][SIZE+1]){
	cout<<"MATRIX"<<endl;
	for(int i=0;i<SIZE;i++){
		cout <<setw(3)<<'|';
		for(int j=0;j<SIZE;j++){
			cout <<setw(15) << matr[i][j];
		}
		cout <<setw(3)<<'|';
		cout<<setw(8)<<matr[i][SIZE];
		cout<<endl;
	}	
}

void showSolution(double x[SIZE]){
	for(int i =0;i<SIZE;i++){
		cout<<"X"<<i+1<<" = "<<setw(4)<<x[i]<<endl;
	}
}

void makeMatrixPretty(double matr[SIZE][SIZE+1]){
	//rows swapping 
	for(int iter=SIZE-1;iter>0;iter--){
		for(int row=0;row<iter;row++){
			int fstRowZeroes=0;
			for(int col=0;col<SIZE;col++){
				if(matr[row][col]==0){
					fstRowZeroes++;
				}
			}		
			int scndRowZeroes=0;
			for(int col=0;col<SIZE;col++){
				if(matr[row+1][col]==0){
					scndRowZeroes++;
				}
			}
			if(fstRowZeroes>scndRowZeroes){
				swap(matr[row],matr[row+1]);
			}
		}
	}
	//columns swapping
	for(int iter=SIZE-1;iter>0;iter--){
		for(int col=0;col<iter;col++){
			int fstColZeroes=0;
			for(int row=0;row<SIZE;row++){
				if(matr[row][col]==0){
					fstColZeroes++;
				}
			}		
			int scndColZeroes=0;
			for(int row=0;row<SIZE;row++){
				if(matr[row][col+1]==0){
					scndColZeroes++;	
				}
			}
			if(fstColZeroes<scndColZeroes){
				for(int row=0;row<SIZE;row++){
					swap(matr[row][col],matr[row][col+1]);
				}					
			}
		}
	}
}
void reverseGauss(double matr[SIZE][SIZE+1],double x[SIZE]){
	x[SIZE-1]=matr[SIZE-1][SIZE]/matr[SIZE-1][SIZE-1];
	

	for(int i=SIZE-2;i>=0;i--){
		double s=0.;
		for(int p=i+1;p<SIZE;p++){
			s+=matr[i][p]*x[p];
		}
		x[i]=(matr[i][SIZE]-s)/matr[i][i];
	}

}

double **alloc_2d_double(int rows, int cols) {
    double *data = (double *)malloc(rows*cols*sizeof(double));
    double **array= (double **)malloc(rows*sizeof(double*));
    for (int i=0; i<rows; i++)
        array[i] = &(data[cols*i]);

    return array;
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
    
   if(rank){//child 
    	int rows=0;
		MPI_Recv(&rows, 1, MPI_INT, 0, 0, MPI_COMM_WORLD, &status);		
		double** matr_fragm= alloc_2d_double(rows,SIZE+1);		
		MPI_Recv(&(matr_fragm[0][0]), rows*(SIZE+1), MPI_DOUBLE, 0, 0, MPI_COMM_WORLD, &status);

		//child communicaton loop
		for(int column=0;column<SIZE-1;column++){
			int max_temp_elem=0;
			int max_elem_i=0;
			int max_elem_j=0;
			/*looking for max elem*/
			//так как не переставляем рядки
			int start_search_row=0;//column/rank;
			for(int i=start_search_row;i<rows;i++){
				if(column!=0){
					if(matr_fragm[i][column-1]!=0)
					{
						continue;
					}
				}
				for(int j=column;j<SIZE;j++){//так как не "переставляем" столбцы
					if(max_temp_elem<abs(matr_fragm[i][j])){
						max_temp_elem=abs(matr_fragm[i][j]);
						max_elem_i=i;
						max_elem_j=j;
					}
				}				
			}
			MPI_Send(&max_temp_elem,1,MPI_DOUBLE,0,1,MPI_COMM_WORLD);
			int max_elem_Child_rank=0;
			MPI_Bcast(&max_elem_Child_rank,1,MPI_INT,0/*от главного процесса*/,MPI_COMM_WORLD);

			if(max_elem_Child_rank==rank){
				if(max_elem_j!=column){
					swap(matr_fragm[max_elem_i][column],matr_fragm[max_elem_i][max_elem_j]);
				}

				for(int recRank=1;recRank<nproc;recRank++){//пропускаем 0 процесс
					if(recRank==rank)
						continue;
					MPI_Send(&matr_fragm[max_elem_i][0],(SIZE+1),MPI_DOUBLE,recRank/*от процесса с наибольшим элементом*/,2/*tag*/,MPI_COMM_WORLD);
					MPI_Send(&max_elem_j,1,MPI_INT,recRank/*от процесса с наибольшим элементом*/,2/*tag*/,MPI_COMM_WORLD);
				}
				max_elem_j=column;
				double mainLine[SIZE+1];
				for(int l=0;l<SIZE+1;l++){
					mainLine[l]=matr_fragm[max_elem_i][l];
				}

				for(int line=start_search_row;line<rows;line++){
					if(line==max_elem_i)
						continue;
					if(column!=0){
						if(matr_fragm[line][column-1]!=0)
						{
							continue;
						}
					}

					double coeff=matr_fragm[line][max_elem_j]/mainLine[max_elem_j];
					for(int col=0;col<SIZE+1;col++){
						if(col==max_elem_j){
							matr_fragm[line][col]=0;
							continue;
						}
						matr_fragm[line][col]=matr_fragm[line][col]-mainLine[col]*coeff;
					}
				}
			}
			else{
				double mainLine[SIZE+1];
				int max_elem_j=0;
				MPI_Recv(&mainLine,(SIZE+1),MPI_DOUBLE,max_elem_Child_rank/*от процесса с наибольшим элементом*/,2/*tag*/,MPI_COMM_WORLD,&status);
				MPI_Recv(&max_elem_j,1,MPI_INT,max_elem_Child_rank/*от процесса с наибольшим элементом*/,2/*tag*/,MPI_COMM_WORLD,&status);
				//sleep(1);
				if(max_elem_j!=column){
					swap(matr_fragm[max_elem_i][column],matr_fragm[max_elem_i][max_elem_j]);
				}
				max_elem_j=column;
				for(int line=start_search_row;line<rows;line++){
					if(column!=0){
						if(matr_fragm[line][column-1]!=0)
						{
							continue;
						}
					}

					double coeff=matr_fragm[line][max_elem_j]/mainLine[max_elem_j];
					for(int col=0;col<SIZE+1;col++){
						if(col==max_elem_j){
							matr_fragm[line][col]=0;
							continue;
						}
						matr_fragm[line][col]=matr_fragm[line][col]-mainLine[col]*coeff;
					}
				}			
			}
		}
	

		MPI_Send(&rows, 1, MPI_INT, 0, 0, MPI_COMM_WORLD);		
		MPI_Send(&(matr_fragm[0][0]), rows*(SIZE+1), MPI_DOUBLE, 0, 0, MPI_COMM_WORLD);	
    }
    else{//main process
    	cout.precision(2);
		double matr[SIZE][SIZE+1];/*={{-5,7,1,3},
									{2,-6,3,-1},
									{1,-3,-5,-7}};*/
    	fillMatr(matr);
		double x[SIZE];

		showMatr(matr);

		for(int childRank=1;childRank<nproc;childRank++){
			//підраховуємо кількість рядків на кожен процес
			int rows=SIZE/(nproc-1);
			if(SIZE%(nproc-1)>=childRank){
				rows+=1;
			}		
			//cout<<rows<< " for "<<childRank<<endl;	
			double** tmp_arr= alloc_2d_double(rows,SIZE+1);
			
			for(int i =0,j=childRank;j-1<SIZE;i++,j+=nproc-1){
				for(int l=0;l<SIZE+1;l++){
					tmp_arr[i][l]=matr[j-1][l];
				}
			}
			MPI_Send(&rows,1,MPI_INT,childRank,0,MPI_COMM_WORLD);
			MPI_Send(&(tmp_arr[0][0]),rows*(SIZE+1),MPI_DOUBLE,childRank,0,MPI_COMM_WORLD);
			delete [] tmp_arr;	
			delete tmp_arr[0];			
		}

		/*loop for communicaton*/
		for(int step=0;step<SIZE-1;step++){
			int max_elem=-1;
			int max_elem_Child_rank=0;
			for(int childRank=1;childRank<nproc;childRank++){
				int max_temp;
				MPI_Recv(&max_temp/*всегда неотрицательное*/, 1, MPI_DOUBLE, childRank, 1, MPI_COMM_WORLD, &status);
				if(max_elem<max_temp){
					max_elem=max_temp;
					max_elem_Child_rank=childRank;
				}
			}
			MPI_Bcast(&max_elem_Child_rank,1,MPI_INT,0/*от главного процесса*/,MPI_COMM_WORLD);

		}

		for(int childRank=1;childRank<nproc;childRank++){
			int rows=0;
			MPI_Recv(&rows, 1, MPI_INT, childRank, 0, MPI_COMM_WORLD, &status);		
			double** matr_fragm= alloc_2d_double(rows,SIZE+1);		
			MPI_Recv(&(matr_fragm[0][0]), rows*(SIZE+1), MPI_DOUBLE, childRank, 0, MPI_COMM_WORLD, &status);
			//cout<<endl<<"childRank ="<<childRank<<endl;
			for(int line=childRank-1,i=0;line<SIZE;line+=(nproc-1),i++){
				for(int j=0;j<SIZE+1;j++){
					matr[line][j]=matr_fragm[i][j];
				}
			}

		}
		showMatr(matr);
		makeMatrixPretty(matr);
		showMatr(matr);
		reverseGauss(matr,x);
		showSolution(x);
	}

	MPI_Barrier(MPI_COMM_WORLD);


	MPI_Finalize();   

	return 0;
}
	
