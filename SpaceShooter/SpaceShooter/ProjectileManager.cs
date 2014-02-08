using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    public class ProjectileManager
    {
        private List<Projectile> mProjectiles;
        public SpriteBatch SB { get; set; }
        private int mCount, i;

        public List<Projectile> Projectiles
        {
            get
            {
                return mProjectiles;
            }
            set
            {
                mProjectiles = value;
            }
        }

        public ProjectileManager(ref SpriteBatch sb)
        {
            mProjectiles = new List<Projectile>();
            mCount = 0;
        }

        public void addProjectile(Projectile p)
        {
            mProjectiles.Add(p);
            ++mCount;
        }

        public void removeProjectile(Projectile p)
        {
            mProjectiles.Remove(p);
            --mCount;
        }

        public void update()
        {
            for ( i = 0; i < mCount; ++i)
            {
                mProjectiles.ElementAt(i).update();
            }
        }

        public void draw()
        {
            for ( i = 0; i < mCount; ++i)
            {
                mProjectiles.ElementAt(i).draw();
            }
        }
    }
}
