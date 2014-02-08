using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    public class ScreenStack
    {
        public List<Screen> Screens { get; set; }
        public Screen mActiveScreen;
        public int ScreenCount { get; set; }

        public ScreenStack()
        {
            Screens = new List<Screen>();
            ScreenCount = 0;
            mActiveScreen = null;
        }

        public void push(Screen scr)
        {
            Screens.Add(scr);
            ++ScreenCount;
            mActiveScreen = Screens.ElementAt(ScreenCount-1);
        }

        public void pop()
        {
            Screens.Remove(Screens.Last());
            --ScreenCount;
            if(ScreenCount>0) 
                mActiveScreen = Screens.ElementAt(ScreenCount-1);
        }

        public void update(GameTime t, KeyboardState k, MouseState m)
        {
            mActiveScreen.update(t, k, m);
        }

        public void draw()
        {
            mActiveScreen.draw();
            Constants.mUiManager.draw();
        }
    }
}
