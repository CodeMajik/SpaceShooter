using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShooter
{
    public class CollisionManager
    {
        public CollisionManager()
        {

        }

        public void update()
        {
            double dist = 0.0;
            for (int i = 0; i < Constants.mProjectileManager.Projectiles.Count; i++)
            {
                if (Constants.mProjectileManager.Projectiles.ElementAt(i).Mask == Projectile.PROJECTILE_MASK.PLAYER)
                {
                    for (int j = 0; j < Constants.mEnemyManager.Enemies.Count; j++)
                    {
                        dist = ((Constants.mProjectileManager.Projectiles.ElementAt(i).MidPoint -
                            Constants.mEnemyManager.Enemies.ElementAt(j).MidPoint).Length());
                        if (dist < 20.0)
                        {
                            Constants.mProjectileManager.Projectiles.ElementAt(i).destroy();
                            Constants.PLAYER_SCORE += (100 * ((int)Constants.mEnemyManager.Enemies.ElementAt(j).Type + 1));
                            Constants.mEnemyManager.Enemies.ElementAt(j).Health -= 100;
                            if (Constants.mEnemyManager.Enemies.ElementAt(j).Health<=0)
                                Constants.mEnemyManager.Enemies.ElementAt(j).destroy();
                            
                            break;
                        }
                    }
                }
                else if (Constants.mProjectileManager.Projectiles.ElementAt(i).Mask == Projectile.PROJECTILE_MASK.ENEMY)
                {
                    dist = ((Constants.mProjectileManager.Projectiles.ElementAt(i).MidPoint -
                           Constants.player.MidPoint).Length());
                    if (dist < 10.0)
                    {
                        Constants.player.Health -= 100;
                        Constants.mProjectileManager.Projectiles.ElementAt(i).destroy();
                        if(Constants.player.Health<=0)
                            Constants.player.destroy();

                        break;
                    }
                }
            }
        }
    }
}
