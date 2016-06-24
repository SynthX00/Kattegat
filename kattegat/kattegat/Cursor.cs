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
        private int mainX, mainY, arrowX, arrowY;
        private int time;

        private SpriteBatch spriteBatch;
        //private SpriteFont font;

        private Texture2D cursor, menuArrow;
        private float spriteWidth, spriteHeight;

        private Board gameBoard;

        public bool menuActive = false;
        public Tile selectedTile;
        public int menuCount = 0;
        private int menuIndex=0;

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
                    if (board.tiles[i,j].TileType == "Town Center")
                    {
                        this.mainX = i;
                        this.mainY = j;
                        break;
                    }
                }
            }

            arrowX = 550;
            arrowY = -10;

            gameBoard = board;

            this.spriteBatch = spriteBatch;
        }

        public void LoadCursorSprite(ContentManager content)
        {
            cursor = content.Load<Texture2D>("cursor");
            menuArrow = content.Load<Texture2D>("menuCursor");

            spriteWidth = cursor.Width;
            spriteHeight = cursor.Height;
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            KeyboardState kb = Keyboard.GetState();
            switch (menuActive)
            {
                case true:
                    if (menuIndex==0)
                    {
                        arrowY = 63;
                    }
                    //menu arrow
                    if (time >= 200)
                    {
                        if (kb.IsKeyDown(Keys.Down))
                        {
                            if (menuIndex+1 <= menuCount)
                            {
                                arrowY += 20;
                            }

                        }
                        else if (kb.IsKeyDown(Keys.Up))
                        {

                        }
                        else if (kb.IsKeyDown(Keys.Space))
                        {

                        }
                    }
                    break;
                default:
                    if (time >= 200)
                    {
                        if (kb.IsKeyDown(Keys.Right))
                        {
                            if (CheckCollisions("Right"))
                            {
                                mainX++;
                                time = 0;
                            }
                        }
                        else if (kb.IsKeyDown(Keys.Left))
                        {
                            if (CheckCollisions("Left"))
                            {
                                mainX--;
                                time = 0;
                            }
                        }
                        else if (kb.IsKeyDown(Keys.Up))
                        {
                            if (CheckCollisions("Up"))
                            {
                                mainY--;
                                time = 0;
                            }
                        }
                        else if (kb.IsKeyDown(Keys.Down))
                        {
                            if (CheckCollisions("Down"))
                            {
                                mainY++;
                                time = 0;
                            }
                        }
                        else if (kb.IsKeyDown(Keys.Space))
                        {
                            menuActive = true;
                            selectedTile = gameBoard.tiles[mainX, mainY];
                        }
                    }
                    break;
            }
            
        }

        private bool CheckCollisions(string dir)
        {
            bool var;

            switch (dir)
            {
                case "Right":
                    if (gameBoard.tiles[mainX + 1, mainY].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                case "Left":
                    if (gameBoard.tiles[mainX - 1, mainY].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                case "Up":
                    if (gameBoard.tiles[mainX, mainY - 1].TileType.Substring(0, 3) == "brd")
                        var = false;
                    else var = true;
                    break;
                case "Down":
                    if (gameBoard.tiles[mainX, mainY + 1].TileType.Substring(0, 3) == "brd")
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
            spriteBatch.Draw(cursor, new Vector2(mainX * spriteWidth, mainY * spriteHeight), Color.White);
            spriteBatch.Draw(menuArrow, new Vector2(arrowX, arrowY), Color.White); //new Vector2(550, 63)
        }
    }
}
