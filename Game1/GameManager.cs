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
    class GameManager
    {
        private bool gameStarted;
        

        public void BeginGame(ref Enemy enemyInst)
        {
            gameStarted = true;
            enemyInst.ChangeDirection(AnimatedSprite.movementDirections.southwest);
        }

        public void AddTower()
        {
            var tower = new Tower();

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
