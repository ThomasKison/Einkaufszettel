using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Models
{
    public class MyShoppingList
    {
        [BsonId]
        public Guid Id { get; set; }
        public List<ShoppingListEntry> Entries { get; set; }

    }
}
