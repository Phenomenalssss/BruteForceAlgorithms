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
                "\n2. Даны N целых чисел. Расставить между ними знаки + и - так, чтобы значение получившегося выражения было равно заданному целому S." +
                "\n3. Необходимо по заданному автомобильному номеру (3 буквы и 3 цифры в формате БЦЦЦББ) подсчитать и вывести все возможные номера, получаемые перестановкой этих букв и цифр." +
                "\n>> ");
            int exercise = Convert.ToInt32(Console.ReadLine());
            switch (exercise)
            {
                case 1:
                    {
                        Console.Write("Введите n = ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        int[] friends = new int[n];
                        for (int i = 0; i < friends.Length; i++)
                        {
                            Console.Write($"Введите точку в которой живёт {i + 1}-й друг = ");
                            friends[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        int minDistance = int.MaxValue;
                        int minI = -1;
                        int min = friends.Min();
                        int max = friends.Max();
                        for (int i = min; i <= max; i++)
                        {
                            int distance = 0;
                            foreach (var friend in friends)
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
                        SpecialMethods.ColorPrint(minDistance.ToString(), ConsoleColor.Green);
                        Console.Write(" в точке = ");
                        SpecialMethods.ColorPrint(minI.ToString(), ConsoleColor.Green);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Введите количество целых чисел = ");
                        int n = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Введите целое S = ");
                        int S = Convert.ToInt16(Console.ReadLine());
                        int[] numbers = new int[n];
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            Console.Write($"Введите {i + 1}-е число = ");
                            numbers[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        int max = (int)Math.Pow(2, n - 1);
                        bool flag = false;
                        for (int i = 0; i < max && !flag; i++)
                        {
                            int temp = i;
                            int sum = numbers[0];
                            string rezult = numbers[0].ToString();
                            for (int j = 1; j < n; j++)
                            {
                                int plusOrMinus = temp % 2;
                                temp /= 2;

                                if (plusOrMinus == 0)
                                {
                                    sum += numbers[j];
                                    rezult += " + " + numbers[j];
                                }
                                else if (plusOrMinus == 1)
                                {
                                    sum -= numbers[j];
                                    rezult += " - " + numbers[j];
                                }
                            }
                            if (sum == S)
                            {
                                Console.WriteLine(rezult + " = " + S);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Console.WriteLine("No solution");
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("Введите номер = ");
                        string carNumber = Console.ReadLine();
                        char[] numbers = new char[3] { carNumber[1], carNumber[2], carNumber[3] };
                        char[] letters = new char[3] { carNumber[0], carNumber[4], carNumber[5] };
                        numbers.Sort();
                        letters.Sort();
                        int tempNumbers = 0;
                        if (carNumber[1] == carNumber[2] && carNumber[2] == carNumber[3])
                        {
                            tempNumbers = 1;
                        }
                        else if (carNumber[1] == carNumber[2] || carNumber[1] == carNumber[3] || carNumber[2] == carNumber[3])
                        {
                            tempNumbers = 3;
                        }
                        else
                        {
                            tempNumbers = 6;
                        }
                        int tempLetters = 0;
                        if (carNumber[0] == carNumber[4] && carNumber[4] == carNumber[5])
                        {
                            tempLetters = 1;
                        }
                        else if (carNumber[0] == carNumber[4] || carNumber[0] == carNumber[5] || carNumber[4] == carNumber[5])
                        {
                            tempLetters = 3;
                        }
                        else
                        {
                            tempLetters = 6;
                        }
                        int count = tempNumbers * tempLetters;
                        Console.Write($"Количество перестановок = ");
                        SpecialMethods.ColorPrint(count.ToString(), ConsoleColor.Green);
                        Console.WriteLine();
                        do
                        {
                            numbers.Sort();
                            do
                            {
                                carNumber = $"{letters[0]}{numbers[0]}{numbers[1]}{numbers[2]}{letters[1]}{letters[2]}";
                                SpecialMethods.ColorPrint(carNumber, ConsoleColor.Yellow);
                                Console.WriteLine();
                            }
                            while (SpecialMethods.GetNextP(numbers));
                        }
                        while (SpecialMethods.GetNextP(letters));
                        break;
                    }
            }
            Console.Write("\nЕщё раз? (1 - да, 0 - нет)\n>> ");
            int repeat = Convert.ToInt32(Console.ReadLine());
            if (repeat == 1)
            {
                Main(args);
            }
        }
    }
}