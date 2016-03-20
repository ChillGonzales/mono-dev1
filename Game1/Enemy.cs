using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Enemy : AnimatedSprite
    {
        //protected Dictionary<string, int> dictDirectionRef;
        public Enemy(Vector2 position) : base(position)
        {
            framesPerSecond = 10;
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("Characters/spritesheet");
            animCount = 8;
            AddAnimation(8);

            //dictDirectionRef = new Dictionary<string, int>();
            //dictDirectionRef.Add("east", 0);
            //dictDirectionRef.Add("north", 1);
            //dictDirectionRef.Add("northeast", 2);
            //dictDirectionRef.Add("northwest", 3);
            //dictDirectionRef.Add("south", 4);
            //dictDirectionRef.Add("southeast", 5);
            //dictDirectionRef.Add("southwest", 6);
            //dictDirectionRef.Add("west", 7);
        }

        public void ChangeAnimation(string direction)
        {
            if (direction == "idle")
            {
                idle = true;
                return;
            }
            else
            {
                idle = false;
                animSelect = Array.IndexOf(DirectionRef, direction);
                AddAnimation(8);
            }               
        }
    }
}
