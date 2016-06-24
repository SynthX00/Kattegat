using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public Color green, darkGreen;

        private Texture2D woodSprite, stoneSprite, goldSprite;

        //private int wood, stone, gold, score;

        public List<string> menuDraw;
        private List<string> empty, forest, mine, goldMine, townCenter, farm, lumberCamp, quarry, miningCamp, sawmill, blacksmith, market, palace, castle, temple,statue, university, wonder, build;
        private Dictionary<string, List<string>> menuOptions;
        private bool defaultMenu = true;

        //private bool defaultMenu = true;

        public UI(Board brd, Cursor cursor, SpriteBatch sprt, SpriteFont fnt)
        {
            gameBoard = brd;
            this.cursor = cursor;

            spriteBatch = sprt;
            font = fnt;

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

            build.Add("Town Center");
            build.Add("Farm");
            build.Add("Sawmill");
            build.Add("Blacksmith");
            build.Add("Market");
            build.Add("Palace");
            build.Add("Castle");
            build.Add("Temple");
            build.Add("Statue");
            build.Add("University");
            build.Add("Wonder");
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
                        menuDraw = empty;
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
                foreach (var line in menuDraw)
                {
                    spriteBatch.DrawString(font, line, new Vector2(620, 62 + i), darkGreen);
                    i += 20;
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
            #region Score
            //check building score
            for (int x = 0; x < gameBoard.Columns; x++)
            {
                for (int y = 0; y < gameBoard.Rows; y++)
                {
                    if (gameBoard.tiles[x,y].building && !gameBoard.tiles[x,y].scored)
                    {
                        switch (gameBoard.tiles[x, y].TileType)
                        {
                            case "Town Center":
                                gameBoard.score += 1000;
                                gameBoard.tiles[x, y].scored = true;
                                break;
                                //TODO: add more buildings to score
                            default:
                                break;
                        }
                    }
                }
            }
            #endregion

            MenuManager();
        }

        public void Draw()
        {
            DrawResourceScoreTiles();

            //menu
            spriteBatch.DrawString(font, "Menu", new Vector2(682, 32), darkGreen);

            DrawMenu();
            //DrawEmptyMenu();
            //MenuManager();

            //exit notice
            spriteBatch.DrawString(font, "PRESS (ESC) TO EXIT", new Vector2(630, 532), darkGreen);
        }
    }
}
