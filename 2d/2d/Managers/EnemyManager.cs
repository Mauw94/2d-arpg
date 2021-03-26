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
        
        public Alien SpawnAlien(List<Texture2D> textures)
        {
            var alien = new Alien(GetRandomTexture(textures));
            Enemies.Add(alien);

            return alien;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }

        Texture2D GetRandomTexture(List<Texture2D> textures)
        {
            var rnd = Game1.Random.Next(0, textures.Count);
            return textures[rnd];
        }
    }
}
