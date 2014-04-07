using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace CE_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //for adding the sprite manager
        public SpriteManager spriteManager;

        //camera
        public Camera camera;

        //game state
        public enum GameState 
        {
            Start, 
            LevelOne, 
            GameOver,
            End
        };

        public  GameState state = GameState.Start;

        KeyboardState board;

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

            //adding the sprite manager
            spriteManager = new SpriteManager(this);
            Components.Add(spriteManager);

            spriteManager.Enabled = false;
            spriteManager.Visible = false;

            //make mouse visible
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            board = Keyboard.GetState();

            switch (state)
            {
                case GameState.Start:
                    if (board.IsKeyDown(Keys.Space))
                    {
                        state = GameState.LevelOne;
                        spriteManager.Enabled = true;
                        spriteManager.Visible = true;
                    }
                    break;

                case GameState.LevelOne:
                    break;

                case GameState.GameOver:
                    spriteManager.Enabled = false;
                    spriteManager.Visible = false;
                    if (board.IsKeyDown(Keys.Space))
                    {
                       // spriteManager.player.HP = spriteManager.player.statHP;
                        //spriteManager.player.Mana = spriteManager.player.statMana;
                        spriteManager.Enabled = true;
                        spriteManager.Visible = true;
                        state = GameState.LevelOne;
                    }
                    break;

                case GameState.End:
                    if (board.IsKeyDown(Keys.Space))
                    {
                  
                        spriteManager.Enabled = false;
                        spriteManager.Visible = false;
                        Exit();
                    }
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            

            switch (state)
            {
                case GameState.Start:
                    graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Content.Load<SpriteFont>(@"Fonts\Arial"), "Press Space To Start",
                    new Vector2(300, 400), Color.Silver);
                    spriteBatch.End();
                    break;

                case GameState.LevelOne:
                    graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
                    spriteBatch.Begin();
                    spriteBatch.End();
                    break;

                case GameState.GameOver:
                    graphics.GraphicsDevice.Clear(Color.Red);
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Content.Load<SpriteFont>(@"Fonts\Arial"), "Press Space To Restart",
                    new Vector2(300, 400), Color.Silver);
                    spriteBatch.End();
                    break;

                case GameState.End:
                    graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Content.Load<SpriteFont>(@"Fonts\Arial"), "Press Space To Exit",
                    new Vector2(300, 400), Color.Silver);
                    spriteBatch.End();
                    break;
                    
            }

           

            base.Draw(gameTime);
        }
    }
}
