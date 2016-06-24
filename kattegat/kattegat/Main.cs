using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace kattegat
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        private Board gameBoard;
        private UI ui;
        private Cursor cursor;

        private Random rnd;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1248;
            graphics.PreferredBackBufferHeight = 864;

            Window.IsBorderless = true;
        }

        
        protected override void Initialize()
        {
            IsMouseVisible = true;

            rnd = new Random();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("_font");

            gameBoard = new Board(9, 9, spriteBatch, font);
            gameBoard.CreateBoard(rnd);
            gameBoard.LoadSprites(Content,rnd);

            cursor = new Cursor(1, 1, gameBoard, spriteBatch);
            cursor.LoadCursorSprite(Content);

            //TODO: GameManager
            ui = new UI(gameBoard, cursor, spriteBatch, font);
            ui.LoadSprites(Content);

            
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed/* || Keyboard.GetState().IsKeyDown(Keys.Escape)*/)
                Exit();

            gameBoard.Update(rnd);
            cursor.Update(gameTime, rnd);
            ui.Update();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(130, 141, 105));

            spriteBatch.Begin(transformMatrix: Matrix.CreateScale(1.5f));

            gameBoard.Draw();
            //gameManager.Draw();
            ui.Draw();
            cursor.Draw();

            //spriteBatch.DrawString(font, "99999", new Vector2(16, 48), new Color(130,141,105));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
