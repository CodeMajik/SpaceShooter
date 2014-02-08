using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    interface IEntityStats
    {
        void draw();
        void update();
        void destroy();
        void reset();
    }

    public class GameEntity: IEntityStats
    {
        protected int mHealth;
        protected bool mAlive;
        public Vector2 mPosition, mVelocity, mMidPoint;
        protected TextureMap mTexture;
        public enum ENTITY_TYPE { PLAYER, AI, PROJECTILE };
        protected ENTITY_TYPE mType;

        public GameEntity(Vector2 position, TextureMap map, ENTITY_TYPE type)
        {
            mPosition = position;
            mVelocity = Vector2.Zero;
            mMidPoint = new Vector2(mPosition.X + map.width / 2, mPosition.Y + map.height / 2);
            mTexture = map;
            mHealth = 50;
            mType = type;
            mAlive = true;
        }

        public GameEntity(Vector2 position, Vector2 velocity, TextureMap map, ENTITY_TYPE type)
        {
            mPosition = position;
            mVelocity = velocity;
            mMidPoint = new Vector2(mPosition.X + map.width / 2, mPosition.Y + map.height / 2);
            mTexture = map;
            mHealth = Constants.MAX_PLAYER_HEALTH;
            mType = type;
            mAlive = true;
        }

        public GameEntity(Vector2 position, Vector2 velocity, TextureMap map, ENTITY_TYPE type, int health = Constants.MAX_PLAYER_HEALTH)
        {
            mPosition = position;
            mVelocity = velocity;
            mMidPoint = new Vector2(mPosition.X + map.width / 2, mPosition.Y + map.height / 2);
            mTexture = map;
            mHealth = health;
            mType = type;
            mAlive = true;
        }

        public ENTITY_TYPE EType
        { get { return mType; } set { mType = value; } }
        public int Health
        { get { return mHealth; } set { mHealth = value; } }
        public bool Alive
        { get { return mAlive; } set { mAlive = value; } }
        public Vector2 Position
        { get { return mPosition; } set { mPosition = value; }}
        public Vector2 MidPoint
        { get { return mMidPoint; } set { mMidPoint = value; } }
        public Vector2 Velocity
        { get { return mVelocity; } set { mVelocity = value; } }
        public TextureMap Texture
        { get { return mTexture; } set { mTexture = value; } }

        public virtual void reset() { }
        public virtual void destroy() { }
        public virtual void update() { }

        public virtual void draw()
        {
            if(mAlive)
                mTexture.Draw(Constants.sb, mPosition);
        }
    }
}
