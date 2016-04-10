namespace _05.PermutationsWithRepetition
{
    using System;

    public static class PermutationsWithRepetition
    {
        public static void Main()
        {
            var collection = new[] { 1, 3, 5, 5 };
            PermuteRep(collection);
        }

        private static void PermuteRep<T>(T[] workArray, int? end = null, int start = 0)
            where T : IComparable<T>
        {
            if (end == null)
            {
                end = workArray.Length - 1;
            }

            PrintPerm(workArray);

            for (int left = end.Value - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                    if (workArray[left].CompareTo(workArray[right]) != 0)
                    {
                        Swap(ref workArray[left], ref workArray[right]);
                        PermuteRep(workArray, end, left + 1);
                    }

                var firstElement = workArray[left];

                for (int i = left; i <= end.Value - 1; i++)
                {
                    workArray[i] = workArray[i + 1];
                }

                workArray[end.Value] = firstElement;
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private static void PrintPerm<T>(T[] arr)
        {
            Console.WriteLine($"{{{string.Join(", ", arr)}}}");
        }
    }
}
