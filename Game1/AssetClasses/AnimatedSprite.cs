using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    namespace AssetClasses
    {
        abstract class AnimatedSprite
        {
            protected Texture2D sTexture;
            protected int animCount;
            protected bool idle;
            private Vector2 sPosition;
            private Rectangle[] sRectangles;
            private int frameIndex;
            //protected string[] DirectionRef = new string[8] {"east", "north", "northeast", "northwest", "south", "southeast", "southwest", "west"};
            private double timeElapsed;
            private double timeToUpdate;
            //protected int animSelect = 0;
            public enum movementDirections { east = 0, north = 1, northeast = 2, northwest = 3, south = 4, southeast = 5, southwest = 6, west = 7, idle = 8 };
            protected movementDirections currentDirection;

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
                    sRectangles[i] = new Rectangle(i * width, (sTexture.Height / animCount) * (int)currentDirection, width, sTexture.Height / animCount);
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
                    switch (currentDirection)
                    {
                        case movementDirections.east:
                            sPosition.X += 1;
                            break;
                        case movementDirections.north:
                            sPosition.Y -= 1;
                            break;
                        case movementDirections.west:
                            sPosition.X -= 1;
                            break;
                        case movementDirections.south:
                            sPosition.Y += 1;
                            break;
                        case movementDirections.southwest:
                            sPosition.X -= 0.5f;
                            sPosition.Y += 0.5f;
                            break;
                        case movementDirections.southeast:
                            sPosition.X += 0.5f;
                            sPosition.Y += 0.5f;
                            break;
                        case movementDirections.northwest:
                            sPosition.X -= 0.5f;
                            sPosition.Y -= 0.5f;
                            break;
                        case movementDirections.northeast:
                            sPosition.X += 0.5f;
                            sPosition.Y -= 0.5f;
                            break;
                    }
                }
                spriteBatch.Draw(sTexture, sPosition, sRectangles[frameIndex], Color.White);
            }
        }
    }
}
