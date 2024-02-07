using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04GenericSwapMethodInteger
{
    public class Box<T>
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

        public void Swap(int index1, int index2)
        {
            (list[index1], list[index2]) = (list[index2], list[index1]);
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
