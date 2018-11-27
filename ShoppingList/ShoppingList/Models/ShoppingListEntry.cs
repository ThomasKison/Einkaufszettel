using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    class ShoppingListEntry
    {
        public string Label { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public string Store { get; set; }
    }
}
