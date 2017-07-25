using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcEngine
{
    class Core
    {
        static public string CoreDirectory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("LOADING WORLD LEVEL - 1");
                            Console.WriteLine("----------------------------------------------------");
            World.LevelLoader(1);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("INITIALIZING GRAPHICS");
                        Console.WriteLine("----------------------------------------------------");
            Graphics.Start();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("INITIALIZING INPUT");
                        Console.WriteLine("----------------------------------------------------");
            Input.Start();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("PRESS ENTER TO BEGIN LOOP");
            Console.WriteLine("----------------------------------------------------");
            Console.ReadLine();
            Graphics.Loop();
        }
    }
}
