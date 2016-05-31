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
        private Texture2D redProjectileTexture;
        public Tower activeTower;
        private List<Enemy> enemyList;
        private double timeElapsed;
        private double timeToUpdate = 1/30f;

        public void BeginGame(ref List<Enemy> enemyListInst)
        {
            gameStarted = true;
            enemyList = enemyListInst;            
            enemyListInst[0].ChangeDirection(AnimatedSprite.movementDirections.southwest);
        }

        public void AddTower(int screenX, int screenY)
        {
            if (towerList == null)
            {
                towerList = new List<Tower>();
            }
            
            activeTower = new Tower(new Vector2(Cursor.Position.X, Cursor.Position.Y), towerTexture, screenX, screenY);            
            towerList.Add(activeTower);
            activeTower.SetProjectile = redProjectileTexture;

        }
        public void Update(GameTime gameTime)
        {            
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate && gameStarted)
            {
                timeElapsed -= timeToUpdate;
                foreach (var tower in towerList)
                {                    
                    foreach (var enemy in enemyList)
                    {
                        if (tower.CircleCollider.Contains(enemy.Position)){
                            tower.SetTarget = enemy.Position;
                        }
                    }
                }                
            }
            if (towerList != null)
            {
                foreach (var tower in towerList)
                {
                    tower.Update(gameTime);
                }
            }
        }
        public void LoadContent(ContentManager content)
        {
            towerTexture = content.Load<Texture2D>("Buildings/tower_35");
            redProjectileTexture = content.Load<Texture2D>("Projectiles/RedProjectile");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (towerList != null) {
                foreach (var item in towerList)
                {                    
                    item.Draw(spriteBatch);
                }
            }
        }
    }
}
