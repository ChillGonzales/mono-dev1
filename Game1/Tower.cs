using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Tower
    {
        private Texture2D towerTexture;
        private Vector2 towerPos;

        public void LoadContent(ContentManager content)
        {
            towerTexture = content.Load<Texture2D>("Landscape/landscape_00");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(towerTexture, towerPos, Color.White);
        }
    }
}
