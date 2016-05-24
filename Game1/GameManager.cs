using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Drawing;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game1.AssetClasses;

namespace Game1
{
    class GameManager
    {
        private bool gameStarted;
        private List<Tower> towerList;
        private Texture2D towerTexture;
        public Tower activeTower;
        public void BeginGame(ref Enemy enemyInst)
        {
            gameStarted = true;
            enemyInst.ChangeDirection(AnimatedSprite.movementDirections.southwest);
        }

        public void AddTower(int screenX, int screenY)
        {
            if (towerList == null)
            {
                towerList = new List<Tower>();
            }
            
            activeTower = new Tower(new Vector2(Cursor.Position.X, Cursor.Position.Y), towerTexture, screenX, screenY);
            towerList.Add(activeTower);

        }
        public void Update()
        {
            if (towerList != null)
            {
                foreach (var item in towerList)
                {
                    item.Update();
                }
            }
        }
        public void LoadContent(ContentManager content)
        {
            towerTexture = content.Load<Texture2D>("Landscape/landscape_00");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (towerList != null) {
                foreach (var item in towerList)
                {
                    item.Update();
                    item.Draw(spriteBatch);
                }
            }
        }
    }
}
