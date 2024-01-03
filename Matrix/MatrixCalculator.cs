using MathNet.Numerics.LinearAlgebra;

namespace Matrix
{
    internal class MatrixCalculator
    {
        public void PerformMatrixOperations()
        {
            Console.WriteLine("Enter the dimensions of matrix A (m n):");
            int rowsA = int.Parse(Console.ReadLine());
            int colsA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter matrix A:");
            Matrix<double> matrixA = InputMatrix(rowsA, colsA);

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Matrix Multiplication");
            Console.WriteLine("2. Matrix Addition");
            Console.WriteLine("3. Determinant of Matrix A");
            Console.WriteLine("4. Solve System of Equations ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter a scalar for matrix multiplication:");
                    double scalar = double.Parse(Console.ReadLine());
                    MatrixMultiplication(matrixA, scalar);
                    break;

                case 2:
                    MatrixAddition(matrixA);
                    break;

                case 3:
                    DeterminantCalculation(matrixA);
                    break;

                case 4:
                    SolveSystemOfEquations(matrixA);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }


            static void MatrixMultiplication(Matrix<double> matrixA, double scalar)
            {
                Matrix<double> resultMultiply = matrixA * scalar;
                Console.WriteLine($"Result of matrix multiplication with scalar {scalar}:");
                Console.WriteLine(resultMultiply);
            }

            static void MatrixAddition(Matrix<double> matrixA)
            {
                Console.WriteLine("Enter the dimensions of matrix B (p q):");

                int rowsB = int.Parse(Console.ReadLine());
                int colsB = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter matrix B:");
                Matrix<double> matrixB = InputMatrix(rowsB, colsB);

                if (matrixA.RowCount == matrixB.RowCount && matrixA.ColumnCount == matrixB.ColumnCount)
                {
                    Matrix<double> resultAddition = matrixA + matrixB;
                    Console.WriteLine("Result of matrix addition:");
                    Console.WriteLine(resultAddition);
                }
                else
                {
                    Console.WriteLine("Matrix addition is not possible. Matrices have different dimensions.");
                }
            }

            static void DeterminantCalculation(Matrix<double> matrixA)
            {
                double determinantA = matrixA.Determinant();
                Console.WriteLine($"Determinant of matrix A: {determinantA}");
            }

            static void SolveSystemOfEquations(Matrix<double> matrixA)
            {
                Console.WriteLine("Enter the vector B for the system Ax = B:");
                Vector<double> vectorB = InputVector(matrixA.RowCount);

                try
                {
                    Vector<double> solutionX = matrixA.Solve(vectorB);
                    Console.WriteLine("\nSolution for the system Ax = B:");
                    Console.WriteLine(solutionX);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            static Matrix<double> InputMatrix(int rows, int cols)
            {
                double[,] data = new double[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine($"Enter the elements of row {i + 1} (separated by space):");
                    string[] rowValues = Console.ReadLine().Split();

                    for (int j = 0; j < cols; j++)
                    {
                        data[i, j] = double.Parse(rowValues[j]);
                    }
                }

                return Matrix<double>.Build.DenseOfArray(data);
            }

            static Vector<double> InputVector(int size)
            {
                double[] data = new double[size];

                Console.WriteLine("Enter the elements of the vector (separated by space):");
                string[] values = Console.ReadLine().Split();

                for (int i = 0; i < size; i++)
                {
                    data[i] = double.Parse(values[i]);
                }

                return Vector<double>.Build.Dense(data);
            }
        }
    }
}
/*Console.WriteLine("Enter the dimensions of matrix A (m n):");
            int rowsA = int.Parse(Console.ReadLine());
            int colsA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter matrix A:");
            Matrix<double> matrixA = InputMatrix(rowsA, colsA);

            Console.WriteLine("Enter the dimensions of matrix B (p q):");
            int rowsB = int.Parse(Console.ReadLine());
            int colsB = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter matrix B:");
            Matrix<double> matrixB = InputMatrix(rowsB, colsB);

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Matrix Multiplication");
            Console.WriteLine("2. Matrix Addition");
            Console.WriteLine("3. Determinant of Matrix A");
            Console.WriteLine("4. Solve System of Equations ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    MatrixMultiplication(matrixA, matrixB);
                    break;

                case 2:
                    MatrixAddition(matrixA, matrixB);
                    break;

                case 3:
                    DeterminantCalculation(matrixA);
                    break;

                case 4:
                  
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void MatrixMultiplication(Matrix<double> matrixA, Matrix<double> matrixB)
        {
            Matrix<double> resultMultiply = matrixA * matrixB;
            Console.WriteLine("Result of matrix multiplication:");
            Console.WriteLine(resultMultiply);
        }

        static void MatrixAddition(Matrix<double> matrixA, Matrix<double> matrixB)
        {
            Matrix<double> resultAddition = matrixA + matrixB;
            Console.WriteLine("Result of matrix addition:");
            Console.WriteLine(resultAddition);
        }

        static void DeterminantCalculation(Matrix<double> matrixA)
        {
            double determinantA = matrixA.Determinant();
            Console.WriteLine($"Determinant of matrix A: {determinantA}");
        }

        static void SolveSystemOfEquations(Matrix<double> matrixA, Vector<double> vectorB)
        {
            try
            {
                // Solve system of linear equations Ax = B
                Vector<double> solutionX = matrixA.Solve(vectorB);

                Console.WriteLine("\nSolution for the system Ax = B:");
                Console.WriteLine(solutionX);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static Matrix<double> InputMatrix(int rows, int cols)
        {
            double[,] data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Enter the elements of row {i + 1} (separated by space):");
                string[] rowValues = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = double.Parse(rowValues[j]);
                }
            }

            return Matrix<double>.Build.DenseOfArray(data);
        }*/