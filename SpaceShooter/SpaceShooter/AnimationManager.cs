using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter
{
    public class AnimationManager
    {
        public SpriteBatch SB { get; set; }
        public List<Animation> Animations { get; set; }
        private int mCount, i;
        //bool paused;

        public AnimationManager(ref SpriteBatch sb)
        {
            SB = sb;
            Animations = new List<Animation>();
            mCount = 0;
            //paused = false;
        }

        public void update(GameTime dt)
        {
            //if(!paused)
            for ( i = 0; i < mCount; ++i)
            {
                Animations.ElementAt(i).Sprite.Update();
                if (Animations.ElementAt(i).Sprite.Done)
                    removeAnimation(Animations.ElementAt(i));
            }
        }

        public void draw()
        {
            for ( i = 0; i < mCount; ++i)
            {
                Animations.ElementAt(i).Sprite.Draw(SB, Animations.ElementAt(i).Location);
            }
        }

        public void addAnimation(Animation animation)
        {
            Animations.Add(animation);
            ++mCount;
        }

        public void removeAnimation(Animation animation)
        {
            Animations.Remove(animation);
            --mCount;
        }
    }
}
