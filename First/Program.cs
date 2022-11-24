namespace First_Homework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            #region Task 1.1
            Console.WriteLine("(Task 1.1) Results:");
            for (int a = 3; a < 10; a++)
            {
                for (int b = 2; b < a; b++)
                {
                    for (int c = 1; c < b; c++)
                    {
                        for (int d = 0; d < c; d++)
                        {
                            Console.Write($"{a}{b}{c}{d} ");
                        }
                    }
                }
            }
            Console.WriteLine("(Task 1.1) Finished\n");
            #endregion Task 1.1
            
            #region Task 1.2
            Console.Write("(Task 1.2) Enter matrix size (0 < size <= 9): ");
            int size = Convert.ToInt32(Console.ReadLine());
            if (size > 9 || size <= 0)
            {
                Console.WriteLine("Size is out of bounds");
                return;
            }
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int currentNumber = size;
                    if (j < i) // все, что слева от главной диагонали
                        currentNumber = (currentNumber - (i + 1)) + (j + 1);
                        
                    if (i == j && j == i) // главная диагональ
                        currentNumber = size;

                    if (j > i) // все, что справа от главной диагонали
                        currentNumber = (currentNumber + (i + 1)) - (j + 1);
                    
                    Console.Write(currentNumber + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("(Task 1.2) Finished\n");
            #endregion Task 1.2

            #region Task 1.3 Не решено
            /*int firstDotX = Convert.ToInt32(Console.ReadLine());
            int firstDotY = Convert.ToInt32(Console.ReadLine());
            
            int secondDotX = Convert.ToInt32(Console.ReadLine());
            int secondDotY = Convert.ToInt32(Console.ReadLine());
            
            int thirdDotX = Convert.ToInt32(Console.ReadLine());
            int thirdDotY = Convert.ToInt32(Console.ReadLine());

            int xMax = Math.Max(firstDotX, Math.Max(secondDotX, thirdDotX)); // нижняя грань
            int yMax = Math.Max(firstDotY, Math.Max(secondDotY, thirdDotY)); // левая грань

            for (int i = 0; i < yMax; i++)
            {
                for (int j = 0; j < xMax; j++)
                {
                    if (j == 0 || i == yMax - 1 || i == j) Console.Write("* ");
                }
                Console.Write("\n");
            }*/
            #endregion Task 1.3 Не решено

            #region Task 1.4
            Console.Write("(Task 1.4) Enter height (height > 0): ");
            int height = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < height; i++)
            {
                int value = 1;
                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0 || i == 0)
                        value = 1;
                    else
                        value = value * ((i - j) + 1) / j;
                    
                    Console.Write($"{value} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("(Task 1.4) Finished\n");
            #endregion Task 1.4

            #region Task 2.1
            Console.Write("(Task 2.1) Input your number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            string resultStr = "";

            if (number < 0) number = -number;
            if (number == 0) resultStr += 0;

            resultStr = ToBinary(number);
            
            // Alternative using mask
            int mask = 1 << 15;
            for (int i = 0; i < 16; i++)
            {
                Console.Write((mask & number) > 0 ? 1 : 0);
                
                mask >>= 1;
            }
            Console.Write("\n");
            
            Console.WriteLine($"Result: {resultStr}");
            Console.WriteLine("(Task 2.1) Finished\n");
            #endregion Task 2.1

            #region Task 2.2
            Console.Write("(Task 2.2) Enter m: ");
            int m = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("(Task 2.2) Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            string mResultString = ToBinary(m);
            string nResultString = ToBinary(n);
            
            string resultString = "";

            int maxLength = Math.Max(mResultString.Length, nResultString.Length);
            while (mResultString.Length % maxLength != 0)
                mResultString = "0" + mResultString;
            
            while (nResultString.Length % maxLength != 0)
                nResultString = "0" + nResultString;

            int ost = 0;
            for (int i = maxLength - 1; i >= 0; i--)
            {
                (int, int) results = Summator(Convert.ToInt32(mResultString[i]) - 48, Convert.ToInt32(nResultString[i]) - 48, ost);
                ost = results.Item2;
                
                resultString = results.Item1 + resultString;
            }
            if (ost == 1) resultString = "1" + resultString;
            
            maxLength = Math.Max(mResultString.Length, Math.Max(nResultString.Length, resultString.Length));
            while (mResultString.Length % maxLength != 0)
                mResultString = "0" + mResultString;
            
            while (nResultString.Length % maxLength != 0)
                nResultString = "0" + nResultString;
            
            Console.WriteLine($"{mResultString}\n{nResultString}");
            for (int i = 0; i < maxLength; i++)
            {
                Console.Write(".");
            }
            
            Console.WriteLine($"\n{resultString}");
            Console.WriteLine("(Task 2.2) Finished\n");
            #endregion Task 2.2
            
            #region Task 2.3 Не решено

            // Console.WriteLine();

            #endregion Task 2.3 Не решено

            #region Task 2.4 Не решено

            #endregion Task 2.4 Не решено

            #region Task 2.5 Не решено

            /*Console.Write("Enter your number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            string resultString = "";
            while (number > 0)
            {
                resultString = (number & 1) + resultString;
                number >>= 1;
            }

            while (resultString.Length % 64 != 0)
                resultString = "0" + resultString;
            
            Console.WriteLine($"Result: {resultString}");*/

            #endregion Task 2.5 Не решено
        }

        private static string ToBinary(int number) // функция превращает обычное число в строчку - двоичное представление
        {
            string result = "";
            if (number == 0) result += 0;
            while (number > 0)
            {
                result = (number & 1) + result; // (number & 1): 1 - если на конце 1, 0 если на конце 0
                number >>= 1; // сдвиг на один вправо
            }

            return result;
        }

        private static (int, int) Summator(int first, int second, int ostatok)
        {
            int sum = first + second + ostatok;
            int returnerFirst = 0;
            int returnerSecond = 0;

            switch (sum)
            {
                case 1:
                    returnerFirst = 1;
                    returnerSecond = 0;
                    break;
                case 2:
                    returnerFirst = 0;
                    returnerSecond = 1;
                    break;
                case 3:
                    returnerFirst = 1;
                    returnerSecond = 1;
                    break;
                default:
                    returnerFirst = 0;
                    returnerSecond = 0;
                    break;
            }
            
            return (returnerFirst, returnerSecond);
        } 
    }
}