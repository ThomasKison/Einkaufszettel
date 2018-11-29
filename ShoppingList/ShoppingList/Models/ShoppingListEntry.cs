using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    class ShoppingListEntry
    {
        public string Label { get; set; } = "";
        public double Quantity { get; set; } = 1;
        public string Unit { get; set; } = "Stck";
        public decimal Price { get; set; } = 0;
        public string Store { get; set; } = "";
    }
}
