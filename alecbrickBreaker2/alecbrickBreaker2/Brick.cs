using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace alecbrickBreaker2
{
    public class Brick : Sprite
    {        
        public Brick(Texture2D Image, Vector2 Position, Color Color) : base(Image, Position, Color)
        {
        }
        public void Update(GameTime gametime, Rectangle Ball, Viewport vp)
        {            
            if (hitbox.Intersects(Ball))
            {

            }

            base.Update(gametime, vp);
        }
    }

}
