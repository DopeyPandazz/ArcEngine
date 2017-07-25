using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;
namespace ArcEngine
{
    class SpriteObj
    {
        public List<string> SpriteList { get; set; }
        public List<Texture> TextureList { get; set; }
        public int Speed { get; set; }
        public Boolean Loaded { get; set; }
        public int Frames { get; set; }
        public int CurrentFrame { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public SpriteObj(List<string> spritepaths)
        {
            TextureList = new List<Texture>();
            SpriteList = spritepaths;
            Speed = 10;
            Loaded = false;
            Frames = spritepaths.Count;
            CurrentFrame = 0;
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(spritepaths[1]);
            Width = bit.Width;
            Height = bit.Height;
        }
        public SpriteObj(string folderpath)
        {
            TextureList = new List<Texture>();
            SpriteList = new List<string>();
            foreach (string path in Directory.GetFiles(folderpath))
            {
                if (path.EndsWith("png", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    SpriteList.Add(path);
                }
            }
            if (SpriteList.Count == 0)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("Did not find any png files in folder[" + folderpath.Replace(Core.CoreDirectory, "") + "]. Breaking...");
                Console.ReadLine();
                Debugger.Break();
                //The program has stopped, a folder for a spriteobj inizilization is empty.
                Environment.Exit(2);
            }
            else
            {
                Console.WriteLine("Sprite Object Initialzed[" + SpriteList.Count.ToString() + "]: " + folderpath.Replace(Core.CoreDirectory, ""));
            }
            Speed = 10;
            Loaded = false;
            Frames = SpriteList.Count;
            CurrentFrame = 0;
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(SpriteList[0]);
            Width = bit.Width;
            Height = bit.Height;
        }
        public SpriteObj(List<string> spritepaths, int speed)
        {
            TextureList = new List<Texture>();
            SpriteList = spritepaths;
            Speed = speed;
            Loaded = false;
            Frames = spritepaths.Count;
            CurrentFrame = 0;
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(spritepaths[1]);
            Width = bit.Width;
            Height = bit.Height;
        }
        public SpriteObj(string folderpath, int speed)
        {
            TextureList = new List<Texture>();
            SpriteList = new List<string>();
            Console.WriteLine("Sprite Object Initialzing From Folder : " + folderpath.Replace(Core.CoreDirectory, ""));
            foreach (string path in Directory.GetFiles(folderpath)){
                if(path.EndsWith("png", true, System.Globalization.CultureInfo.CurrentCulture)){
                SpriteList.Add(path);
                }
            }
            if (SpriteList.Count == 0)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("Did not find any png files in folder. Breaking...");
                Console.ReadLine();
                Debugger.Break();
                //The program has stopped, a folder for a spriteobj inizilization is empty.
                Environment.Exit(2);
            }
            else
            {
                Console.WriteLine("Sprite Object Initialzed. Found " + SpriteList.Count.ToString() + " Files");
            }
            Speed = speed;
            Loaded = false;
            Frames = SpriteList.Count;
            CurrentFrame = 0;
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(SpriteList[0]);
            Width = bit.Width;
            Height = bit.Height;
        }
        public SpriteObj(List<string> spritepaths, int speed, int width, int height)
        {
            TextureList = new List<Texture>();
            SpriteList = spritepaths;
            Speed = speed;
            Loaded = false;
            Frames = spritepaths.Count;
            CurrentFrame = 0;
            Width = width;
            Height = height;
        }
        public SpriteObj(string folderpath, int speed, int width, int height)
        {
            TextureList = new List<Texture>();
            SpriteList = new List<string>();
            Console.WriteLine("Sprite Object Initialzing From Folder : " + folderpath.Replace(Core.CoreDirectory, ""));
            foreach (string path in Directory.GetFiles(folderpath))
            {
                if (path.EndsWith("png", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    SpriteList.Add(path);
                }
            }
            if (SpriteList.Count == 0)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("Did not find any png files in folder. Breaking...");
                Console.ReadLine();
                Debugger.Break();
                //The program has stopped, a folder for a spriteobj inizilization is empty.
                Environment.Exit(2);
            }
            else
            {
                Console.WriteLine("Sprite Object Initialzed. Found " + SpriteList.Count.ToString() + " Files");
            }
            Speed = speed;
            Loaded = false;
            Frames = SpriteList.Count;
            CurrentFrame = 0;
            Width = width;
            Height = height;
        }
    }
    class CharObj
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Depth { get; set; }
        public int Speed { get; set; }
        public int Scale { get; set; }
        public bool isPlayer { get; set; }
        public int CurrentAnimation { get; set; }
        public List<SpriteObj> AnimationList { get; set; }
        public PhysObj PhysicsObject { get; set; }
        public string ID { get; set; }
        public void ResetFrames()
        {
            foreach (SpriteObj SpriteObject in AnimationList)
            {
                SpriteObject.CurrentFrame = 0;
            }
        }
        public CharObj(double x, double y, List<SpriteObj> animationlist, PhysObj physicsobject, int depth, int speed, int scale, bool isplayer)
        {
            X = x;
            Y = y;
            AnimationList = animationlist;
            PhysicsObject = physicsobject;
            PhysicsObject.X = (float)x;
            PhysicsObject.Y = (float)y;
            isPlayer = isplayer;
            Scale = scale;
            Speed = speed;
            Depth = depth;
            ID = Objects.GetID();
            CurrentAnimation = 0;
        }
        public CharObj(double x, double y, List<SpriteObj> animationlist, double mass, int depth, int speed, int scale, bool isplayer)
        {
            X = x;
            Y = y;
            AnimationList = animationlist;
            PhysicsObject = new PhysObj((float)X, (float)Y, 0.0, 0.0, 10, mass, true);
            isPlayer = isplayer;
            ID = Objects.GetID();
            CurrentAnimation = 0;
        }
    }
    class TileObj
    {
        public string SpritePath { get; set; }
        public string ID { get; set; }
        public int Depth { get; set; }
        public int Scale { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool isBackground { get; set; }
        public Texture TileTexture { get; set; }
        public TileObj(string spritepath, int depth, int scale , bool isbackground)
        {
            Depth = depth;
            SpritePath = spritepath;
            isBackground = isbackground;
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(spritepath);
            Width = bit.Width;
            Height = bit.Height;
            ID = Objects.GetID();
            Scale = scale;
        }
    }
    class TileGroup
    {
        public List<Point> PointList { get; set; }
        public TileObj Tile { get; set; }
        public TileGroup(TileObj TileObject, List<Point> pointlist)
        {
            PointList = pointlist;
            Tile = TileObject;
        }
    }
    class SolidObj
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Depth { get; set; }
        public int Scale { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Texture SpriteTexture { get; set; }
        public string SpritePath { get; set; }
        public PhysObj PhysicsObject { get; set; }
        public string ID { get; set; }
        public SolidObj(double x, double y, string spritepath, PhysObj physicsobject, int depth, int scale)
        {
            X = x;
            Y = y;
            PhysicsObject = physicsobject;
            PhysicsObject.X = (float)x;
            PhysicsObject.Y = (float)y;
            SpritePath = spritepath;
            Scale = scale;
            Depth = depth;
            ID = Objects.GetID();
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(spritepath);
            Width = bit.Width;
            Height = bit.Height;
        }
        public SolidObj(double x, double y, string spritepath, double mass, int depth, int scale)
        {
            X = x;
            Y = y;
            Depth = depth;
            Scale = scale;
            SpritePath = spritepath;
            PhysicsObject = new PhysObj((float)X, (float)Y, 0.0, 0.0, 10, mass, true);
            ID = Objects.GetID();
            System.Drawing.Bitmap bit = new System.Drawing.Bitmap(spritepath);
            Width = bit.Width;
            Height = bit.Height;
        }
    }
    class Objects
    {
        static public List<CharObj> CharObjList = new List<CharObj>();
        static public List<TileGroup> TileGroupList = new List<TileGroup>();
        static public List<TileObj> TileObjList = new List<TileObj>();
        static public List<SolidObj> SolidObjList = new List<SolidObj>();
        static public List<string> ObjIDList;
        static public int CharLoadCount = 0;
        static public int TileLoadCount = 0;
        static public int SpriteLoadCount = 0;
        static public int SolidLoadCount = 0;
        static public int RandomCount = 0;
        static public string RandomString(int size, bool lowerCase, int seed)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random(seed);
            char ch;
            int chint;
            for (int i = 0; i < size; i++)
            {
                chint = Convert.ToInt32(Math.Floor(74 * random.NextDouble()) + 48);
                if (chint == 96) { chint++; }
                if (chint == 59) { chint++; }
                ch = Convert.ToChar(chint);
                builder.Append(ch);
            }
            return builder.ToString();
        }
        static public string GetID()
        {
            string ID = Objects.RandomString(20, false, Objects.RandomCount);
            Console.WriteLine("Initialized Object : " + ID);
            Objects.RandomCount++;
            if (Objects.RandomCount == 1000)
            {
                Objects.RandomCount = 1;
            }
            return ID;
        }
        static public void CharObjUpdate(CharObj CharObject)
        {
            CharObject.PhysicsObject.X = (float)CharObject.X;
            CharObject.PhysicsObject.Y = (float)CharObject.Y;
        }
        static public void CreateCharObj(double x, double y, List<SpriteObj> animationlist, PhysObj physicsobject, int depth, int speed, int scale, bool isplayer)
        {
            CharObj CharObject = new CharObj(x, y, animationlist, physicsobject, depth, speed, scale, isplayer);
            Objects.CharObjList.Add(CharObject);
            foreach (SpriteObj spriteobject in animationlist) {
                spriteobject.Speed = speed;
            }
        }
        static public void CreateCharObj(double x, double y, List<SpriteObj> animationlist, int mass, int depth, int speed, int scale, bool isplayer)
        {
            CharObj CharObject = new CharObj(x, y, animationlist, mass, depth, speed, scale, isplayer);
            Objects.CharObjList.Add(CharObject);
            foreach (SpriteObj spriteobject in animationlist)
            {
                spriteobject.Speed = speed;
            }
            if (CharObject.isPlayer)
            {
                CharObject.CurrentAnimation = 4;
            }
        }
        static public void CreateTileObj(string spritepath, int depth, int scale)
        {
            TileObj TileObject = new TileObj(spritepath, depth, scale, false);
            Objects.TileObjList.Add(TileObject);
        }
        static public void CreateTileObj(string spritepath, int depth, int scale, bool isbackground)
        {
            TileObj TileObject = new TileObj(spritepath, depth, scale, isbackground);
            Objects.TileObjList.Add(TileObject);
            //Objects.TileObjList = Objects.TileObjList.OrderBy(TileObj => TileObj.Depth).ToList();
        }
        static public void CreateTileGroup(string spritepath, int depth, int scale, List<Point> xypointlist)
        {
            TileObj TileObject = new TileObj(spritepath, depth, scale, false);
            TileGroup Tile_Group = new TileGroup(TileObject, xypointlist);
            Objects.TileGroupList.Add(Tile_Group);
            //Objects.TileGroupList = Objects.TileGroupList.OrderBy(TileGroupList => TileGroupList.Tile.Depth).ToList();
        }
        static public void CreateSolidObject( string spritepath, double x, double y, int depth, int scale, double mass)
        {
            SolidObj SolidObject = new SolidObj(x, y, spritepath, new PhysObj((float)y, (float)x, 0.0, 0.0, 10, mass, true), depth, scale);
            Objects.SolidObjList.Add(SolidObject);
        }
        static public void CreateSolidObject( string spritepath, double x, double y, PhysObj PhysObject, int depth, int scale)
        {
            SolidObj SolidObject = new SolidObj(x, y, spritepath, PhysObject, depth, scale);
            Objects.SolidObjList.Add(SolidObject);
        }
    }
}
