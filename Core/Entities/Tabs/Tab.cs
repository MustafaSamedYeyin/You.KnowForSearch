using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Entities.Bases;

namespace TabSpace
{
    public class Tab : AggregateRoot
    {
        public string? Name { get; set; }
        public bool IsFocus { get; set; }
        public double Sort { get; set; }
    }
}
