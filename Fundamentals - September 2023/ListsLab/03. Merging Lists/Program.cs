namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resultList = MergeTwoLists(firstList, secondList);
            Console.WriteLine(string.Join(" ", resultList));
        }

        private static List<int> MergeTwoLists(List<int> firstList, List<int> secondList)
        {
            List<int> shorterList;
            List<int> longerList;
            List<int> resultList = new List<int>();

            if (firstList.Count > secondList.Count)
            {
                shorterList = secondList;
                longerList = firstList;
            }
            else
            {
                shorterList = firstList;
                longerList = secondList;
            }

            for (int i = 0; i < shorterList.Count; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);

                firstList.RemoveAt(i);
                secondList.RemoveAt(i);
                i = -1;
            }

            for (int i = 0; i < longerList.Count; i++)
            {
                resultList.Add(longerList[i]);

                longerList.RemoveAt(i);
                i = -1;
            }

            return resultList;
        }
    }
}