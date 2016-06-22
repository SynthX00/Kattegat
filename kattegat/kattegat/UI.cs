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
        private Board board;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        public Color green, darkGreen;

        private Texture2D woodSprite, stoneSprite, goldSprite;

        private int wood, stone, gold, score;

        private List<string> menuDraw;
        private Dictionary<string, string> menuOptions;


        //private bool defaultMenu = true;

        public UI(Board brd, SpriteBatch sprt, SpriteFont fnt)
        {
            board = brd;
            spriteBatch = sprt;
            font = fnt;

            green = new Color(130, 141, 105);
            darkGreen = new Color(63, 68, 55);

            wood = 0;
            stone = 0;
            gold = 0;
            score = 0;

            menuDraw = new List<string>();
            menuOptions = new Dictionary<string, string>();

            #region options
            menuOptions.Add("Empty", "Build...");
            menuOptions.Add("Empty", "Leave");

            menuOptions.Add("Forest", "Harvest");
            menuOptions.Add("Forest", "Build Lumber Camp");
            menuOptions.Add("Forest", "Clear");
            menuOptions.Add("Forest", "Leave");

            menuOptions.Add("Mine", "Build Quarry");
            menuOptions.Add("Mine", "Clear");
            menuOptions.Add("Mine", "Leave");

            menuOptions.Add("Gold Mine", "Build Mining Camp");
            menuOptions.Add("Gold Mine", "Clear");
            menuOptions.Add("Gold Mine", "Leave");

            menuOptions.Add("Town Center", "Leave");

            menuOptions.Add("Farm", "Demolish");
            menuOptions.Add("Farm", "Leave");

            menuOptions.Add("Lumber Camp", "Demolish");
            menuOptions.Add("Lumber Camp", "Leave");

            menuOptions.Add("Quarry", "Demolish");
            menuOptions.Add("Quarry", "Leave");

            menuOptions.Add("Mining Camp", "Demolish");
            menuOptions.Add("Mining Camp", "Leave");

            menuOptions.Add("Swamill", "Demolish");
            menuOptions.Add("Swamill", "Leave");

            menuOptions.Add("Blacksmith", "Demolish");
            menuOptions.Add("Blacksmith", "Leave");

            menuOptions.Add("Market", "Sell Wood");
            menuOptions.Add("Market", "Sell Stone");
            menuOptions.Add("Market", "Buy Wood");
            menuOptions.Add("Market", "Buy Stone");
            menuOptions.Add("Market", "Demolish");
            menuOptions.Add("Market", "Leave");

            menuOptions.Add("Palace", "Demolish");
            menuOptions.Add("Palace", "Leave");

            menuOptions.Add("Castle", "Demolish");
            menuOptions.Add("Castle", "Leave");

            menuOptions.Add("Temple", "Demolish");
            menuOptions.Add("Temple", "Leave");

            menuOptions.Add("University", "Demolish");
            menuOptions.Add("University", "Leave");

            menuOptions.Add("Wonder", "Demolish");
            menuOptions.Add("Wonder", "Leave");

            menuOptions.Add("Build", "Town Center");
            menuOptions.Add("Build", "Farm");
            menuOptions.Add("Build", "Sawmill");
            menuOptions.Add("Build", "Blacksmith");
            menuOptions.Add("Build", "Market");
            menuOptions.Add("Build", "Palace");
            menuOptions.Add("Build", "Castle");
            menuOptions.Add("Build", "Temple");
            menuOptions.Add("Build", "Statue");
            menuOptions.Add("Build", "University");
            menuOptions.Add("Build", "Wonder");
            #endregion
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
            spriteBatch.DrawString(font, wood.ToString(), new Vector2(8, 48), green);
            spriteBatch.DrawString(font, stone.ToString(), new Vector2(520, 48), green);
            spriteBatch.DrawString(font, gold.ToString(), new Vector2(8, 560), green);
            spriteBatch.DrawString(font, score.ToString(), new Vector2(520, 560), green);

        }

        private void DrawEmptyMenu()
        {
            spriteBatch.DrawString(font, "Menu", new Vector2(682, 32), darkGreen);
            spriteBatch.DrawString(font, "Select a tile", new Vector2(650, 92), darkGreen);
            spriteBatch.DrawString(font, "to show other options", new Vector2(615, 124), darkGreen);
            spriteBatch.DrawString(font, "(SPACE)", new Vector2(680, 156), darkGreen);
        }

        private void DrawMenu(string tileType)
        {
            switch (tileType)
            {
                case "Empty":
                    foreach (var key in menuOptions.Keys)
                    {
                        if (key == "Empty")
                        {
                            menuDraw.Add(menuOptions[key]);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        
        public void Update()
        {

            //check buildings
            for (int x = 0; x < board.Columns; x++)
            {
                for (int y = 0; y < board.Rows; y++)
                {
                    if (board.tiles[x,y].building && !board.tiles[x,y].scored)
                    {
                        switch (board.tiles[x, y].TileType)
                        {
                            case "towncenter":
                                score += 1000;
                                board.tiles[x, y].scored = true;
                                break;
                                //TODO: add more buildings to score
                            default:
                                break;
                        }
                    }
                }
            }


        }

        public void Draw()
        {
            DrawResourceScoreTiles();

            //DrawEmptyMenu();
            //MenuManager();

            //exit notice
            spriteBatch.DrawString(font, "PRESS (ESC) TO EXIT", new Vector2(630, 532), darkGreen);
        }
    }
}
