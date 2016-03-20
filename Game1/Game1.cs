using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Texture2D[,] spriteSheet = new Texture2D[8,8];
        Texture2D chMech;
        float time;
        float frameTime = 0.1f;
        int frameIndex;
        const int totalFrames = 3;
        int frameHeight = 64;
        int frameWidth = 64;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 64, graphics
               // .GraphicsDevice.Viewport.Height / 2 - 64);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //spriteSheet = this.Content.Load<Texture2D>("Landscape/landscape_17"); 
            for (int i = 0; i < spriteSheet.Length / 8; i++)
            {
                for (int j = 0; j < spriteSheet.Length / 8; j++)
                {
                    spriteSheet[i, j] = this.Content.Load<Texture2D>("Landscape/landscape_21");
                }
            }
            chMech = this.Content.Load<Texture2D>("Characters/mech2_src");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.
            //    Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            KeyboardState state = Keyboard.GetState();
            // TODO: Add your update logic here
            if (state.IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.D))
                chMech.position.X += 10;
            if (state.IsKeyDown(Keys.A))
                position.X -= 10;
            if (state.IsKeyDown(Keys.W))
                position.Y -= 10;
            if (state.IsKeyDown(Keys.S))
                position.Y += 10;
                
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > frameTime)
            {
                frameIndex++;

                time = 0f;
            }
            spriteBatch.Begin();
            //spriteBatch.Draw(spriteSheet, position);
            for (int i = 0; i < spriteSheet.Length / 8; i++)
            {
                for(int j = 0; j < spriteSheet.Length / 8; j++)
                {
                    spriteBatch.Draw(spriteSheet[i, j], new Vector2(i * spriteSheet[i, j].Width / 2, j * spriteSheet[i, j].Height / 2));
                }
            }
            spriteBatch.End();
            // TODO: Add your drawing code here
            //Rectangle source = new Rectangle(frameIndex * frameWidth, 0, frameWidth, frameHeight);
            //Vector2 position = new Vector2(this.Window.ClientBounds.Width / 2,
            //    this.Window.ClientBounds.Height / 2);
            //Vector2 origin = new Vector2(frameWidth / 2.0f, frameHeight);
            //spriteBatch.Begin();
            //spriteBatch.Draw(spriteSheet, position, source, Color.White,0.0f, origin,1.0f,SpriteEffects.None,0.0f);
            //spriteBatch.End();         
            base.Draw(gameTime);
        }
    }
}
