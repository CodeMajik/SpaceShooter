using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    public class Projectile: GameEntity
    {
        public enum PROJECTILE_MASK { ENEMY, PLAYER }
        public PROJECTILE_MASK Mask { get; set; }
        Vector2 mInitPosition;
        int mLife;

        public Projectile(Vector2 position, TextureMap map, PROJECTILE_MASK mask)
            : base(position, map, ENTITY_TYPE.PROJECTILE) 
        {
            Mask = mask;
            mInitPosition = position;
            mVelocity = Constants.DEFAULT_PROJECTILE_VELOCITY;
            mLife = 150;
        }

        public Projectile(Vector2 position, TextureMap map, int life, PROJECTILE_MASK mask)
            : base(position, map, ENTITY_TYPE.PROJECTILE)
        {
            Mask = mask;
            mInitPosition = position;
            mVelocity = Constants.DEFAULT_PROJECTILE_VELOCITY;
            mLife = life;
        }

        public Projectile(Vector2 position, TextureMap map, int life, Vector2 vel, PROJECTILE_MASK mask)
            : base(position, map, ENTITY_TYPE.PROJECTILE)
        {
            Mask = mask;
            mInitPosition = position;
            mVelocity = vel;
            mLife = life;
        }

        public Projectile(Vector2 position, TextureMap map, Vector2 vel, PROJECTILE_MASK mask)
            : base(position, map, ENTITY_TYPE.PROJECTILE)
        {
            Mask = mask;
            mInitPosition = position;
            mVelocity = vel;
            mLife = 150;
        }

        public override void update()
        {
            if (mAlive)
            {
                mPosition += mVelocity;
                mMidPoint = new Vector2(mPosition.X + mTexture.width / 2, mPosition.Y + mTexture.height / 2);
                if ((mPosition - mInitPosition).Length() > mLife)
                {
                    this.destroy();
                }
            }
        }

        public override void destroy()
        {
            if (mAlive)
            {
                Constants.mAnimationManager.addAnimation(
                    new Animation(new AnimatedSprite(Constants.content.Load<Texture2D>("laserburn1"), 1, 1, 60), new Vector2(mPosition.X - 16, mPosition.Y))
                    );
                mAlive = false;
                Constants.mProjectileManager.removeProjectile(this);
            }
        }

        public override void reset()
        {
           //nope
        }
    }
}
