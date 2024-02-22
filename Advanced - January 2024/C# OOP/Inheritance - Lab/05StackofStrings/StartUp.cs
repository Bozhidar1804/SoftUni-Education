namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new string[] { "abc", "def" });
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Count);
        }
    }
}