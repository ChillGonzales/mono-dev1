using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    namespace AssetClasses
    {
        public class Enemy : AnimatedSprite
        {
            public Enemy(Vector2 position) : base(position)
            {
                framesPerSecond = 10;
                idle = true;                
            }

            public void LoadContent(ContentManager content)
            {
                sTexture = content.Load<Texture2D>("Characters/spritesheet");
                animCount = 8;
                AddAnimation(8);
            }

            public void ChangeDirection(movementDirections newDirection)
            {
                if (newDirection == movementDirections.idle)
                {
                    idle = true;
                    return;
                }
                else
                {
                    idle = false;
                    //animSelect = Array.IndexOf(DirectionRef, direction);
                    currentDirection = newDirection;
                    AddAnimation(8);
                }
            }
        }
    }
}
