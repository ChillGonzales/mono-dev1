using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    abstract class AnimatedSprite
    {
        protected Texture2D sTexture;
        protected int animCount;
        protected bool idle;
        private Vector2 sPosition;
        private Rectangle[] sRectangles;
        private int frameIndex;
        //protected Dictionary<string, int> dictDirectionRef = new Dictionary<string, int> { {"east", 0},{"north",1},
        //                                                   {"northeast",2}, {"northwest",3}, {"south",4}, {"southeast",5}, {"southwest",6}, {"west",7} };
        protected string[] DirectionRef = new string[8] {"east", "north", "northeast", "northwest", "south", "southeast", "southwest", "west"};
        private double timeElapsed;
        private double timeToUpdate;
        protected int animSelect = 0;

        public int framesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }

        public AnimatedSprite(Vector2 position)
        {
            sPosition = position;
        }

        public void AddAnimation(int frames)
        {
            int width = sTexture.Width / frames;
            sRectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                sRectangles[i] = new Rectangle(i * width, (sTexture.Height/animCount) * animSelect, width, sTexture.Height / animCount);
            }
        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;
                if ((frameIndex < sRectangles.Length - 1) && !idle)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!idle)
            {                
                switch (DirectionRef[animSelect])
                {
                    case "east":
                        sPosition.X += 1;
                        break;
                    case "north":
                        sPosition.Y -= 1;
                        break;
                    case "west":
                        sPosition.X -= 1;
                        break;
                    case "south":
                        sPosition.Y += 1;
                        break;
                    case "southwest":
                        sPosition.X -= 0.5f;
                        sPosition.Y += 0.5f;
                        break;
                    case "southeast":
                        sPosition.X += 0.5f;
                        sPosition.Y += 0.5f;
                        break;
                    case "northwest":
                        sPosition.X -= 0.5f;
                        sPosition.Y -= 0.5f;
                        break;
                    case "northeast":
                        sPosition.X += 0.5f;
                        sPosition.Y -= 0.5f;
                        break;
                } 
            }
            spriteBatch.Draw(sTexture, sPosition,sRectangles[frameIndex], Color.White);
        }
    }
}
