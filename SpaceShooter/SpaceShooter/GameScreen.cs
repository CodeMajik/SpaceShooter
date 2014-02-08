using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class GameScreen: Screen
    {
        public Player PlayerShip { get; set; }
        private Vector2 bg2pos, veltemp;
        private TextureMap enemyMap, laserMap, bossMap;
        private bool pressedPause;
        private int enemyTimer, max_time;
        Random r;

        public GameScreen(ref SpriteBatch sb, ref Player p, TextureMap eMap, 
            TextureMap lMap, TextureMap bMap, params string[] bgNames)
        {
            max_time = 100;
            enemyTimer = 0;
            bg2pos = new Vector2(0.0f, -800.0f);
            SB = sb;
            PlayerShip = p;
            pressedPause = false;
            Backgrounds = new List<TextureMap>();
            DrawableEntities = new List<GameEntity>();
            foreach (string bg in bgNames)
            {
                Backgrounds.Add(new TextureMap(Constants.content.Load<Texture2D>(bg), 1, 1));
            }

            enemyMap = eMap;
            laserMap = lMap;
            bossMap = bMap;

            r = new Random();
            veltemp = Vector2.Zero;
            for (int i = 0; i < 5; ++i)
            {
                veltemp.Y = r.Next(1, 5);
                Constants.mEnemyManager.addEnemy(new Enemy(
                    new Vector2(r.Next(100, Constants.graphics.PreferredBackBufferWidth - 100), 0.0f),
                    veltemp, enemyMap, laserMap, Enemy.ENEMY_TYPE.SIDEWINDER));
            }
        }

        public void checkForEndGame()
        {
            if (Constants.BOSS_DEFEATED)
            {
                Constants.GAME_OVER = true;
                Constants.mScreenStack.push(Constants.mEndScreenWin);
            }
        }

        public override void draw()
        {
            Backgrounds.ElementAt(0).Draw(SB, new Vector2());
            Backgrounds.ElementAt(1).Draw(SB, bg2pos);
            PlayerShip.draw();
            Constants.mAnimationManager.draw();
            Constants.mEnemyManager.draw();
            Constants.mProjectileManager.draw();
        }

        public override void update(GameTime t, KeyboardState k, MouseState m)
        {
            checkForEndGame();
            if (Constants.BOSS_ACTIVE && !Constants.BOSS_CREATED)
            {
                veltemp.Y = 0.3f;
                Constants.mEnemyManager.addEnemy(new Boss(
                       new Vector2(r.Next(200, Constants.graphics.PreferredBackBufferWidth - 200), 0.0f),
                       veltemp, bossMap, laserMap));
                Constants.BOSS_CREATED = true;
            }
            Constants.mAnimationManager.update(t);
            Constants.mProjectileManager.update();
            Constants.mEnemyManager.update();
            Constants.mCollisionManager.update();
            foreach (GameEntity g in DrawableEntities)
            {
                g.update();
            }
            PlayerShip.update();
            PlayerShip.controlShip(k);
            controls(k);
            if (bg2pos.Y < 800)
            {
                bg2pos.Y += 0.3f;
            }
            else
                bg2pos.Y = -800;

            if (!Constants.BOSS_ACTIVE)
            {
                ++enemyTimer;
                if (enemyTimer >= max_time)
                {
                    Constants.mEnemyManager.addEnemy(new Enemy(
                        new Vector2(r.Next(100, Constants.graphics.PreferredBackBufferWidth - 100), 0.0f),
                        veltemp, enemyMap, laserMap, Enemy.ENEMY_TYPE.SIDEWINDER));

                    enemyTimer = 0;
                }
            }    
        }

        public override void destroy()
        {
           
        }

        public override void addEntity(GameEntity e)
        {
            DrawableEntities.Add(e);
        }

        public override void addBackground(TextureMap t)
        {
            Backgrounds.Add(t);
        }

        public override void controls(KeyboardState k)
        {
            if (k.IsKeyDown(Keys.T))
            {
                pressedPause = true;
            }
            if (k.IsKeyUp(Keys.T) && pressedPause)
            {
                Constants.paused ^= Convert.ToBoolean(1);
                pressedPause = false;
            }
        }
    }
}
