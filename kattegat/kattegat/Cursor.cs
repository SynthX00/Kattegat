using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kattegat
{
    class Cursor
    {
        private int x, y;
        private int time;

        private SpriteBatch spriteBatch;
        //private SpriteFont font;

        private Texture2D sprite;
        private float spriteWidth, spriteHeight;

        private Board gameBoard;
        
        public Cursor(int x, int y, Board board, SpriteBatch spriteBatch)
        {
            /*
            this.x = x;
            this.y = y;
            */
            
            for (int i = 1; i < board.Columns-1; i++)
            {
                for (int j = 1; j < board.Rows-1; j++)
                {
                    if (board.tiles[i,j].TileType == "towncenter")
                    {
                        this.x = i;
                        this.y = j;
                        break;
                    }
                }
            }
            
            gameBoard = board;

            this.spriteBatch = spriteBatch;
        }

        public void LoadCursorSprite(ContentManager content)
        {
            sprite = content.Load<Texture2D>("cursor");

            spriteWidth = sprite.Width;
            spriteHeight = sprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            KeyboardState kb = Keyboard.GetState();

            if (time>=200)
            {
                if (kb.IsKeyDown(Keys.Right))
                {
                    if (CheckCollisions("Right"))
                    {
                        x++;
                        time = 0;
                    }
                }
                else if (kb.IsKeyDown(Keys.Left))
                {
                    if (CheckCollisions("Left"))
                    {
                        x--;
                        time = 0;
                    }
                }
                else if (kb.IsKeyDown(Keys.Up))
                {
                    if (CheckCollisions("Up"))
                    {
                        y--;
                        time = 0;
                    }
                }
                else if (kb.IsKeyDown(Keys.Down))
                {
                    if (CheckCollisions("Down"))
                    {
                        y++;
                        time = 0;
                    }
                }
                //TODO: else if (kb.IsKeyDown(Keys.Space))
            }
        }

        private bool CheckCollisions(string dir)
        {
            bool var;

            switch (dir)
            {
                case "Right":
                    if (gameBoard.tiles[x + 1, y].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                case "Left":
                    if (gameBoard.tiles[x - 1, y].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                case "Up":
                    if (gameBoard.tiles[x, y - 1].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                case "Down":
                    if (gameBoard.tiles[x, y + 1].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                default:
                    var = false;
                    break;
            }

            return var;
        }

        public void Draw()
        {
            spriteBatch.Draw(sprite, new Vector2(x * spriteWidth, y * spriteHeight), Color.White);
        }
    }
}
