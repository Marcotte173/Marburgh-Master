using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

public class Sound
{
    public static SoundPlayer sPlayer = new SoundPlayer();
    public static bool sPlay = false;

    public static void PlayOnce(String path)
    {
        sPlayer = new SoundPlayer(Environment.CurrentDirectory + @"\sfx\" + path + ".wav");
        sPlayer.Play();
    }

    public static void Loop(String path)
    {
        sPlayer = new SoundPlayer(Environment.CurrentDirectory + @"\sfx\" + path + ".wav");
        sPlayer.PlayLooping();
        sPlay = true;
    }

    public static void Stop()
    {
        sPlayer.Stop();
        sPlay = false;
    }
}