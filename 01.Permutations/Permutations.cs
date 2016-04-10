namespace _01.Permutations
{
    using System;
    using System.Linq;

    public static class Permutations
    {
        private static int totalPerm;
        private static int n;
        private static int[] arr;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            arr = Enumerable.Range(1, n).ToArray();

            Perm();

            Console.WriteLine($"Total permutations: {totalPerm}");
        }

        private static void Perm(int k = 0)
        {
            if (k >= arr.Length)
            {
                Print(arr);
                totalPerm++;
                return;
            }

            Perm(k + 1);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                Perm(k + 1);
                Swap(ref arr[k], ref arr[i]);
            }
        }

        private static void Swap(ref int item1, ref int item2)
        {
            item1 ^= item2;
            item2 ^= item1;
            item1 ^= item2;
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
