using BruteForceAlgorithms;
using System.Data.SqlTypes;
using System.Security.AccessControl;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Выберете задачу, введя её номер из списка:" +
                "\n1. На прямой живут n друзей, i-й друг живет в точке xi. Они хотят встретиться в одной точке. Помогите им найти такую точку, чтобы суммарное расстояние, которое они пройдут, было бы минимально." +
                "\n>> ");
            int exercise = Convert.ToInt32(Console.ReadLine());
            switch (exercise)
            {
                case 1:
                    {
                        Console.Write("Введите n = ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        int[] friends = new int[n];
                        for(int i = 0; i < friends.Length; i++)
                        {
                            Console.Write($"Введите точку в которой живёт {i+1}-й друг = ");
                            friends[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        int minDistance = int.MaxValue;
                        int minI = -1;
                        int min = friends.Min();
                        int max = friends.Max();
                        for(int i = min; i <= max; i++)
                        {
                            int distance = 0;
                            foreach(var friend in friends)
                            {
                                distance += Math.Abs(friend - i);
                            }
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                minI = i;
                            }
                        }
                        Console.Write($"Минимальное суммарное расстояние = ");
                        ColorPrint.Run(minDistance.ToString(), ConsoleColor.Green);
                        Console.Write(" в точке = ");
                        ColorPrint.Run(minI.ToString(), ConsoleColor.Green);
                        break;
                    }
            }
            Console.WriteLine("\nЕщё раз? (1 - да, 0 - нет)\n>> ");
            int repeat = Convert.ToInt32(Console.ReadLine());
            if (repeat == 1)
            {
                Main(args);
            }
        }
    }
}