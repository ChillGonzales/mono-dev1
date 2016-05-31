using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.AssetClasses
{
    class RedProjectile : AnimatedSprite        
    {
        private bool flyAnim, explodeAnim;

        public RedProjectile(Vector2 position) : base(position)
        {
            framesPerSecond = 5;
            flyAnim = true;
            explodeAnim = false;
            animCount = 3;
            AddAnimation(3);
        }
        public void LoadContent(ContentManager content)
        {
            
        }
    }
}
