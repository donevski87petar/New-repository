using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.Models
{
    public class Food
    {
        public string foodId { get; set; }
        public string uri { get; set; }
        public string label { get; set; }
        public Nutrients nutrients { get; set; }
        public string category { get; set; }
        public string categoryLabel { get; set; }
        public string image { get; set; }
    }
}
