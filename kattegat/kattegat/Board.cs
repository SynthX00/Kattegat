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
    class Board
    {
        private int columns, rows;

        public Tile[,] tiles;
        //private List<Tile> emptyTiles;

        private SpriteBatch spriteBatch;
        private SpriteFont font;
        //private Random _rnd;

        public Board(int x, int y, SpriteBatch spriteBatch, SpriteFont font)
        {
            columns = x;
            rows = y;

            tiles = new Tile[columns, rows];

            this.spriteBatch = spriteBatch;
            this.font = font;
        }

        public void CreateBoard(Random rnd)
        {
            _CreateEmptyBoard();

            //emptyTiles = new List<Tile>();
            //emptyTiles.Clear();
            //for (int x = 0; x < columns; x++)
            //{
            //    for (int y = 0; y < rows; y++)
            //    {
            //        if (tiles[x, y].isPlaceHolder)
            //        {
            //            emptyTiles.Add(tiles[x, y]);
            //        }
            //    }
            //}
            //...

            _GenerateNewWorld(rnd);
        }

        private void _CreateEmptyBoard()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    tiles[x, y] = new Tile(x, y, spriteBatch); //set placeholder

                    //set border
                    if (x == 0 || x == columns - 1)
                        tiles[x, y] = new Tile(x, y, "brdVer", spriteBatch);

                    if (y == 0 || y == rows - 1)
                        tiles[x, y] = new Tile(x, y, "brdHor", spriteBatch);

                    if(x == 0 && y == 0 || x == columns-1 && y == 0 || x == 0 && y == rows-1 || x == columns-1 && y == rows-1)
                        tiles[x, y] = new Tile(x, y, "brdCor", spriteBatch);
                    //...
                    //TODO: set resource & score icons

                    if(x == 0 && y == 0)
                        tiles[x, y] = new Tile(x, y, "brdCor", spriteBatch);
                    if (x == columns - 1 && y == 0)
                        tiles[x, y] = new Tile(x, y, "brdCor", spriteBatch);
                    if (x == 0 && y == rows - 1)
                        tiles[x, y] = new Tile(x, y, "brdCor", spriteBatch);
                    /*if (x == columns - 1 && y == rows - 1)
                        tiles[x, y] = new Tile(x, y, "brdCorScore", spriteBatch);*/
                }
            } 
        }

        private void _GenerateNewWorld(Random rnd)
        {
            //_rnd = new Random();

            Dictionary<int, int> deployableTiles = new Dictionary<int, int>();
            deployableTiles.Clear();
            //int forestQty, mineQty, goldQty, emptyQty;
            int rndType;

            deployableTiles.Add(0, rnd.Next(16, 16));   //forest
            deployableTiles.Add(1, rnd.Next(7, 11));    //mine
            deployableTiles.Add(2, rnd.Next(13, 16));   //forest
            deployableTiles.Add(3, rnd.Next(3, 6));     //gold
            deployableTiles.Add(4, 49 - (deployableTiles[0] + deployableTiles[1] + deployableTiles[2]));

            /*
            forestQty = _rnd.Next(26, 30);
            mineQty = _rnd.Next(7, 11);
            goldQty = _rnd.Next(3, 7);

            emptyQty = 48 - (forestQty + mineQty + goldQty);
            */
            bool deploy = false;

            for (int x = 1; x < columns-1; x++)
            {
                for (int y = 1; y < rows-1; y++)
                {
                    //tiles[x, y] = new Tile(x, y, "empty", spriteBatch);
                    rndType = rnd.Next(5);
                    deploy = false;
                    //int count = 0;
                    do
                    {
                        if (deployableTiles[rndType] - 1 < 0)
                        {
                            //deployableTiles.Remove(rndType);
                            rndType = rnd.Next(5);
                            //count++;
                        }
                        else
                        {
                            deployableTiles[rndType]--;
                            deploy = true;
                            //count = 0;
                            tiles[x, y] = new Tile(x, y, (rndType == 0 ? "Forest" : (rndType == 1 ? "Mine" : (rndType == 2 ? "Forest" : (rndType == 3 ? "Gold" : "Empty")))), spriteBatch);
                        }
                    } while (!deploy /*&& count < 1*/);
                    
                }
            }

            //set towncenter
            //_rnd = new Random();
            int rndX = rnd.Next(1, columns - 2);
            int rndY = rnd.Next(1, rows - 2);
            tiles[rndX, rndY] = new Tile(rndX, rndY, "Town Center", spriteBatch, true);
            //set random starting point - check
            //set random amount of forests - check
            //set random amount of mines - check
            //set random amount of gold mines - check
            //set all other placeholder tiles as empty - check

        }

        public void LoadSprites(ContentManager content, Random rnd)
        {
            foreach (var tile in tiles)
            {
                tile.LoadTileSprite(content, rnd);
            }
        }

        public void Update()
        {
            foreach (var tile in tiles)
            {
                tile.Update();
            }
        }

        public void Draw()
        {
            foreach (var tile in tiles)
            {
                tile.Draw();
            }
            //spriteBatch.DrawString(font, "99999", new Vector2(16, 48), new Color(130, 141, 105));
            //spriteBatch.DrawString(font, "Score", new Vector2(520, 520), new Color(130, 141, 105));
        }

        #region {get;set;}
        public int Columns
        {
            get { return columns; }
        }

        public int Rows
        {
            get { return rows; }
        }
        #endregion
    }
}