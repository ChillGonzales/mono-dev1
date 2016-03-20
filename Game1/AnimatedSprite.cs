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
        private Vector2 sPosition;
        private Rectangle[] sRectangles;
        private int frameIndex;

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
                if (frameIndex < sRectangles.Length - 1)
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
            spriteBatch.Draw(sTexture, sPosition,sRectangles[frameIndex], Color.White);
        }
    }
}
