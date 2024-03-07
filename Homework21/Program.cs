using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework21
{
    internal class Program
    {
        const int n = 4;
        static string[,] path = new string[n,n] { {"1", "2", "200", "5" }, { "3", "1", "5", "5" }, { "2", "2", "10", "5" }, { "5", "15", "5", "5" } };
        static void Main(string[] args)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{path[i, j]}, ");
                }
                Console.WriteLine();
            }
            
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardner2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{path[i,j]}, ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (path[i,j] != "Прошёл второй")
                    {
                        int delay = Convert.ToInt32(path[i, j]);
                        path[i, j] = "Прошёл первый";
                        Thread.Sleep(delay);
                    }

                }
            }
        }        static void Gardner2()
        {
            for (int i = n-1; i >= 0; i--)
            {
                for (int j = n-1; j >= 0; j--)
                {
                    if (path[i,j] != "Прошёл первый")
                    {
                        int delay = Convert.ToInt32(path[i, j]);
                        path[i, j] = "Прошёл второй";
                        Thread.Sleep(delay);
                    }

                }
            }
        }
    }
}
