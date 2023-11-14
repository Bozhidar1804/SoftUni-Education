namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string fileName = string.Empty;
            string fileExtension = string.Empty;

            int LastSeparatorIndex = input.LastIndexOf('\\');
            int LastSeparatorIndex2 = input.LastIndexOf('.');

            string[] inputArr = input.Split(input[LastSeparatorIndex], input[LastSeparatorIndex2]).ToArray();
            fileName = inputArr[inputArr.Length - 2];
            fileExtension = inputArr[inputArr.Length - 1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}