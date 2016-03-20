using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Player : AnimatedSprite
    {
        public Player(Vector2 position) : base(position)
        {
            framesPerSecond = 10;
        }

        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("Characters/spritesheet");
            animCount = 8;
            AddAnimation(8);
        }

        public void ChangeAnimation(int AnimSelect)
        {
            animSelect = AnimSelect;
            AddAnimation(8);
        }
    }
}
