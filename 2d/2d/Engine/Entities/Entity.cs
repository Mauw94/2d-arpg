using _2d.Engine.EntityHelpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _2d.Engine.Entities
{
    public class Entity : IDisposable
    {
        /// <summary>
        /// The graphics device.
        /// </summary>
        public GraphicsDeviceManager GraphicsDevice;

        /// <summary>
        /// Entity texture.
        /// </summary>
        public Texture2D Texture;

        /// <summary>
        /// Entity position.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Entity Movement speed.
        /// </summary>
        public float Movement;

        /// <summary>
        /// Gets a rectangle which bounds this entity in world space.
        /// </summary>
        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(Texture.Bounds.Size.X, Texture.Bounds.Size.Y, Texture.Width, Texture.Height);
            }
        }

        public BoundsHelper BoundsHelper { get; }

        public ContentManager Content { get; }

        public Entity(IServiceProvider service, BoundsHelper boundsHelper, GraphicsDeviceManager graphics)
        {
            Content = new ContentManager(service, "content");
            BoundsHelper = boundsHelper;
            GraphicsDevice = graphics;
        }

        /// <summary>
        /// Dispose of the content.
        /// </summary>
        public virtual void Dispose()
        {
            Content.Unload();
        }
    }
}
