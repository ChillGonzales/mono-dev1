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
        Enemy enemy;
        Vector2 position;
        Texture2D[,] spriteSheet = new Texture2D[8,8];        
        float time;
        float frameTime = 0.1f;
        int frameIndex;
        const int totalFrames = 3;

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
            position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 64, graphics
                .GraphicsDevice.Viewport.Height / 2 - 64);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);            
            for (int i = 0; i < spriteSheet.Length / 8; i++)
            {
                for (int j = 0; j < spriteSheet.Length / 8; j++)
                {
                    spriteSheet[i, j] = this.Content.Load<Texture2D>("Landscape/landscape_21");
                }
            }           
            // TODO: use this.Content to load your game content here

            enemy = new Enemy(new Vector2(100f,100f));
            enemy.LoadContent(Content);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.
                Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A) && state.IsKeyDown(Keys.S))
                enemy.ChangeAnimation("southwest");
            else if (state.IsKeyDown(Keys.D) && state.IsKeyDown(Keys.S))
                enemy.ChangeAnimation("southeast");
            else if (state.IsKeyDown(Keys.D) & state.IsKeyDown(Keys.W))
                enemy.ChangeAnimation("northeast");
            else if (state.IsKeyDown(Keys.W) && state.IsKeyDown(Keys.A))
                enemy.ChangeAnimation("northwest");
            else if (state.IsKeyDown(Keys.A))
                enemy.ChangeAnimation("west");
            else if (state.IsKeyDown(Keys.D))
                enemy.ChangeAnimation("east");
            else if (state.IsKeyDown(Keys.S))
                enemy.ChangeAnimation("south");
            else if (state.IsKeyDown(Keys.W))
                enemy.ChangeAnimation("north");
            else
                enemy.ChangeAnimation("idle");
            enemy.Update(gameTime);
                        
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
            enemy.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
