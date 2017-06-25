using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace alecbrickBreaker2
{
    public class Paddle : Sprite
    {
        int speed;
       public Keys left;
       public Keys right;
        

        public Paddle(Texture2D Image, Vector2 Position, Color Color, int Speed, Keys Left, Keys Right) : base(Image, Position, Color)
        {
            speed = Speed;
            left = Left;
            right = Right;
        }

        public override void Update(GameTime gametime, Viewport vp)
        {
            KeyboardState ks = Keyboard.GetState();
            if(ks.IsKeyDown(right))
            {
                position.X -= speed;
            }
            if(ks.IsKeyDown(left))
            {
                position.X += speed;
            }
           
            if (position.X <= 0)
            {
                position.X += speed;
            }
            if (position.X >= vp.Width- image.Width)
            {
                position.X -= speed;
            }

            base.Update(gametime, vp);
        }
    }
}
