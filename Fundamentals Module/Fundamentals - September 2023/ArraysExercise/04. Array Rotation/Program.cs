namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            string[] rotated = new string[input.Length];

            for (int i = 0; i < n; i++)
            {
                rotated[input.Length - 1] = input[0];
                for (int j = 0; j < input.Length - 1; j++)
                {
                    rotated[j] = input[j + 1];
                }

                for (int k = 0; k < input.Length; k++)
                {
                    input[k] = rotated[k];
                }

            }

            Console.WriteLine(string.Join(" ", rotated));
        }
    }
}