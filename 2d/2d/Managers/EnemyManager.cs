using _2d.Sprites;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2d.Managers
{
    public class EnemyManager
    {
        public static List<Enemy> Enemies;

        public EnemyManager()
        {
            Enemies = new List<Enemy>();
        }
        
        public GreenAlien SpawnAlien(Texture2D texture)
        {
            var alien = new GreenAlien(texture);
            Enemies.Add(alien);

            return alien;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
