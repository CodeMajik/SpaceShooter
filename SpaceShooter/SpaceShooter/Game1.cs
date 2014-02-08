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

namespace SpaceShooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundManager mSoundMgr;
        TextureMap plrMap, laserMap, enemyMap, bossMap;
        Texture2D background, background2;
        AnimatedSprite explosion;
        Vector2 bg2pos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
        }

        void startGame()
        {
            Constants.mMenuScreen.destroy();
            Constants.mScreenStack.push(Constants.mMainGameScreen);
        }

        void back()
        {
            Constants.mScreenStack.pop();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("background1");
            background2 = Content.Load<Texture2D>("background2");
            Constants.init(ref graphics, ref spriteBatch, Content);
            plrMap = new TextureMap(Content.Load<Texture2D>("playership1"), 1, 1);
            laserMap = new TextureMap(Content.Load<Texture2D>("laser1"), 1, 1);
            enemyMap = new TextureMap(Content.Load<Texture2D>("enemy1"), 1, 1);
            bossMap = new TextureMap(Content.Load<Texture2D>("boss1"), 1, 1);

            Constants.player = new Player(Constants.DEFAULT_POSITION, plrMap, laserMap);
            explosion = new AnimatedSprite(Content.Load<Texture2D>("explosion1"), 1, 10, 55);
            Constants.mAnimationManager.addAnimation(new Animation(explosion, new Vector2(200.0f, 200.0f)));

            bg2pos = new Vector2(0.0f, -800.0f);
            Constants.mMainGameScreen = new GameScreen(ref spriteBatch, ref Constants.player, enemyMap, laserMap, bossMap, "background1", "background2");
            Constants.mSplashScreen = new SplashScreen("splashscreen1", ref spriteBatch, "Press Space To Begin");
            Constants.mEndScreenLose = new SplashScreen("splashscreen3", ref spriteBatch, "Press Escape To Exit");
            Constants.mEndScreenWin = new SplashScreen("splashscreen2", ref spriteBatch, "Press Escape To Exit");

            Vector2 menuPos = new Vector2((graphics.PreferredBackBufferWidth / 2)-32.0f, (graphics.PreferredBackBufferHeight * 0.33f));
            List<Button> btns = new List<Button>();
            btns.Add(new Button(new TextureMap(Content.Load<Texture2D>("ButtonStart"), 1, 1),
               new Vector2(menuPos.X, menuPos.Y), this.startGame));
            btns.Add(new Button(new TextureMap(Content.Load<Texture2D>("ButtonQuit"), 1, 1),
               new Vector2(menuPos.X, menuPos.Y + 36), this.Exit));

            Constants.mMenuScreen = new MenuScreen(ref spriteBatch, btns);
            Constants.mScreenStack.push(Constants.mSplashScreen);

            mSoundMgr = new SoundManager();

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

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            if (!Constants.paused)
                Constants.mScreenStack.update(gameTime, Keyboard.GetState(), Mouse.GetState());
            else
                Constants.mMainGameScreen.controls(Keyboard.GetState());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            Constants.mScreenStack.draw();
            if (Constants.paused)
                spriteBatch.DrawString(Constants.mUiManager.Font, Constants.pauseString, new Vector2(graphics.PreferredBackBufferWidth / 2 - 64, graphics.PreferredBackBufferHeight / 2-32), Color.Yellow
                    ,0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 1.0f);
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
