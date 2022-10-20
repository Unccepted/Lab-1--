using System;
using System.Threading;
using System.IO;
using System.Text;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {


            TaskOne();
            Thread.Sleep(2000);
            TaskTwo(2);
            Thread.Sleep(2000);
            TaskThree();


        }

        private static void TaskThree()
        {
            string[] files = Directory.GetFiles("TaskThreeDirectory");

            string lastChild = files.Last();

            for (int i = 0; i < files.Length; i++)
            {
                double sum = 0;
                foreach (string line in File.ReadLines(files[i]))
                {
                    string oprt = "";
                    if (oprt == "")
                    {
                        oprt = line;
                    }
                    Console.WriteLine(line);

                }
            }
        }
        static void TaskOne()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread myThread = new(Print);
                myThread.Name = $"Поток {i}";
                myThread.Start(4);
                Thread.Sleep(500);
            }


            void Print(object? obj)
            {

                if (obj is int n)
                {
                    for (int i = 0; i < n; i++)
                    {

                        Console.Write(Thread.CurrentThread.Name + " ");
                        Console.WriteLine($"Method number: {i}");
                        Thread.Sleep(500);
                    }
                }

            }
        }
        static void TaskTwo(int arrAction)
        {

            int m = 2, n = 2, k = 2;
            Random rnd = new Random(10);


            for (int i = 0; i < arrAction; i++)
            {
                Thread t = new Thread(TaskTwoActions);
                t.Start();
                Console.WriteLine($"Matrix implementation loop : {i}");
                Thread.Sleep(1000);

            }
            void TaskTwoActions()
            {
                // Масиви для заповнення
                int[,] arrA = new int[m, n];
                int[,] arrB = new int[n, k];

                arrA = CreateArray(m, n);
                arrB = CreateArray(n, k);
                int[,] arrC = MultipliantArrays(arrA, arrB);

                Console.WriteLine("Matrix A");
                PrintArray(arrA);
                Console.WriteLine("Matrix B");
                PrintArray(arrB);
                Console.WriteLine("Matrix C");
                PrintArray(arrC);

            }
            // Заповнення Матриць
            int[,] CreateArray(int r, int c)
            {
                int[,] arr = new int[r, c];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        arr[i, j] = rnd.Next(0, 100);

                    }
                }
                return arr;
            }
            // Вивід Матриць
            void PrintArray(int[,] arr)
            {
                for (int i = 0; i < m; i++, Console.WriteLine())
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(arr[i, j] + "\t ");

                    }
                }
            }
            // Множеення матриць
            int[,] MultipliantArrays(int[,] arrA, int[,] arrB)
            {
                int[,] arrC = new int[m, k];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        for (var k = 0; k < n; k++)
                        {
                            arrC[i, j] += arrA[i, k] * arrB[k, j];
                        }
                    }
                }
                return arrC;
            }
        }

    }
}
