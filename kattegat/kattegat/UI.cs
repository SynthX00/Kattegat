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
    class UI
    {
        private Board gameBoard;
        private Cursor cursor;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        private GraphicsDeviceManager graphics;

        public Color green, darkGreen;

        private Texture2D woodSprite, stoneSprite, goldSprite;
        private Texture2D daylabel;

        //private int wood, stone, gold, score;

        public List<string> menuDraw;
        private List<string> empty, forest, mine, goldMine, townCenter, farm, lumberCamp, quarry, miningCamp, sawmill, blacksmith, market, palace, castle, temple,statue, university, wonder, build;
        private Dictionary<string, List<string>> menuOptions;
        private bool defaultMenu = true;


        private bool drawEndScreen = false;
        //private bool defaultMenu = true;

        public UI(Board brd, Cursor cursor, SpriteBatch sprt, SpriteFont fnt, GraphicsDeviceManager gfx)
        {
            drawEndScreen = false;

            gameBoard = brd;
            this.cursor = cursor;

            spriteBatch = sprt;
            font = fnt;

            graphics = gfx;

            green = new Color(130, 141, 105);
            darkGreen = new Color(63, 68, 55);

            /*wood = 0;
            stone = 0;
            gold = 0;
            score = 0;
            */
            menuDraw = new List<string>();

            empty = new List<string>();
            forest = new List<string>();
            mine = new List<string>();
            goldMine = new List<string>();
            townCenter = new List<string>();
            farm = new List<string>();
            lumberCamp = new List<string>();
            quarry = new List<string>();
            miningCamp = new List<string>();
            sawmill = new List<string>();
            blacksmith = new List<string>();
            market = new List<string>();
            palace = new List<string>();
            castle = new List<string>();
            temple = new List<string>();
            statue = new List<string>();
            university = new List<string>();
            wonder = new List<string>();
            build = new List<string>();

            #region options
            empty.Add("Build");
            empty.Add("Leave");

            forest.Add("Harvest");
            forest.Add("Build Lumber Camp");
            forest.Add("Clear");
            forest.Add("Leave");

            mine.Add("Build Quarry");
            mine.Add("Clear");
            mine.Add("Leave");

            goldMine.Add("Build Mining Camp");
            goldMine.Add("Clear");
            goldMine.Add("Leave");

            townCenter.Add("End Game");
            townCenter.Add("Leave");

            farm.Add("Demolish");
            farm.Add("Leave");

            lumberCamp.Add("Demolish");
            lumberCamp.Add("Leave");

            quarry.Add("Demolish");
            quarry.Add("Leave");

            miningCamp.Add("Demolish");
            miningCamp.Add("Leave");

            sawmill.Add("Demolish");
            sawmill.Add("Leave");

            blacksmith.Add("Demolish");
            blacksmith.Add("Leave");

            market.Add("Sell Wood");
            market.Add("Sell Stone");
            market.Add("Buy Wood");
            market.Add("Buy Stone");
            market.Add("Demolish");
            market.Add("Leave");

            palace.Add("Demolish");
            palace.Add("Leave");

            castle.Add("Demolish");
            castle.Add("Leave");

            temple.Add("Demolish");
            temple.Add("Leave");

            statue.Add("Demolish");
            statue.Add("Leave");

            university.Add("Demolish");
            university.Add("Leave");

            wonder.Add("Demolish");
            wonder.Add("Leave");

            build.Add("Town Center (x1) \n125g 125s 125w");
            build.Add("Farm \n100g 50s 100w");
            build.Add("Sawmill \n25g 50s 100w");
            build.Add("Blacksmith \n50g 75s 25w");
            build.Add("Market \n125g 75s 75w");
            build.Add("Palace \n300g 225s 200w");
            build.Add("Castle \n175g 350s 125w");
            build.Add("Temple \n375g 200s 100w");
            build.Add("Statue \n50g 150s 25w");
            build.Add("University \n250g 125s 200w");
            build.Add("Wonder (x1) (University) \n500g 375s 250w");
            build.Add("Leave");
            #endregion

            menuOptions = new Dictionary<string, List<string>>();
            menuOptions.Add("Empty", empty);
            menuOptions.Add("Forest", forest);
            menuOptions.Add("Mine", mine);
            menuOptions.Add("Gold Mine", goldMine);
            menuOptions.Add("Town Center", townCenter);
            menuOptions.Add("Farm", farm);
            menuOptions.Add("Lumber Camp", lumberCamp);
            menuOptions.Add("Quarry", quarry);
            menuOptions.Add("Mining Camp", miningCamp);
            menuOptions.Add("Sawmill", sawmill);
            menuOptions.Add("Blacksmith", blacksmith);
            menuOptions.Add("Market", market);
            menuOptions.Add("Palace", palace);
            menuOptions.Add("Castle", castle);
            menuOptions.Add("Temple", temple);
            menuOptions.Add("Statue", statue);
            menuOptions.Add("University", university);
            menuOptions.Add("Wonder", wonder);
            menuOptions.Add("Build", build);

        }

        public void LoadSprites(ContentManager content)
        {
            woodSprite = content.Load<Texture2D>("brdCorWood");
            stoneSprite = content.Load<Texture2D>("brdCorStone");
            goldSprite = content.Load<Texture2D>("brdCorGold");

            daylabel = content.Load<Texture2D>("daylabel");
        }

        private void DrawResourceScoreTiles()
        {
            //titles
            spriteBatch.Draw(woodSprite, new Vector2(0 * woodSprite.Width, 0 * woodSprite.Height), Color.White);
            spriteBatch.Draw(stoneSprite, new Vector2(8 * stoneSprite.Width, 0 * stoneSprite.Height), Color.White);
            spriteBatch.Draw(goldSprite, new Vector2(0 * goldSprite.Width, 8 * goldSprite.Height), Color.White);

            spriteBatch.DrawString(font, "Score", new Vector2(520, 520), green);

            //values
            spriteBatch.DrawString(font, gameBoard.wood.ToString(), new Vector2(8, 48), green);
            spriteBatch.DrawString(font, gameBoard.stone.ToString(), new Vector2(520, 48), green);
            spriteBatch.DrawString(font, gameBoard.gold.ToString(), new Vector2(8, 560), green);
            spriteBatch.DrawString(font, gameBoard.score.ToString(), new Vector2(520, 560), green);

        }

        private void MenuManager()
        {
            if (cursor.menuActive)
            {
                switch (cursor.selectedTile.TileType)
                {
                    case "Empty":
                        if (cursor.buildMenu)
                        {
                            menuDraw = build;
                        }
                        else
                        {
                            menuDraw = empty;
                        }
                        
                        defaultMenu = false;
                        break;
                    case "Forest":
                        menuDraw = forest;
                        defaultMenu = false;
                        break;
                    case "Mine":
                        menuDraw = mine;
                        defaultMenu = false;
                        break;
                    case "Gold Mine":
                        menuDraw = goldMine;
                        defaultMenu = false;
                        break;
                    case "Town Center":
                        menuDraw = townCenter;
                        defaultMenu = false;
                        break;
                    case "Farm":
                        menuDraw = farm;
                        defaultMenu = false;
                        break;
                    case "Lumber Camp":
                        menuDraw = lumberCamp;
                        defaultMenu = false;
                        break;
                    case "Quarry":
                        menuDraw = quarry;
                        defaultMenu = false;
                        break;
                    case "Mining Camp":
                        menuDraw = miningCamp;
                        defaultMenu = false;
                        break;
                    case "Sawmill":
                        menuDraw = sawmill;
                        defaultMenu = false;
                        break;
                    case "Blacksmith":
                        menuDraw = blacksmith;
                        defaultMenu = false;
                        break;
                    case "Market":
                        menuDraw = market;
                        defaultMenu = false;
                        break;
                    case "Palace":
                        menuDraw = palace;
                        defaultMenu = false;
                        break;
                    case "Castle":
                        menuDraw = castle;
                        defaultMenu = false;
                        break;
                    case "Temple":
                        menuDraw = temple;
                        defaultMenu = false;
                        break;
                    case "University":
                        menuDraw = university;
                        defaultMenu = false;
                        break;
                    case "Wonder":
                        menuDraw = wonder;
                        defaultMenu = false;
                        break;
                    default:
                        defaultMenu = true;
                        break;
                }
                cursor.menuCount = menuDraw.Count;
            }
            else
            {
                defaultMenu = true;
            }
        }

        private void DrawMenu()
        {
            int i = 0;

            if (!defaultMenu)
            {
                if (cursor.buildMenu)
                {
                    foreach (var line in menuDraw)
                    {
                        spriteBatch.DrawString(font, line, new Vector2(620, 62 + i), darkGreen);
                        i += 30;
                    }
                }
                else
                {
                    foreach (var line in menuDraw)
                    {
                        spriteBatch.DrawString(font, line, new Vector2(620, 62 + i), darkGreen);
                        i += 20;
                    }
                }
            }else
            {
                spriteBatch.DrawString(font, "Select a tile", new Vector2(650, 92), darkGreen);
                spriteBatch.DrawString(font, "to show other options", new Vector2(615, 124), darkGreen);
                spriteBatch.DrawString(font, "(SPACE)", new Vector2(680, 156), darkGreen);
            }
        }
        
        public void Update()
        {
            if (!gameBoard.endGame)
            {
                #region Score
                //check building score
                for (int x = 0; x < gameBoard.Columns; x++)
                {
                    for (int y = 0; y < gameBoard.Rows; y++)
                    {
                        if (gameBoard.tiles[x, y].building && !gameBoard.tiles[x, y].scored)
                        {
                            switch (gameBoard.tiles[x, y].TileType)
                            {
                                case "Town Center":
                                    gameBoard.score += 1000;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Farm":
                                    gameBoard.score += 100;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Lumber Camp":
                                    gameBoard.score += 250;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                //TODO: add more buildings to score
                                case "Quarry":
                                    gameBoard.score += 250;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Mining Camp":
                                    gameBoard.score += 250;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Sawmill":
                                    gameBoard.score += 100;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Blacksmith":
                                    gameBoard.score += 1000;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Market":
                                    gameBoard.score += 1500;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Palace":
                                    gameBoard.score += 5000;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Castle":
                                    gameBoard.score += 2000;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Temple":
                                    gameBoard.score += 2500;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Statue":
                                    gameBoard.score += 200;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "University":
                                    gameBoard.score += 3000;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                case "Wonder":
                                    gameBoard.score += 10000;
                                    gameBoard.tiles[x, y].scored = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                #endregion

                MenuManager();
            }
            else
            {
                drawEndScreen = true;
            }
        }

        private void DrawDay()
        {
            spriteBatch.Draw(daylabel, new Vector2(256, 22), Color.White);
            spriteBatch.DrawString(font, "Day", new Vector2(263, 26), green);

            if (gameBoard.day >=100)
            {
                spriteBatch.DrawString(font, gameBoard.day.ToString(), new Vector2(293, 26), green);
            }
            else if (gameBoard.day >=10)
            {
                spriteBatch.DrawString(font, gameBoard.day.ToString(), new Vector2(297, 26), green);
            }
            else
            {
                spriteBatch.DrawString(font, gameBoard.day.ToString(), new Vector2(300, 26), green);
            }
            //spriteBatch.DrawString(font, /*gameBoard.day.ToString()*/ "0", new Vector2(300,26), green);
            //spriteBatch.DrawString(font, /*gameBoard.day.ToString()*/ "10", new Vector2(297, 26), green);
            
        }

        public void Draw()
        {
            DrawResourceScoreTiles();

            //menu
            spriteBatch.DrawString(font, "Menu", new Vector2(682, 32), darkGreen);

            DrawMenu();

            DrawDay();
            //DrawEmptyMenu();
            //MenuManager();

            if (drawEndScreen)
            {
                Texture2D rect = new Texture2D(graphics.GraphicsDevice, 256, 128);

                Color[] data = new Color[256 * 128];
                for (int i = 0; i < data.Length; ++i) data[i] = green;
                rect.SetData(data);

                spriteBatch.Draw(rect, new Vector2(256, 192), Color.Gray);

                spriteBatch.DrawString(font, "Ending -", new Vector2(286,222),green);
                spriteBatch.DrawString(font, "Days -", new Vector2(286, 252), green);
                spriteBatch.DrawString(font, "Score -", new Vector2(286, 282), green);

                if (gameBoard.noTime)
                {
                    spriteBatch.DrawString(font, "Days Expired", new Vector2(376, 222), green);
                }
                else if (gameBoard.finishWonder)
                {
                    spriteBatch.DrawString(font, "Wonder Built", new Vector2(376, 222), green);
                }
                else if (gameBoard.towncenterEnd)
                {
                    spriteBatch.DrawString(font, "You left", new Vector2(396, 222), green);
                }
                else
                {
                    spriteBatch.DrawString(font, "default", new Vector2(396, 222), green);
                }

                spriteBatch.DrawString(font, gameBoard.day.ToString(), new Vector2(396, 252), green);
                spriteBatch.DrawString(font, gameBoard.score.ToString(), new Vector2(396, 282), green);
            }
            //exit notice
            spriteBatch.DrawString(font, "PRESS (ESC) TO EXIT", new Vector2(630, 532), darkGreen);
        }
    }
}
