using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Topic_3_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTribble;
        Rectangle greyTribbleRect;
        Rectangle window;
        Vector2 greyTribbleSpeed;
        Texture2D orangeTribble;
        Rectangle orangeTribbleRect;
        Vector2 orangeTribbleSpeed;
        Texture2D creamTribble;
        Rectangle creamTribbleRect;
        Vector2 creamTribbleSpeed;
        Random random = new Random();
        Color BackColor;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //BackColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), 0);
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            greyTribbleRect = new Rectangle(random.Next(1, 700), random.Next(1, 500), 100, 100);
            greyTribbleSpeed = new Vector2(5, 0);
            orangeTribbleRect = new Rectangle(100, 120, 100, 100);
            orangeTribbleSpeed = new Vector2(0, 3);
            creamTribbleRect = new Rectangle(random.Next(1, 700), random.Next(1, 500), 100, 100);
            creamTribbleSpeed = new Vector2(7, 4);
            BackColor = Color.White;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTribble = Content.Load<Texture2D>("tribbleGrey");
            orangeTribble = Content.Load<Texture2D>("tribbleOrange");
            creamTribble = Content.Load<Texture2D>("tribbleCream");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            if (greyTribbleRect.Left > window.Width)
            {
                greyTribbleRect.X = -100;
                
            }
            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
            {
                greyTribbleSpeed.Y *= -1;
                
            }
            orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
            if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.Left < 0)
                orangeTribbleSpeed.X *= -1;
                orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;
            if (orangeTribbleRect.Bottom > window.Height || orangeTribbleRect.Top < 0)
            {
               
                orangeTribbleSpeed.Y *= -1;
                orangeTribbleRect.Y = random.Next(1, 800);
                orangeTribbleRect.X = random.Next(1, 600);
            }
            creamTribbleRect.X += (int)creamTribbleSpeed.X;
            if (creamTribbleRect.Right > window.Width || creamTribbleRect.Left < 0)
            {
                creamTribbleSpeed.X *= -1;
                BackColor = new Color(random.Next(1, 256), random.Next(1, 256), random.Next(1, 256));
            }
            creamTribbleRect.Y += (int)creamTribbleSpeed.Y;
            if (creamTribbleRect.Bottom > window.Height || creamTribbleRect.Top < 0)
            {
                creamTribbleSpeed.Y *= -1;
                BackColor = new Color(random.Next(1, 256), random.Next(1, 256), random.Next(1, 256));
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackColor);
            _spriteBatch.Begin();
            _spriteBatch.Draw(greyTribble, greyTribbleRect, Color.White);
            _spriteBatch.Draw(orangeTribble, orangeTribbleRect, Color.White);
            _spriteBatch.Draw(creamTribble, creamTribbleRect, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
