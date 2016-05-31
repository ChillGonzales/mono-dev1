using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Game1.Physics;

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
            public CircleCollider2D CircleCollider;
            private double timeElapsed;
            private double fireRate = 1f;
            private Vector2 currentTarget;
            public Vector2 SetTarget { get; set; }
            public Texture2D SetProjectile { get; set; }

            public Tower(Vector2 pos, Texture2D _towerTexture, int _screenX, int _screenY)
            {
                towerPos = pos;
                firstClick = true;
                towerTexture = _towerTexture;
                screenX = _screenX;
                screenY = _screenY;
                CircleCollider = new CircleCollider2D(towerPos, 100.0f);
            }

            public void Update(GameTime gameTime)
            {
                if (firstClick)
                {
                    towerPos.X = Cursor.Position.X - screenX;
                    towerPos.Y = Cursor.Position.Y - screenY;
                    CircleCollider.Center = towerPos;
                }
                timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
                if (timeElapsed > fireRate) {
                    timeElapsed -= fireRate;
                    FireProjectile();
                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(towerTexture, towerPos, Color.White);
            }

            public void FireProjectile()
            {                
                Debug.Print("Projectile Fired!" + Environment.NewLine);
            }            
        }
    }
}
