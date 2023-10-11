namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());

            int[] result = TopNumbers(endNumber);
            foreach(int i in result)
            {
                if (i == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }

        private static int[] TopNumbers(int endNumber)
        {
            int[] result = new int[endNumber];
            bool holdsOneOddDigit = false;

            for(int i = 1; i <= endNumber; i++)
            {
                int[] currentNumber = new int[1];
                currentNumber[0] = i;
                int sumOfDigits = 0;

                if (currentNumber[0] > 9)
                {
                    string numberString = i.ToString();
                    int[] splittedArr = new int[numberString.Length];

                    for (int a = 0; a < numberString.Length; a++)
                    {
                        splittedArr[a] = int.Parse(numberString[a].ToString()); 
                    }

                    for (int j = 0; j < splittedArr.Length; j++)
                    {
                        sumOfDigits += splittedArr[j];
                        if (splittedArr[j] % 2 != 0)
                        {
                            holdsOneOddDigit = true;
                        }
                    }

                    if (sumOfDigits % 8 == 0 & holdsOneOddDigit)
                    {
                        string concatenatedDigits = string.Join("", splittedArr);
                        int resultedNumber = int.Parse(concatenatedDigits);
                        result[i] = resultedNumber;
                    }
                    holdsOneOddDigit = false;
                    continue;
                }


                for (int j = 0; j < currentNumber.Length; j++)
                {
                    sumOfDigits += currentNumber[j];
                    if (currentNumber[j] % 2 != 0)
                    {
                        holdsOneOddDigit = true;
                    }
                }

                if(sumOfDigits % 8 == 0 & holdsOneOddDigit)
                {
                    result[i] = currentNumber[0];
                }
                holdsOneOddDigit = false;
            }


            return result;
        }
    }
}