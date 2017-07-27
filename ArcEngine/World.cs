using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace ArcEngine
{
    class World
    {
        //Form Variables
        static public string WindowTitle = "ArcEngine";
        static public int WindowHeight = 600;
        static public int WindowWidth = 800;
        static public string IconPath = (Core.CoreDirectory + "\\icon.ico");
        static public bool WindowFullscreen = false;

        //Debug
        static public List<string> OffsceenObjects = new List<string>();
        static public bool DebugMarkers = false;
        static public bool DebugMessages = false;
        static public TileObj MarkerTile = new TileObj(Core.CoreDirectory + "\\sprites\\tiles\\cross.png", 100, 1, false);

        //Player
        static public int PlayerSpeed = 1;
        static public int PlayerSprintSpeed = 2;
        //Camera
        static public int CameraX = 0;
        static public int CameraY = 0;
        static public int TileOffsetX = 0;
        static public int TileOffsetY = 0;
        //Set this to the dimensions of the background tile
        static public int TileWidth = 32;
        static public int TileHeight = 32;
        static public void LevelLoader(int level){
            if (level == 1)
            {
                Objects.TileObjList.Add(World.MarkerTile);
                List<SpriteObj> SpriteList = new List<SpriteObj>();
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_left")); //0
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_right"));//1
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_up"));   //2
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_down")); //3
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_left_still")); //4
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_right_still")); //5
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_up_still")); //6
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\char\\char_down_still")); //7
                Objects.CreateCharObj(200.0, 200.0, SpriteList, 10, 100, 10, 1, true, "Player");

                Objects.CreateEffectObj(new SpriteObj(Core.CoreDirectory + "\\sprites\\explosion"), -1, 5, 2, "ExplosionEffect");
                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\shoot"));
                //Objects.CreateCharObj(100.0, 100.0, SpriteList, 10, 10, 4, 1, false);

                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\spaceship"));
                //Objects.CreateCharObj(100.0, 400.0, SpriteList, 10, 64, 4, 1, false);

                SpriteList = new List<SpriteObj>();
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\starship"));
                Objects.CreateCharObj(400.0, 100.0, SpriteList, 10, 96, 4, 1, false, "Starship");

                SpriteList = new List<SpriteObj>();
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\tank"));
                Objects.CreateCharObj(400.0, 250.0, SpriteList, 10, 124, 10, 1, false, "Tank");

                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\rustbug"));
                //Objects.CreateCharObj(300.0, 400.0, SpriteList, 10, 10, 3, 1, false);

                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\warrior_flame"));
                //Objects.CreateCharObj(600, 100.0, SpriteList, 10, 62, 6, 1, false);

                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\mech"));
                //Objects.CreateCharObj(400.0, 400.0, SpriteList, 10, 50, 6, 1, false);

                Objects.CreateTileObj(Core.CoreDirectory + "\\sprites\\tiles\\tile1.png", 5, 1, true);

                List<Point> points = new List<Point>();
                points.Add(new Point(300,200));
                points.Add(new Point(332,232));
                points.Add(new Point(300,232));
                points.Add(new Point(332,200));
                Objects.CreateTileGroup(Core.CoreDirectory + "\\sprites\\tiles\\tile2.png", 4, 1, points);

                //List<Point> points2 = new List<Point>();
                //points2.Add(new Point(0, 0));
                //Objects.CreateTileGroup(Core.CoreDirectory + "\\sprites\\tiles\\blue.png", 4, 1, points2);

                Objects.CreateSolidObj(Core.CoreDirectory + "\\sprites\\tiles\\crate.png", 300, 300, 100, 1, 10.0);

                Objects.CharObjList.Reverse();
            }
        }
    }
}
