using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceShooter
{
    public class Enemy: GameEntity
    {
        public enum ENEMY_TYPE { SIDEWINDER, REGULAR, BOSS }
        protected Random rand;
        public List<Turret> Gun { get; set; }
        public ENEMY_TYPE Type { get; set; }

        public Enemy(Vector2 position, TextureMap map, TextureMap tMap, ENEMY_TYPE t)
            :base(position, map, ENTITY_TYPE.AI)
        {
            Type = t;
            Gun = new List<Turret>();
            Gun.Add(new Turret((tMap)));
            rand = new Random();
            mVelocity = Constants.DEFAULT_ENEMY_VELOCITY;
        }

        public Enemy(Vector2 position, Vector2 velocity, TextureMap map, TextureMap tMap, ENEMY_TYPE t)
            : base(position, map, ENTITY_TYPE.AI)
        {
            Type = t;
            Gun = new List<Turret>();
            Gun.Add(new Turret((tMap)));
            rand = new Random();
            mVelocity = velocity;
        }

        void doBoids()
        {
            int c = Constants.mEnemyManager.Enemies.Count;
            Vector2 vel = Vector2.Zero;

            for (int j = 0; j < c; ++j)
            {
                if (Constants.mEnemyManager.Enemies.ElementAt(j) != this)
                {
                    if ((Constants.mEnemyManager.Enemies.ElementAt(j).Position - mPosition).Length() < 30.0f)
                        vel.X = vel.X - (Constants.mEnemyManager.Enemies.ElementAt(j).Position.X - mPosition.X);
                }
            }
            mVelocity += (vel/50);
        }

        public override void update()
        {
            if(Type == ENEMY_TYPE.SIDEWINDER)
            doBoids();

            mPosition += mVelocity;
            mMidPoint = new Vector2(mPosition.X + mTexture.width / 2, mPosition.Y + mTexture.height / 2);
            int temp = rand.Next(0, 100);
            if (temp > 80 && temp < 83)
            {
                foreach(Turret t in Gun)
                    t.shoot(new Vector2(mPosition.X + 16, mPosition.Y + 130), -Constants.DEFAULT_PROJECTILE_VELOCITY, Projectile.PROJECTILE_MASK.ENEMY);
            }
        }

        public override void destroy()
        {
            if (mAlive)
            {
                Constants.mAnimationManager.addAnimation(
                    new Animation(new AnimatedSprite(Constants.content.Load<Texture2D>("explosion1"), 1, 10, 60), new Vector2(mPosition.X + 16, mPosition.Y))
                    );
                mAlive = false;
                ++Constants.ENEMIES_DEFEATED;
                if (Constants.ENEMIES_DEFEATED >= Constants.BOSS_ACTIVATOR)
                {
                    Constants.BOSS_ACTIVE = true;
                }
                Constants.mEnemyManager.removeEnemy(this);
            }
        }

        public override void reset()
        {
            mPosition = new Vector2(rand.Next(100, Constants.graphics.PreferredBackBufferWidth - 100), 0.0f);
            mVelocity.Y = rand.Next(1, 5);
            mHealth = Constants.MAX_ENEMY_HEALTH;
        }
    }
}
