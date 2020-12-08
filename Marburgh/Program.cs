using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace MedievalRPG
{
    class Program
    {
        static void Main(string[] args)
        {            
            Color.SetupConsole();
            GameStart.Menu();
        }
    }
}