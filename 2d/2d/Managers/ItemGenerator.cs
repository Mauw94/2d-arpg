using _2d.Models.Items;
using System;
using System.Collections.Generic;

namespace _2d.Managers
{
    public class ItemGenerator
    {
        private const int _maxValue = 100;
        private static readonly Dictionary<ItemType, int> Items 
            = new Dictionary<ItemType, int>
            {
                { ItemType.Health, 40 },
                { ItemType.Armour, 10 },
                { ItemType.SpeedPotion, 35 },
                { ItemType.DamagePotion, 15 },
            };
        
        public ItemGenerator()
        {
        }

        public static ItemType GetItemToDrop()
        {
            ItemType result = ItemType.Armour;

            var weight = Game1.Random.Next(_maxValue);

            foreach (var item in Items)
            {
                var v = item.Value;

                if (weight >= v)
                {
                    weight -= v;
                } 
                else
                {
                    result = item.Key;
                    break;
                }
            }
            Console.WriteLine("Dropped item: " + result.ToString());
            return result;
        }
    }
}
