using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data = new List<T>();

        public Box ()
        {
            data = new List<T> ();
        }
        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            var element = data.Last();
            data.RemoveAt(data.Count - 1);
            return element;
        }

        public int Count { get { return data.Count; } }

        public List<T> Data { get; set; }
    }
}
