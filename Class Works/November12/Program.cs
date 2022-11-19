namespace November12
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            #region Arrays
            // Declarations
            // int[] array = { 1, 2, 3, 4, 5 };
            // string[] strs = { "a", "n" };
            // int len = 5;
            // int[] array = new int[len];

            // Input/Output
            // int[,] arr = new int[3, 4];
            // for (int i = 0; i < 3; i++)
            // {
            //     for (int j = 0; j < 4; j++)
            //     {
            //         arr[i, j] = i * 4 + j;
            //     }
            // }
            //
            // for (int i = 0; i < arr.GetLength(0); i++)
            // {
            //     for (int j = 0; j < arr.GetLength(1); j++)
            //     {
            //         Console.Write(arr[i, j] + " ");
            //     }
            //     Console.Write("\n");
            // }

            // Foreach loop
            // int[] arr = { 2, 4, 6, 8, 10 };
            //
            // foreach (int val in arr)
            // {
            //     Console.Write(val + " ");
            // }

            #endregion
            
            PrintArray(new int[] {1, 2, 3, 4});
            Console.WriteLine(ArraySum(new int[] { 2, 8, 15, 75 }));

            int a = 4;
            int b = 10;
            
            Console.WriteLine(MaxNumber(ref a, ref b) + "\n");
            
            Console.WriteLine("A (before swap): " + a);
            Console.WriteLine("B (before swap): " + b + "\n");

            Swap(ref a, ref b);
            
            Console.WriteLine("A (after swap): " + a);
            Console.WriteLine("B (after swap): " + b + "\n");
        }

        private static void PrintArray(int[] array)
        {
            if (array.Length < 1) return;
            
            foreach (int val in array)
                Console.Write(val + " ");
            
            Console.Write("\n");
        }

        private static int ArraySum(int[] array)
        {
            if (array.Length < 1) return 0;
            
            int returner = 0;
            foreach (int val in array)
                returner += val;

            return returner;
        }

        // `ref` to change incoming values
        private static int MaxNumber(ref int a, ref int b)
        {
            int m = (a > b) ? a : b;
            
            a = 17;
            b = 35;

            return m;
        }

        private static void Swap(ref int first, ref int second)
        {
            (first, second) = (second, first);
        }
    }
}