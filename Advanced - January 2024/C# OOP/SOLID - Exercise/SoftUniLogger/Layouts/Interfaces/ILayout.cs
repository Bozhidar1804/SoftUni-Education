using SoftUniLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Layouts.Interfaces
{
    public interface ILayout
    {
        string Format(Message message);
    }
}
