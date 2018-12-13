using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class ShoppingListEntry : BindableBase
    {
        #region bindable properties
        private string _label ="";
        private double _quantity=1;
        private string _unit="Stck";
        private decimal _price;
        private string _store;
        [BsonId]
        public Guid Id { get; set; }
        public string Label
        {
            get { return _label; }
            set { base.RaisePropertyChanged(ref _label, value); }
        }
        public double Quantity
        {
            get { return _quantity; }
            set { base.RaisePropertyChanged(ref _quantity, value); }
        }

        public string Unit
        {
            get { return _unit; }
            set { base.RaisePropertyChanged(ref _unit, value); }
        }
        public decimal Price
        {
            get { return _price; }
            set { base.RaisePropertyChanged(ref _price, value); }
        }
        public string Store
        {
            get { return _store; }
            set { base.RaisePropertyChanged(ref _store, value); }
        }

        #endregion

    }
}
