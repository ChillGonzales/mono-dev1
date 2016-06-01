using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Windows;

namespace Game1.AssetClasses
{
    class RedProjectile : AnimatedSprite        
    {
        private bool flyAnim, explodeAnim, firing;
        private Vector2 currentTarget;

        public RedProjectile(Vector2 position) : base(position)
        {
            framesPerSecond = 5;
            flyAnim = true;
            explodeAnim = false;
            animCount = 1;
            idle = false;
            currentDirection = movementDirections.east;
            
            
        }
        public override void DrawFrame()
        {
            if (firing)
            {
                var distanceToTarget = new Vector2(currentTarget.X - this.sPosition.X, currentTarget.Y - this.sPosition.Y);                
                sPosition = distanceToTarget;
            }
        }
        public void Fire(Vector2 target)
        {
            firing = true;
            idle = false;
            currentTarget = target;
        }
        public void SetTexture(Texture2D texture)
        {
            sTexture = texture;
            AddAnimation(6);
        }
    }
}
