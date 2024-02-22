using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;
        public RandomList()
        {
            rnd = new Random();
        }
        public string RandomString(List<String> list)
        {
            int index = rnd.Next(list.Count);
            string item = list[index];
            list.Remove(item);
            return item;
        }
    }
}
