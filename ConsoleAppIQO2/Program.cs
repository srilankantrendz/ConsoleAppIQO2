using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIQO2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool result = true;
            double baseVal = 72;
            int count = 30;
            double gain = .87;
            Random random = new Random();
            int lossCount = 0, winCount = 0;

            int investment1 = 1;
            int investment2 = 3;
            int investment3 = 6;

            int investment1A = 3;   // 2.61
            int investment2A = 6;   // 2.22
            int investment3A= investment1A;


            int investment = investment1;
            bool[] responses = new bool[count];


            Console.WriteLine(baseVal);

            for (int i = 0; i < count; i++)
            {
                result = GetBoolResponse(random);
                if (result)
                {
                    baseVal = baseVal + investment * gain;
                    Console.Write($"Win [{investment * gain}]: ");
                    winCount++;
                    investment = investment1;
                }
                else
                {
                    baseVal = baseVal - investment ;
                    Console.Write($"Loss ({investment}) : ");
                    lossCount++;
                    if (investment == investment1)
                    {
                        investment = investment2;
                    }
                    else if (investment == investment2)
                    {
                        investment = investment3;
                    }
                    else
                    {
                        investment = investment1;
                    }
                }
                responses[i] = result;
                Console.WriteLine(baseVal);
            }

            Console.WriteLine("----------------");
            Console.WriteLine($"Win:{winCount} :: Loss :{lossCount}");
            foreach (bool res in responses)
            {
                Console.Write(ShowBoolVal(res));
            }
            Console.WriteLine("");
            Console.WriteLine("============== Start Other Plan for Same =======");
            Console.ReadLine();
            //////
            ///
            ////////////////
            lossCount = 0; winCount = 0;
            baseVal = 72;
            investment = investment1A;
            Console.WriteLine(baseVal);

            for (int i = 0; i < count; i++)
            {
                result = responses[i];
                if (result)
                {
                    baseVal = baseVal + investment * gain;
                    Console.Write($"Win [{investment * gain}]: ");
                    winCount++;
                    investment = investment1A;
                }
                else
                {
                    baseVal = baseVal - investment;
                    Console.Write($"Loss ({investment}) : ");
                    lossCount++;
                    if (investment == investment1A)
                    {
                        investment = investment2A;
                    }
                    else if (investment == investment2A)
                    {
                        investment = investment3A;
                    }
                    else
                    {
                        investment = investment1A;
                    }
                }
                responses[i] = result;
                Console.WriteLine(baseVal);
            }

            Console.WriteLine("----------------");
            Console.WriteLine($"Win:{winCount} :: Loss :{lossCount}");
            foreach (bool res in responses)
            {
                Console.Write(ShowBoolVal(res));
            }
            Console.WriteLine("");
            Console.WriteLine("==============================");
            Console.ReadLine();
        }

        private static string ShowBoolVal(bool res)
        {
            if (res == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        private static bool GetBoolResponse(Random random)
        {
            var result = random.Next() > (Int32.MaxValue / 2);
            return result;
        }
    }
}
