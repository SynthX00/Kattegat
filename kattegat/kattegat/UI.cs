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

        public void MenuManager(bool selected = false)
        {
            if (selected)
            {

            }
            else
            {
                DrawMenu(true);
            }
        }

        private void DrawEmptyMenu()
        {
            spriteBatch.DrawString(font, "Menu", new Vector2(682, 32), darkGreen);
            spriteBatch.DrawString(font, "Select a tile", new Vector2(650, 92), darkGreen);
            spriteBatch.DrawString(font, "to show other options", new Vector2(615, 124), darkGreen);
            spriteBatch.DrawString(font, "(SPACE)", new Vector2(680, 156), darkGreen);
        }

        private void DrawMenu(bool dflt)
        {
            if (dflt)
            {
                DrawEmptyMenu();
            }
            else
            {

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
            DrawMenu();

            //exit notice
            spriteBatch.DrawString(font, "PRESS (ESC) TO EXIT", new Vector2(630, 532), darkGreen);
        }
    }
}
