using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceShooter
{
    public class EnemyManager
    {
        private List<Enemy> mEnemies;
        private Random rand;
        public SpriteBatch SB { get; set; }
        private int mCount, i;

        public List<Enemy> Enemies
        {
            get
            {
                return mEnemies;
            }
            set
            {
                mEnemies = value;
            }
        }

        public EnemyManager(ref SpriteBatch sb)
        {
            rand = new Random();
            mEnemies = new List<Enemy>();
            mCount = 0;
        }

        public void addEnemy(Enemy e)
        {
            mEnemies.Add(e);
            ++mCount;
        }

        public void removeEnemy(Enemy e)
        {
            mEnemies.Remove(e);
            --mCount;
        }

        public void update()
        {
            for ( i = 0; i < mCount; ++i)
            {
                mEnemies.ElementAt(i).update();
                if (mEnemies.ElementAt(i).MidPoint.Y > Constants.graphics.PreferredBackBufferHeight)
                    mEnemies.ElementAt(i).reset();
                if (mEnemies.ElementAt(i).MidPoint.X <= 0)
                    mEnemies.ElementAt(i).Velocity =
                        new Vector2(-mEnemies.ElementAt(i).Velocity.X, mEnemies.ElementAt(i).Velocity.Y);
                else if (mEnemies.ElementAt(i).MidPoint.X > Constants.graphics.PreferredBackBufferWidth - (mEnemies.ElementAt(i).Texture.width / 1.2))
                    mEnemies.ElementAt(i).Velocity = new Vector2(-mEnemies.ElementAt(i).Velocity.X, mEnemies.ElementAt(i).Velocity.Y); 
            }
        }

        public void draw()
        {
            for ( i = 0; i < mCount; ++i)
            {
                mEnemies.ElementAt(i).draw();
            }
        }
    }
}
