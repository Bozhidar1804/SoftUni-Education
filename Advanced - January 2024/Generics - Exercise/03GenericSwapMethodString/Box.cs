using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03GenericSwapMethodString
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
    }
}
