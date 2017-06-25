using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace alecbrickBreaker2
{
    public class Ball : Sprite
    {
        public int speedx;
        public int speedy;
        public Ball(Texture2D Image, Vector2 Position, Color Color, int Speed) : base(Image, Position, Color)
        {
            speedx = Speed;
            speedy = Speed;
        }
        public override void Update(GameTime gametime, Viewport vp)
        {
            
            position.X += speedx;
            position.Y += speedy;
            if(position.X == 0)
            {
                speedx = -speedx;

            
            }
            if(position.X <= 0||position.X >= vp.Width - image.Width)
            {
                speedx *= -1;
            }
           
               
                
            
            if(position.Y <= 0 )
            {
                speedy *= -1;
            }
            base.Update(gametime, vp);
        }
    }
}
