using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.Models
{
    public class Food2
    {
        public string foodId { get; set; }
        public string uri { get; set; }
        public string label { get; set; }
        public Nutrients2 nutrients { get; set; }
        public string category { get; set; }
        public string categoryLabel { get; set; }
        public string image { get; set; }
        public string foodContentsLabel { get; set; }
        public List<ServingSize> servingSizes { get; set; }
        public double? servingsPerContainer { get; set; }
    }
}
