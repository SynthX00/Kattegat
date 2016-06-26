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
        public bool changeTile = false;

        private SpriteBatch spriteBatch;

        private Texture2D sprite; //, corner, ver, hor, empty, forest, mine, gold; //... add more if needed (each tile has a diferent sprite)
        private Texture2D statue, farm, lumberCamp, quarry, miningCamp, sawmill, blacksmith, market, palace, castle, temple, university, wonder, townCenter;

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
            emptySprites = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                emptySprites.Add(content.Load<Texture2D>("Empty" + i.ToString()));
            }

            forestSprites = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    forestSprites.Add(content.Load<Texture2D>("Forest" + i.ToString() + j.ToString()));
                }
            }

            statue = content.Load<Texture2D>("Statue");
            farm = content.Load<Texture2D>("Farm");
            lumberCamp = content.Load<Texture2D>("Lumber Camp");
            quarry = content.Load<Texture2D>("Quarry");
            miningCamp = content.Load<Texture2D>("Mining Camp");
            sawmill = content.Load<Texture2D>("Sawmill");
            blacksmith = content.Load<Texture2D>("Blacksmith");
            market = content.Load<Texture2D>("Market");
            palace = content.Load<Texture2D>("Palace");
            castle = content.Load<Texture2D>("Castle");
            temple = content.Load<Texture2D>("Temple");
            university = content.Load<Texture2D>("University");
            wonder = content.Load<Texture2D>("Wonder");
            townCenter = content.Load<Texture2D>("Town Center");

            switch (tileType)
            {
                case "Empty":
                    sprite = emptySprites[rnd.Next(emptySprites.Count)];
                    break;
                case "Forest":
                    sprite = forestSprites[rnd.Next(forestSprites.Count)];
                    break;
                //TODO: Stone/Gold
                case "Statue":
                    sprite = statue;
                    break;
                case "Farm":
                    sprite = farm;
                    break;
                case "Lumber Camp":
                    sprite = lumberCamp;
                    break;
                case "Quarry":
                    sprite = quarry;
                    break;
                case "Mining Camp":
                    sprite = miningCamp;
                    break;
                case "Sawmill":
                    sprite = sawmill;
                    break;
                case "Blacksmith":
                    sprite = blacksmith;
                    break;
                case "Market":
                    sprite = market;
                    break;
                case "Palace":
                    sprite = palace;
                    break;
                case "Castle":
                    sprite = castle;
                    break;
                case "Temple":
                    sprite = temple;
                    break;
                case "University":
                    sprite = university;
                    break;
                case "Wonder":
                    sprite = wonder;
                    break;
                case "Town Center":
                    sprite = townCenter;
                    break;
                //TODO: Add other tiles
                default:
                    sprite = content.Load<Texture2D>(tileType);
                    break;
            }

            spriteWidth = sprite.Width;
            spriteHeight = sprite.Height;
        }

        public void Update(Random rnd)
        {
            //TODO: update function
            if (changeTile)
            {
                switch (tileType)
                {
                    case "Empty":
                        sprite = emptySprites[rnd.Next(emptySprites.Count)];
                        changeTile = false;
                        break;
                    case "Statue":
                        sprite = statue;
                        changeTile = false;
                        break;
                    case "Farm":
                        sprite = farm;
                        changeTile = false;
                        break;
                    case "Lumber Camp":
                        sprite = lumberCamp;
                        changeTile = false;
                        break;
                    case "Quarry":
                        sprite = quarry;
                        changeTile = false;
                        break;
                    case "Mining Camp":
                        sprite = miningCamp;
                        changeTile = false;
                        break;
                    case "Sawmill":
                        sprite = sawmill;
                        changeTile = false;
                        break;
                    case "Blacksmith":
                        sprite = blacksmith;
                        changeTile = false;
                        break;
                    case "Market":
                        sprite = market;
                        changeTile = false;
                        break;
                    case "Palace":
                        sprite = palace;
                        changeTile = false;
                        break;
                    case "Castle":
                        sprite = castle;
                        changeTile = false;
                        break;
                    case "Temple":
                        sprite = temple;
                        changeTile = false;
                        break;
                    case "University":
                        sprite = university;
                        changeTile = false;
                        break;
                    case "Wonder":
                        sprite = wonder;
                        changeTile = false;
                        break;
                    case "Town Center":
                        sprite = townCenter;
                        changeTile = false;
                        break;
                    //TODO: Add other tiles
                    default:
                        //TODO:probably need to preload sprites in "LoadTileSprites"
                        //sprite = content.Load<Texture2D>(tileType);
                        break;
                }
            }
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
