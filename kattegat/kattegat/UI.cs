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

        private Texture2D woodSprite, stoneSprite, goldSprite;

        private int wood, stone, gold, score;

        public UI(Board brd, SpriteBatch sprt, SpriteFont fnt)
        {
            board = brd;
            spriteBatch = sprt;
            font = fnt;

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

            spriteBatch.DrawString(font, "Score", new Vector2(520, 520), new Color(130, 141, 105));

            //values
            spriteBatch.DrawString(font, wood.ToString(), new Vector2(8, 48), new Color(130, 141, 105));
            spriteBatch.DrawString(font, stone.ToString(), new Vector2(520, 48), new Color(130, 141, 105));
            spriteBatch.DrawString(font, gold.ToString(), new Vector2(8, 560), new Color(130, 141, 105));
            spriteBatch.DrawString(font, score.ToString(), new Vector2(520, 560), new Color(130, 141, 105));

        }

        private void DrawEmptyMenu()
        {
            spriteBatch.DrawString(font, "Menu", new Vector2(692, 32), new Color(63, 68, 55));

        }

        public void Update()
        {
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
            DrawEmptyMenu();
        }
    }
}
