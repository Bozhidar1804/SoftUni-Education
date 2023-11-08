namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string reversed = "";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                Console.WriteLine($"{input} = {reversed}");
            }
        }
    }
}