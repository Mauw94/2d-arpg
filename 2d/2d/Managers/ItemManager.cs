using _2d.Models.Items;
using _2d.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2d.Managers
{
    public class ItemManager
    {
        public static List<Item> Items;

        private Texture2D _texture;
        private readonly ContentManager _content;

        public ItemManager(ContentManager content)
        {
            Items = new List<Item>();
            _content = content;
        }

        public Item GenerateItem(ItemType type, Vector2 spawnPosition)
        {
            var item = CreateItem(type, spawnPosition);
            Items.Add(item);

            return item;
        }

        Item CreateItem(ItemType type, Vector2 spawnPosition)
        {
            switch (type)
            {
                case ItemType.Armour:
                    _texture = _content.Load<Texture2D>("armour");
                    return new HealthPotion(_texture, spawnPosition);

                case ItemType.Health:
                    _texture = _content.Load<Texture2D>("hp_potion");
                    return new HealthPotion(_texture, spawnPosition);

                case ItemType.DamagePotion:
                    _texture = _content.Load<Texture2D>("damage_potion");
                    return new DamagePotion(_texture, spawnPosition);

                case ItemType.SpeedPotion:
                    _texture = _content.Load<Texture2D>("speed_potion");
                    return new SpeedPotion(_texture, spawnPosition);

                default:
                    return null;
            }
        }
    }
}
