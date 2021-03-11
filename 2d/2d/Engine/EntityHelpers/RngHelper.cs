using System;

namespace _2d.Engine.EntityHelpers
{
    public static class RngHelper
    {
        /// <summary>
        /// Get a random number between min&max.
        /// </summary>
        public static int GetRandomNr(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
