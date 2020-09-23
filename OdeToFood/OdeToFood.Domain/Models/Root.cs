using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.Models
{
    public class Root
    {
        public string text { get; set; }
        public List<Parsed> parsed { get; set; }
        public List<Hint> hints { get; set; }
        public Links _links { get; set; }
    }
}
