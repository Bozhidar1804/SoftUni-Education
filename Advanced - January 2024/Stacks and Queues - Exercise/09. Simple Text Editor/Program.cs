namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<char> text = new Stack<char>();
            string lastString = "";


            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                int number = int.Parse(command[0]);

                if (number == 1)
                {
                    lastString = new string(text.ToString());

                    char[] addedText = command[1].ToCharArray();
                    Array.Reverse(addedText);
                    foreach (char c in addedText)
                    {
                        text.Push(c);
                    }
                } else if (number == 2)
                {
                    lastString = new string(text.ToString());

                    int count = int.Parse(command[1]);
                    for (int j = 0; j < count; j++)
                    {
                        text.Pop();
                    }
                } else if (number == 3)
                {
                    int index = int.Parse(command[1]);
                    if (index > 0)
                    {
                        index--;
                    }
                    string currentText = "";
                    foreach (char c in text)
                    {
                        currentText += c;
                    }
                    char[] currentTextCharArr = currentText.ToCharArray();
                    Console.WriteLine(currentTextCharArr[index]);
                } else if (number == 4)
                {
                    char[] lastTextArr = lastString.ToCharArray();
                    Array.Reverse(lastTextArr);
                    Stack<char> lastText = new Stack<char>();
                    foreach (char c in lastTextArr)
                    {
                        lastText.Push(c);
                    }

                    text = lastText;
                }
            }
        }
    }
}