using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace SpaceShooter
{
    public class SoundManager
    {
        MediaLibrary mMediaLibrary;
        Random r;

        public SoundManager()
        {
            mMediaLibrary = new MediaLibrary();
            r = new Random();
            // play the first track from the album
            MediaPlayer.Play(mMediaLibrary.Albums[r.Next(0, mMediaLibrary.Albums.Count - 1)].Songs[0]);

            //sc = Constants.content.Load<SongCollection>("audio");
            //MediaPlayer.Play(sc);
            //mSounds.Add(Constants.content.Load<Song>("Before my body is dry"));
            //MediaPlayer.Play(mSounds.First());
        }

        public void playNewRandomSound(){
            MediaPlayer.Play(mMediaLibrary.Albums[r.Next(0, mMediaLibrary.Albums.Count - 1)].Songs[0]);
        }

        public void update()
        {

        }
    }
}
