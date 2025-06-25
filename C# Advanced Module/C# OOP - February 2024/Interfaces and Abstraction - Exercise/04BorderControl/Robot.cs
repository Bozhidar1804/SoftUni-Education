using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04BorderControl
{
    public class Robot : BaseEntity
    {
        public Robot (string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
    }
}
