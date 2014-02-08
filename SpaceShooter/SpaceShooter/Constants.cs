using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceShooter
{
    public static class Constants
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch sb;
        public static ContentManager content;
        public const int MAX_PLAYER_HEALTH = 500;
        public const int MAX_ENEMY_HEALTH = 200;
        public static int LIVES_LEFT = 3;
        public static int PLAYER_SCORE = 0;
        public static int ENEMIES_DEFEATED = 0;
        public static int BOSS_ACTIVATOR = 50;
        public static bool BOSS_ACTIVE = false;
        public static bool BOSS_CREATED = false;
        public static bool BOSS_DEFEATED = false;
        public static int BOSS_STARTING_HEALTH = 1000;
        public static bool GAME_OVER = false;
        public static bool paused = false;
        public static int MAX_X;
        public static int MAX_Y;
        public static int MIN_X;
        public static int MIN_Y;
        public static int MAX_ENEMIES = 50;
        public const float PLAYER_MOVEMENT_SPEED = 2.8f;
        public const float GRAVITY = 9.81f;
        public static Vector2 DEFAULT_POSITION, DEFAULT_PROJECTILE_VELOCITY;
        public static Vector2 DEFAULT_VELOCITY = Vector2.Zero;
        public static Vector2 DEFAULT_ENEMY_VELOCITY = new Vector2(0.0f, 3.0f);
        public static Player player;
        public static AnimationManager mAnimationManager;
        public static ProjectileManager mProjectileManager;
        public static EnemyManager mEnemyManager;
        public static CollisionManager mCollisionManager;
        public static UIManager mUiManager;
        public static ScreenStack mScreenStack;
        public static GameScreen mMainGameScreen;
        public static MenuScreen mMenuScreen;
        public static SplashScreen mSplashScreen, mEndScreenLose, mEndScreenWin;
        public static string pauseString;

        public static void init(ref GraphicsDeviceManager g, ref SpriteBatch s, ContentManager c)
        {
            sb = s;
            content = c;
            graphics = g;
            DEFAULT_POSITION = new Vector2((float)(graphics.PreferredBackBufferWidth / 2)-32, (float)graphics.PreferredBackBufferHeight-100.0f );
            DEFAULT_PROJECTILE_VELOCITY = new Vector2(0.0f, -25.0f);
            mAnimationManager = new AnimationManager(ref sb);
            mProjectileManager = new ProjectileManager(ref sb);
            mEnemyManager = new EnemyManager(ref sb);
            mCollisionManager = new CollisionManager();
            mUiManager = new UIManager("MyFont", ref sb);
            mScreenStack = new ScreenStack();
            pauseString = "PAUSED";
            MAX_X = graphics.PreferredBackBufferWidth - 64;
            MAX_Y = graphics.PreferredBackBufferHeight - 70;
            MIN_X = 32;
            MIN_Y = graphics.PreferredBackBufferHeight - 126;
        }
    }
}
