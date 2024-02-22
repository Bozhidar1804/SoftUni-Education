using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericBoxofString
{
    public class Box<T>
    {
        private List<T> list;

        public Box ()
        {
            list = new List<T>();
        }

        public void Add(T element)
        {
            list.Add(element);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
