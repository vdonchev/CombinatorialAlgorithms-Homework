namespace _04.GenerateSubsetsOfStringArray
{
    using System;
    using System.Linq;

    public static class GenerateSubsetsOfStringArray
    {
        private static string[] strings;
        private static string[] workArr;
        private static int k;

        public static void Main()
        {
            Console.Write("Insert strings separated by space(s) = ");
            strings = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            Console.Write($"k < {strings.Length} = ");
            k = int.Parse(Console.ReadLine());

            workArr = new string[k];

            GenerateSubSet();
        }

        private static void GenerateSubSet(int index = 0, int pos = 0)
        {
            if (index >= workArr.Length)
            {
                PrintSet();
                return;
            }

            for (int i = pos; i < strings.Length; i++)
            {
                workArr[index] = strings[i];
                GenerateSubSet(index + 1, i + 1);
            }
        }

        private static void PrintSet()
        {
            Console.WriteLine($"({string.Join(" ", workArr)})");
        }
    }
}
