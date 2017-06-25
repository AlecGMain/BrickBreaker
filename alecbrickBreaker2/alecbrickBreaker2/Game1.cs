using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace alecbrickBreaker2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ball pie;
        Paddle paddle;
        List<Brick> bricks = new List<Brick>(30);
        public int lives = 5;

        Brick brick;
        SpriteFont poop;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1160;
            graphics.PreferredBackBufferHeight = 1000;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Viewport vp = GraphicsDevice.Viewport;
        
            pie = new Ball(Content.Load<Texture2D>("pie"), new Vector2(vp.Width / 2, vp.Height / 2), Color.White, 10);
            poop = Content.Load<SpriteFont>("poop");
            paddle = new Paddle(Content.Load<Texture2D>("cool car"), new Vector2(vp.Width / 2, vp.Height), Color.White, 5, Keys.Right, Keys.Left);
            paddle.position.Y -= paddle.image.Height;
            for (int i = 0; i < 336; i += 112)
            {
                for (int j = 0; j < 1160; j += 116)
                {
                    brick = new Brick(Content.Load<Texture2D>("omnom"), new Vector2(j, i), Color.White);
                    bricks.Add(brick);

                }
                // TODO: use this.Content to load your game content here
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Viewport vp = GraphicsDevice.Viewport;
            paddle.Update(gameTime, vp);
            pie.Update(gameTime, vp);
            if (pie.hitbox.Intersects(paddle.hitbox))
            {
                pie.speedy = -Math.Abs(pie.speedy);
            }
            foreach (Brick Brick in bricks)
            {
                if (Brick.hitbox.Intersects(pie.hitbox))
                {
                    bricks.Remove(Brick);
                    pie.speedy *= -1;
                    break;
                }
            }
            if (pie.position.Y >= vp.Height - pie.image.Height)
            {
                pie.position.X = vp.Width / 2;
                pie.position.Y = vp.Height / 2;
                lives--;

            }   // TODO: Add your update logic here
            if(lives == 0)
            {
                Exit();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            pie.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            foreach(Brick brick in bricks)
            {
                brick.Draw(spriteBatch);
            }

            spriteBatch.DrawString(poop, $"LIVES: {lives}", Vector2.Zero, Color.Red);
            if(bricks.Count == 0)
            {
                
                spriteBatch.DrawString(poop, $"YOU WIN!", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Blue);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
