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

        public void Update(GameTime gameTime, Random rnd)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            KeyboardState kb = Keyboard.GetState();
            switch (menuActive)
            {
                case true:
                    //menu arrow
                    if (menuIndex==0)
                    {
                        arrowY = 63;
                    }
                    if (time >= 200)
                    {
                        if (kb.IsKeyDown(Keys.Down))
                        {
                            if (menuIndex+1 <= menuCount-1)
                            {
                                menuIndex++;
                                arrowY += 20;
                                time = 0;
                            }

                        }
                        else if (kb.IsKeyDown(Keys.Up))
                        {
                            if (menuIndex - 1 >= 0)
                            {
                                menuIndex--;
                                arrowY -= 20;
                                time = 0;
                            }
                        }
                        else if (kb.IsKeyDown(Keys.Space)) //select menu option
                        {
                            time = 0;
                            switch (selectedTile.TileType)
                            {
                                case "Empty":
                                    switch (menuIndex)
                                    {
                                        case 0:
                                            //TODO: build menu
                                            break;
                                        case 1:
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/
                                            LeaveMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Forest":
                                    switch (menuIndex)
                                    {
                                        case 0: //harvest
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/

                                            gameBoard.wood += 25;
                                            gameBoard.score += 5;

                                            gameBoard.tiles[selectedTile.X, selectedTile.Y].TileType = "Empty";
                                            gameBoard.tiles[selectedTile.X, selectedTile.Y].changeTile = true;

                                            LeaveMenu();
                                            break;
                                        case 1: //build lumber camp
                                            if (gameBoard.gold - 75 >= 0 && gameBoard.stone - 25 >= 0 && gameBoard.wood >= 50)
                                            {
                                                gameBoard.gold -= 75;
                                                gameBoard.stone -= 25;
                                                gameBoard.wood -= 50;

                                                if (gameBoard.hasSawmill)
                                                {
                                                    gameBoard.wood += 200;
                                                }
                                                else
                                                {
                                                    gameBoard.wood += 125;
                                                }

                                                gameBoard.tiles[selectedTile.X, selectedTile.Y].TileType = "Lumber Camp";
                                                gameBoard.tiles[selectedTile.X, selectedTile.Y].building = true;
                                                gameBoard.tiles[selectedTile.X, selectedTile.Y].changeTile = true;
                                            }
                                            LeaveMenu();
                                            break;
                                        case 2: //clear
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/

                                            gameBoard.score += 1;

                                            gameBoard.tiles[selectedTile.X, selectedTile.Y].TileType = "Empty";
                                            gameBoard.tiles[selectedTile.X, selectedTile.Y].changeTile = true;

                                            LeaveMenu();
                                            break;
                                        case 3: //leave
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/
                                            LeaveMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Mine":
                                    switch (menuIndex)
                                    {
                                        case 0:
                                            break;
                                        case 2:
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/
                                            LeaveMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Gold Mine":
                                    switch (menuIndex)
                                    {
                                        case 0:
                                            break;
                                        case 2:
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/
                                            LeaveMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Town Center":
                                    switch (menuIndex)
                                    {
                                        case 0:
                                            /*menuActive = false;
                                            menuIndex = 0;
                                            arrowY = -10;*/
                                            LeaveMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Farm":
                                    break;
                                case "Lumber Camp":
                                    break;
                                case "Quarry":
                                    break;
                                case "Mining Camp":
                                    break;
                                case "Sawmill":
                                    break;
                                case "Blacksmith":
                                    break;
                                case "Market":
                                    break;
                                case "Palace":
                                    break;
                                case "Castle":
                                    break;
                                case "Temple":
                                    break;
                                case "University":
                                    break;
                                case "Wonder":
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (kb.IsKeyDown(Keys.Escape))
                        {
                            /*menuActive = false;
                            menuIndex = 0;
                            arrowY = -10;
                            time = 0;*/
                            LeaveMenu();
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
                            time = 0;
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

        private void LeaveMenu()
        {
            menuActive = false;
            menuIndex = 0;
            arrowY = -10;
            time = 0;
        }
        public void Draw()
        {
            spriteBatch.Draw(cursor, new Vector2(mainX * spriteWidth, mainY * spriteHeight), Color.White);
            spriteBatch.Draw(menuArrow, new Vector2(arrowX, arrowY), Color.White); //new Vector2(550, 63)
        }
    }
}
