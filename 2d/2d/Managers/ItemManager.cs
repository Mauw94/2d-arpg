using _2d.Models.Items;
using System;
using System.Collections.Generic;

namespace _2d.Managers
{
    public class ItemManager
    {
        private const int _maxValue = 100;
        private readonly Dictionary<ItemType, int> _items;

        public ItemManager()
        {
            _items = new Dictionary<ItemType, int>
            {
                { ItemType.Health, 10 },
                { ItemType.Armour, 40 },
                { ItemType.SpeedPotion, 15 },
                { ItemType.DamagePotion, 35 },
            };
        }

        public ItemType GetRandomItem()
        {
            ItemType result = ItemType.Armour;

            var weight = Game1.Random.Next(_maxValue);

            foreach (var item in _items)
            {
                var v = item.Value;

                if (weight > v)
                {
                    weight -= v;
                } else
                {
                    result = item.Key;
                    break;
                }
            }
            Console.WriteLine("Result is: " + result.ToString());
            return result;
        }
    }
}
