using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.Models
{
    public class Hint
    {
        public Food2 food { get; set; }
        public List<Measure> measures { get; set; }
    }
}
