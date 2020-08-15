using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataZipper
{
    public class Configuration
    {
        public List<string> Sources { get; set; }
        public string Destination { get; set; }
        public string Name { get; set; }
        public int Interval { get; set; }

        public Configuration()
        {
            Sources = new List<string>();
        }
    }
}
