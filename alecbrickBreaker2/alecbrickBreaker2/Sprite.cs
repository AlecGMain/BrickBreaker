using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace alecbrickBreaker2
{
    public class Sprite
    {
        public Texture2D image;
         public Vector2 position;
        Color color;
        public Rectangle hitbox;
        public Sprite(Texture2D Image, Vector2 Position, Color Color)
        {
            image = Image;
            position = Position;
            color = Color;
            hitbox = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height); 
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, position, color);
        }
        public virtual void Update(GameTime gametime , Viewport vp)
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;

            
        }
    }

}
          