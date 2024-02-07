using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        public List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public int Count(T item)
        {
            int count = 0;
            foreach(T element in list)
            {
                if (element.CompareTo(item) > 0) { count++; }
            }
            return count;
        }
    }
}
