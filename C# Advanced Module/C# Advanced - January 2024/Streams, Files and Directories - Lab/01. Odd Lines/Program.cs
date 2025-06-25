namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line = "";
                    int lineNumber = 0;
                    
                    while (!reader.EndOfStream)
                    {
                        lineNumber++;
                        line = reader.ReadLine();
                        if (lineNumber % 2 == 1)
                        {
                            continue;
                        }

                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
