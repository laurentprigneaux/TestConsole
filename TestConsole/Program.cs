using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Increment perf test:");
            TestOperatorIncrement();
            Console.ReadKey(true);
        }

        static void TestOperatorIncrement()
        {
            var array = new int[1000000];
            var list = new List<int>(1000000);
            var dico = new Dictionary<int, int>(1000000);

            for(int i = 0; i < 1000000; i++)
            {
                array[i] = 0;
                list.Add(0);
                dico[i] = 0;
            }

            var timeArray1 = TimeSpan.Zero;
            var timeArray2 = TimeSpan.Zero;
            var timeList1 = TimeSpan.Zero;
            var timeList2 = TimeSpan.Zero;
            var timeDico1 = TimeSpan.Zero;
            var timeDico2 = TimeSpan.Zero;

            for(int k = 0; k < 1000; k++)
            {
                timeArray1 += TestLoop1(array);
                timeList1 += TestLoop1(list);
                timeDico1 += TestLoop1D(dico);
                timeArray2 += TestLoop2(array);
                timeList2 += TestLoop2(list);
                timeDico2 += TestLoop2D(dico);
            }

            Console.WriteLine($"Array Test : [x+=1:{timeArray1}], [x=x+1:{timeArray2}]");
            Console.WriteLine($"List Test : [x+=1:{timeList1}], [x=x+1:{timeList2}]");
            Console.WriteLine($"Dico Test : [x+=1:{timeDico1}], [x=x+1:{timeDico2}]");
        }

        static TimeSpan TestLoop1(IList<int> list)
        {
            var chrono = new Stopwatch();
            chrono.Start();
            for (int i = 0; i < 1000000; i++)
                list[i] += 1;
            chrono.Stop();
            return chrono.Elapsed;
        }

        static TimeSpan TestLoop2(IList<int> list)
        {
            var chrono = new Stopwatch();
            chrono.Start();
            for (int i = 0; i < 1000000; i++)
                list[i] = list[i] + 1;
            chrono.Stop();
            return chrono.Elapsed;
        }

        static TimeSpan TestLoop1D(IDictionary<int, int> dico)
        {
            var chrono = new Stopwatch();
            chrono.Start();
            for (int i = 0; i < 1000000; i++)
                dico[i] += 1;
            chrono.Stop();
            return chrono.Elapsed;
        }

        static TimeSpan TestLoop2D(IDictionary<int, int> dico)
        {
            var chrono = new Stopwatch();
            chrono.Start();
            for (int i = 0; i < 1000000; i++)
                dico[i] = dico[i] + 1;
            chrono.Stop();
            return chrono.Elapsed;
        }
    }
}
