using System;
using System.IO;
using System.Text;

namespace praktika_1
{
    class Program
    {
        static public int InputNumber(string line, int left = 0, int right = 100)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(line);
                if (num >= left && num <= right) return num;
                else
                {
                    Console.WriteLine("В строке должно быть число от {0} до {1}!", left, right);
                }
            }
            catch
            {
                Console.WriteLine("Файл заполнен неверно!");
            }
            Console.ReadLine();
            Environment.Exit(0);
            return -1;
        }
        static public int[,] ReadfromFile(ref int m, ref int n)
        {
            string line;
            using (StreamReader reader = new StreamReader("INPUT.txt", Encoding.Default))
            {
                if (reader.Peek() == -1)
                {
                    Console.WriteLine("Файл пуст");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                int[,] arr = null;
                try
                {
                    line = reader.ReadLine();
                    string[] text = line.Split(' ');
                    n = InputNumber(text[0], 1, 70);
                    m = InputNumber(text[1], 1, 70);
                    arr = new int[n, m];
                    for (int i = 0; i < n; i++)
                    {
                        line = reader.ReadLine();
                        text = line.Split(' ');
                        for (int j = 0; j < m; j++)
                            arr[i, j] = InputNumber(text[j], 0, 100);
                    }
                }
                catch
                {
                    Console.WriteLine("\n\nФайл заполнен неверно");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                return arr;
            }
        }
        static void Main(string[] args)
        {
            int n = 0, m = 0;
            int[,] arr = null;
            arr = ReadfromFile(ref m, ref n);
            Console.WriteLine("INPUT.TXT\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            int [,] result = new int[n, m];
            result[0, 0] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    for (int k = 1; k <= i - 1; k++)
                    {
                        if (arr[k - 1, j - 1] == i - k)
                        {
                            result[i - 1, j - 1] += result[k - 1, j - 1];
                        }
                    }

                    for (int k = 1; k <= j - 1; k++)
                    {
                        if (arr[i - 1, k - 1] == j - k)
                        {
                            result[i - 1, j - 1] += result[i - 1, k - 1];
                        }
                    }
                }
            }
            Console.WriteLine("\nOUTPUT.TXT\n\n" + result[n - 1, m - 1]);
            using (StreamWriter sw = new StreamWriter("OUTPUT.TXT"))
            {
                sw.WriteLine(result[n - 1, m - 1]);
            }
            Console.ReadLine();
        }
    }
}
