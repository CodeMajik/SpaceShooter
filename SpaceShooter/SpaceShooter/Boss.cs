using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceShooter
{
    public class Boss: Enemy
    {
        private List<Vector2> turretPosList;
        private bool sideways_movement;
        public Boss(Vector2 position, Vector2 velocity, TextureMap map, TextureMap tMap)
            :base(position, velocity, map, tMap, ENEMY_TYPE.BOSS)
        {
            Health = Constants.BOSS_STARTING_HEALTH;
            turretPosList = new List<Vector2>();
            sideways_movement = false;
            Vector2 posTemp = MidPoint;
            turretPosList.Add(posTemp);
            posTemp = new Vector2(MidPoint.X - mTexture.width / 5, MidPoint.Y);
            turretPosList.Add(posTemp);
            posTemp = new Vector2(MidPoint.X + mTexture.width / 5, MidPoint.Y);
            turretPosList.Add(posTemp);
            posTemp = new Vector2(MidPoint.X - mTexture.width / 3f, MidPoint.Y + mTexture.height / 14.5f);
            turretPosList.Add(posTemp);
            posTemp = new Vector2(MidPoint.X + mTexture.width / 3f, MidPoint.Y + mTexture.height / 14.5f);
            turretPosList.Add(posTemp);
            for (int i = 0; i < 4; ++i)
            {
                Gun.Add(new Turret(tMap));
            }
        }

        public override void update()
        {
            if (mPosition.Y > Constants.graphics.PreferredBackBufferHeight / 9&&!sideways_movement)
            {
                mVelocity.Y = 0.0f;
                mVelocity.X = -6.0f;
                sideways_movement = true;
            }
            mPosition += mVelocity;
            for (int j = 0; j < turretPosList.Count; ++j)
            {
                turretPosList[j] = new Vector2(turretPosList.ElementAt(j).X + mVelocity.X, turretPosList.ElementAt(j).Y + mVelocity.Y);
            }
            mMidPoint = new Vector2(mPosition.X + mTexture.width / 2, mPosition.Y + mTexture.height / 2);

            int temp = rand.Next(0, 100);
            if (temp > 80 && temp < 85)
                for (int i=0;i<Gun.Count;++i)
                    Gun.ElementAt(i).shoot(turretPosList.ElementAt(i), -Constants.DEFAULT_PROJECTILE_VELOCITY, Projectile.PROJECTILE_MASK.ENEMY, 300);
        }

        public override void destroy()
        {
            if (mAlive)
            {
                Constants.mAnimationManager.addAnimation(
                    new Animation(new AnimatedSprite(Constants.content.Load<Texture2D>("explosionBoss"), 1, 12, 60), mMidPoint));
                mAlive = false;
                Constants.BOSS_DEFEATED = true;
                Constants.mEnemyManager.removeEnemy(this);
            }
        }

        public override void reset()
        {
            //nope
        }
    }
}
