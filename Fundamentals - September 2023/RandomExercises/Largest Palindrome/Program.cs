using System.Text;

namespace Largest_Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charArr = input.ToCharArray();
            int n = charArr.Length;
            int occurrences = 1;

            StringBuilder left = new StringBuilder();
            StringBuilder right = new StringBuilder();
            StringBuilder largestP = new StringBuilder();

            bool builderReset = false;
            

            for (int i = 1; i < n; i++)
            {
                int centerIndex = i;
                if (builderReset == true)
                {
                    occurrences = 1;
                }

                char currentCenter = charArr[i];
                char currentCharLeft = ' ';
                char currentCharRight = ' ';
                if (IsLeftValid(i, occurrences, n))
                {
                    if (char.IsLetter(charArr[i - occurrences]))
                    {
                        currentCharLeft = charArr[i - occurrences];
                    }
                } else { builderReset = true;  continue; }

                if (IsRightValid(i, occurrences, n))
                {
                    if (char.IsLetter(charArr[i + occurrences]))
                    {
                        currentCharRight = charArr[i + occurrences];
                    }
                } else { builderReset = true;  continue; }

                if (currentCharLeft == currentCharRight)
                {
                    builderReset = false;

                    if (occurrences >= 1)
                    {
                        left.Append(currentCharLeft);
                        right.Append(currentCharRight);
                        if (largestP.Length == 0)
                        {
                            largestP.Append(left + currentCenter.ToString() + right);
                        } else
                        {
                            if (i <= largestP.Length)
                            {
                                largestP.Insert(i, right);
                                largestP.Insert(0, left);

                            }
                        }

                        left.Clear();
                        right.Clear();
                    }
                    occurrences++;
                    if (IsLeftValid(i, occurrences, n) && IsRightValid(i, occurrences, n))
                    {
                        if (charArr[i - occurrences] != charArr[i + occurrences])
                        {
                            builderReset = true;
                            i++;
                        }
                    }
                    i--;
                }
            }

            Console.WriteLine(largestP);
        }

        public static bool IsLeftValid (int i, int occurrences, int n)
        {
            bool result = false;
            if ((i - occurrences) >= 0 && (i - occurrences) <= (n - 1))
            {
                result = true;
            }
            return result;
        }

        public static bool IsRightValid (int i, int occurrences, int n)
        {
            bool result = false;
            if ((i + occurrences) >= 0 && (i + occurrences) <= (n - 1))
            {
                result = true;
            }
            return result;
        }
    }
}