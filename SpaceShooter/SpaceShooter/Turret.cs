using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceShooter
{
    public class Turret
    {
        TextureMap TMap { get; set; }

        public Turret(TextureMap tMap)
        {
            TMap = tMap;
        }

        public void shoot(Vector2 pos, Projectile.PROJECTILE_MASK mask)
        {
            Constants.mProjectileManager.addProjectile(new Projectile(pos, TMap, mask));
        }

        public void shoot(Vector2 pos, Vector2 vel, Projectile.PROJECTILE_MASK mask)
        {
            Constants.mProjectileManager.addProjectile(new Projectile(pos, TMap, vel, mask));
        }

        public void shoot(Vector2 pos, Vector2 vel, Projectile.PROJECTILE_MASK mask, int life)
        {
            Constants.mProjectileManager.addProjectile(new Projectile(pos, TMap, life, vel, mask));
        }
    }
}
