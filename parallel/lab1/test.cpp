# include <cmath>
# include <cstdlib>
# include <ctime>
# include <iomanip>
# include <iostream>
# include <mpi.h>

using namespace std;

int main ( int argc, char *argv[] );
int prime_number ( int n, int id, int p );
void timestamp ( );

//****************************************************************************80

int main ( int argc, char *argv[] )

{
  int i;
  int id;
  int n;
  int n_factor;
  int n_hi;
  int n_lo;
  int p;
  int primes;
  int primes_part;
  double wtime;
  int ierr;

  n_lo = 1;
  n_hi = 262144;
  n_factor = 2;
//
//  Initialize MPI.
//
  ierr = MPI_Init ( &argc, &argv );
//
//  Get the number of processes.
//
  ierr = MPI_Comm_size ( MPI_COMM_WORLD, &p );
//
//  Determine this processes's rank.
//
  ierr = MPI_Comm_rank ( MPI_COMM_WORLD, &id );

  if ( id == 0 )
  {
    timestamp ( );
    cout << "\n";
    cout << "PRIME_MPI\n";
    cout << "  C++/MPI version\n";
    cout << "\n";
    cout << "  An MPI example program to count the number of primes.\n";
    cout << "  The number of processes is " << p << "\n";
    cout << "\n";
    cout << "         N        Pi          Time\n";
    cout << "\n";
  }

  n = n_lo;

  while ( n <= n_hi )
  {
    if ( id == 0 )
    {
      wtime = MPI_Wtime ( );
    }
    //ierr = MPI_Bcast ( &n, 1, MPI_INT, 0, MPI_COMM_WORLD );

    primes_part = prime_number ( n, id, p );

    ierr = MPI_Reduce ( &primes_part, &primes, 1, MPI_INT, MPI_SUM, 0, 
      MPI_COMM_WORLD );

    if ( id == 0 )
    {
      wtime = MPI_Wtime ( ) - wtime;

      cout << "  " << setw(8) << n
           << "  " << setw(8) << primes
           << "  " << setw(14) << wtime << "\n";
    }
    n = n * n_factor;
  }
//
//  Terminate MPI.
//
  MPI_Finalize ( );
//
//  Terminate.
//
  if ( id == 0 ) 
  {
    cout << "\n";
    cout << "PRIME_MPI - Master process:\n";
    cout << "  Normal end of execution.\n";
    cout << "\n";
    timestamp ( );
  }

  return 0;
}
//****************************************************************************80

int prime_number ( int n, int id, int p )

//
{
  int i;
  int j;
  int prime;
  int total;

  total = 0;

  for ( i = 2 + id; i <= n; i = i + p )
  {
    prime = 1;
    for ( j = 2; j < i; j++ )
    {
      if ( ( i % j ) == 0 )
      {
        prime = 0;
        break;
      }
    }
    total = total + prime;
  }
  return total;
}
//****************************************************************************80

void timestamp ( )

{
# define TIME_SIZE 40

  static char time_buffer[TIME_SIZE];
  const struct tm *tm;
  size_t len;
  time_t now;

  now = time ( NULL );
  tm = localtime ( &now );

  len = strftime ( time_buffer, TIME_SIZE, "%d %B %Y %I:%M:%S %p", tm );

  cout << time_buffer << "\n";

  return;
# undef TIME_SIZE
}
