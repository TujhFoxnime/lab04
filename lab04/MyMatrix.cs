using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class MyMatrix
    {
        protected int[,] matrix;
        protected int cols;
        protected int rows;

        public int Cols { get { return cols; } }
        public int Rows { get { return rows; } }

        public MyMatrix(int Cols, int Rows)
        {
            this.cols = Cols;
            this.rows = Rows;
        }
        public void Filler(int m, int n, int minValue, int maxValue)
        {
            matrix = new int[m, n];
            Random random = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue);
                }
            }
        }
        public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
        {
            if (m1.Cols != m2.Cols || m1.Rows != m2.Rows)
            {
                throw new Exception("Количество столбцов или строк должно совпадать в матрицах!");
            }
            
            MyMatrix sum_matrix = new MyMatrix(m1.Cols, m1.Rows);
            for (int i = 0; i < m1.Cols; i++)
            {
                for (int j = 0; j < m1.Rows; j++)
                {
                    sum_matrix.matrix[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                }
            }
            return sum_matrix;
        }

        public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
        {
            if (m1.Cols != m2.Cols || m1.Rows != m2.Rows)
            {
                throw new Exception("Количество столбцов или строк должно совпадать в матрицах!");
            }
            
            MyMatrix diff_matrix = new MyMatrix(m1.Cols, m1.Rows);
            for (int i = 0; i < m1.Cols; i++)
            {
                for (int j = 0; j < m1.Rows; j++)
                {
                    diff_matrix.matrix[i, j] = m1.matrix[i, j] - m2.matrix[i, j];
                }
            }
            return diff_matrix;
        }
        public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
        {
            if (m1.Cols != m2.Rows)
            {
                throw new Exception("Количество элементов в столбце первой матрицы должно быть ровно количеству элементов в строке второй матрицы!");
            }

            MyMatrix prod_matrix = new MyMatrix(m1.Rows, m2.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Cols; j++)
                {
                    int count = 0;
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        count += m1.matrix[k, i] * m2.matrix[j, k];
                    }
                    prod_matrix.matrix[i, j] = count;
                }
            }
            return prod_matrix;
        }

        public static MyMatrix operator *(MyMatrix matr, int numb)
        {
            MyMatrix new_matrix = new MyMatrix(matr.Cols, matr.Rows);
            for (int i = 0; i < matr.Cols; i++)
            {
                for (int j = 0; j < matr.Rows; j++)
                {
                    new_matrix.matrix[i, j] = numb * matr.matrix[i, j];
                }
            }
            return new_matrix;
        }

        public static MyMatrix operator /(MyMatrix matr, int numb)
        {
            MyMatrix new_matrix = new MyMatrix(matr.Cols, matr.Rows);
            for (int i = 0; i < matr.Cols; i++)
            {
                for (int j = 0; j < matr.Rows; j++)
                {
                    new_matrix.matrix[i, j] = matr.matrix[i, j];
                }
            }
            return new_matrix;
        }


        public int this[int column, int row]
        {
            get { return matrix[column, row]; }
            set { matrix[column, row] = value; }
        }
    }
}
