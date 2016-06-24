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
    class Tile
    {

        private int x, y;
        private string tileType;
        public bool building = false;
        public bool scored = false;

        private SpriteBatch spriteBatch;

        private Texture2D sprite; //, corner, ver, hor, empty, forest, mine, gold; //... add more if needed (each tile has a diferent sprite)
        private List<Texture2D> forestSprites, emptySprites;

        private float spriteWidth, spriteHeight;

        /// <summary>
        /// Create placeholder tile
        /// </summary>
        public Tile(int x, int y, SpriteBatch spriteBatch)
        {
            this.x = x;
            this.y = y;

            tileType = "null";

            this.spriteBatch = spriteBatch;
        }

        /// <summary>
        /// Create standard tile
        /// </summary>
        public Tile(int x, int y, string type, SpriteBatch spriteBatch, bool bld = false)
        {
            this.x = x;
            this.y = y;

            tileType = type;
            building = bld;

            this.spriteBatch = spriteBatch;
        }

        public void LoadTileSprite(ContentManager content, Random rnd)
        {
            forestSprites = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    forestSprites.Add(content.Load<Texture2D>("Forest" + i.ToString() + j.ToString()));
                }
            }

            emptySprites = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                emptySprites.Add(content.Load<Texture2D>("Empty" + i.ToString()));
            }
            

            //forestSprites.Add(content.Load<Texture2D>("forest01"));
            //forestSprites.Add(content.Load<Texture2D>("forest02"));
            //forestSprites.Add(content.Load<Texture2D>("forest03"));

            switch (tileType)
            {
                case "Forest":
                    sprite = forestSprites[rnd.Next(forestSprites.Count)];
                    break;
                case "Empty":
                    sprite = emptySprites[rnd.Next(emptySprites.Count)];
                    break;
                default:
                    sprite = content.Load<Texture2D>(tileType);
                    break;
            }

            spriteWidth = sprite.Width;
            spriteHeight = sprite.Height;
        }

        public void Update()
        {
            //TODO: update function
        }

        public void Draw()
        {
            spriteBatch.Draw(sprite, new Vector2(x * spriteWidth, y * spriteHeight), Color.White);
        }

        #region {get;set;}
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public string TileType
        {
            get { return tileType; }
            set { tileType = value; }
        }

        public bool isPlaceHolder
        {
            get { return tileType == "null"; }
        }
        #endregion
    }
}
