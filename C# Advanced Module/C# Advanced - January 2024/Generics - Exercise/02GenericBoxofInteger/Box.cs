using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02GenericBoxofInteger
{
    public class Box<T>
    {
        private List<T> list;

        public Box ()
        {
            list = new List<T> ();
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T element in list)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
