using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
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

        private Song bgSong;

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

            bgSong = Content.Load<Song>("background");

            font = Content.Load<SpriteFont>("_font");

            gameBoard = new Board(9, 9, spriteBatch, font, bgSong);
            gameBoard.CreateBoard(rnd);
            gameBoard.LoadSprites(Content,rnd);

            cursor = new Cursor(1, 1, gameBoard, spriteBatch);
            cursor.LoadCursorSprite(Content);

            //TODO: GameManager
            ui = new UI(gameBoard, cursor, spriteBatch, font, graphics);
            ui.LoadSprites(Content);

            
        }
        
        protected override void Update(GameTime gameTime)
        {

            

            if (!gameBoard.endGame)
            {
                gameBoard.Update(rnd, gameTime);
                cursor.Update(gameTime, rnd);
            }
            ui.Update();

            if (gameBoard.endGame)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
            }

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
