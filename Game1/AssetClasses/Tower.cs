using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    namespace AssetClasses
    {
        class Tower
        {
            private Texture2D towerTexture;
            private Vector2 towerPos;
            public bool firstClick;
            private int screenX, screenY;

            public Tower(Vector2 pos, Texture2D _towerTexture, int _screenX, int _screenY)
            {
                towerPos = pos;
                firstClick = true;
                towerTexture = _towerTexture;
                screenX = _screenX;
                screenY = _screenY;
            }

            public void Update()
            {
                if (firstClick)
                {
                    towerPos.X = Cursor.Position.X - screenX;
                    towerPos.Y = Cursor.Position.Y - screenY;
                }
            }
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(towerTexture, towerPos, Color.White);
            }
        }
    }
}
