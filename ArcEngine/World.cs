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
                Objects.CreateCharObj(200.0, 200.0, SpriteList, 10, 100, 6, 1, true);


                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\shoot"));
                //Objects.CreateCharObj(100.0, 100.0, SpriteList, 10, 10, 4, 1, false);

                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\spaceship"));
                //Objects.CreateCharObj(100.0, 400.0, SpriteList, 10, 64, 4, 1, false);

                SpriteList = new List<SpriteObj>();
                SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\starship"));
                Objects.CreateCharObj(400.0, 100.0, SpriteList, 10, 96, 4, 1, false);

                //SpriteList = new List<SpriteObj>();
                //SpriteList.Add(new SpriteObj(Core.CoreDirectory + "\\sprites\\tank"));
                //Objects.CreateCharObj(400.0, 250.0, SpriteList, 10, 124, 4, 1, false);

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

                Objects.CreateSolidObject(Core.CoreDirectory + "\\sprites\\tiles\\crate.png", 300, 300, 100, 1, 10.0);

                Objects.CharObjList.Reverse();
            }
        }
        static public void PlayerLeft(CharObj PlayerObj, bool sprint)
        {
            if (sprint == true)
            {
                PlayerObj.X-=World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.X -= World.PlayerSpeed;
            }
            if (PlayerObj.CurrentAnimation != 0)
            {
                PlayerObj.CurrentAnimation = 0;
                PlayerObj.ResetFrames();
            }
        }
        static public void PlayerRight(CharObj PlayerObj, bool sprint)
        {
            if (sprint == true)
            {
                PlayerObj.X += World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.X += World.PlayerSpeed;
            }
            if (PlayerObj.CurrentAnimation != 1)
            {
                PlayerObj.CurrentAnimation = 1;
                PlayerObj.ResetFrames();
            }
        }
        static public void PlayerUp(CharObj PlayerObj, bool sprint)
        {
            if (sprint == true)
            {
                PlayerObj.Y -= World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.Y -= World.PlayerSpeed;
            }
            if (PlayerObj.CurrentAnimation != 2)
            {
                PlayerObj.CurrentAnimation = 2;
                PlayerObj.ResetFrames();
            }
        }
        static public void PlayerDown(CharObj PlayerObj, bool sprint)
        {
            if (sprint == true)
            {
                PlayerObj.Y += World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.Y += World.PlayerSpeed;
            }
            if (PlayerObj.CurrentAnimation != 3)
            {
                PlayerObj.CurrentAnimation = 3;
                PlayerObj.ResetFrames();
            }
        }
        static public void PlayerReleaseLeft(CharObj PlayerObj)
        {
            PlayerObj.CurrentAnimation = 4;
            PlayerObj.ResetFrames();
        }
        static public void PlayerReleaseRight(CharObj PlayerObj)
        {
            PlayerObj.CurrentAnimation = 5;
            PlayerObj.ResetFrames();
        }
        static public void PlayerReleaseUp(CharObj PlayerObj)
        {
            PlayerObj.CurrentAnimation = 6;
            PlayerObj.ResetFrames();
        }
        static public void PlayerReleaseDown(CharObj PlayerObj)
        {
            PlayerObj.CurrentAnimation = 7;
            PlayerObj.ResetFrames();
        }
        static public void CameraUpdate()
        {
            foreach (CharObj CharObject in Objects.CharObjList)
            {
                if (CharObject.isPlayer)
                {
                    if (CharObject.X < (World.CameraX + 100))
                    {
                        World.CameraX -= World.PlayerSprintSpeed;
                        World.TileOffsetX -= World.PlayerSprintSpeed;
                        if (Math.Abs(World.TileOffsetX) >= 32){
                            World.TileOffsetX = 0;
                        }
                        //Console.WriteLine("Player Not in Frame - Left");
                    }
                    if (CharObject.X > (World.CameraX + World.WindowWidth - 100))
                    {
                        World.CameraX += World.PlayerSprintSpeed;
                        World.TileOffsetX += World.PlayerSprintSpeed;
                        if (Math.Abs(World.TileOffsetX) >= 32)
                        {
                            World.TileOffsetX = 0;
                        }
                        //Console.WriteLine("Player Not in Frame - Right");
                    }
                    if (CharObject.Y < (World.CameraY + 100))
                    {
                        World.CameraY -= World.PlayerSprintSpeed;
                        World.TileOffsetY -= World.PlayerSprintSpeed;
                        if (Math.Abs(World.TileOffsetY) >= 32)
                        {
                            World.TileOffsetY = 0;
                        }
                        //Console.WriteLine("Player Not in Frame - Top");
                    }
                    if (CharObject.Y > (World.CameraY + World.WindowHeight - 100))
                    {
                        World.CameraY += World.PlayerSprintSpeed;
                        World.TileOffsetY += World.PlayerSprintSpeed;
                        if (Math.Abs(World.TileOffsetY) >= 32)
                        {
                            World.TileOffsetY = 0;
                        }
                        //Console.WriteLine("Player Not in Frame - Bottom");
                    }
                }
            }
        }
    }
}
