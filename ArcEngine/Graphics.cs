using System;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Direct2D;
using SlimDX.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
namespace ArcEngine
{
    class Graphics
    {
        static public RenderForm form;
        static public Stopwatch stopwatch;
        static public Sprite sprite;
        static public Device device;
        static public void Start()
        {
            Graphics.InitForm();
            Graphics.InitDevice();
            Graphics.InitObjIDList();
            Graphics.InitCharObjects();
            Graphics.InitSolidObjects();
            Graphics.InitTileObjects();
            Graphics.InitTileGroupObjects();
        }
        static public void InitForm()
        {
            Graphics.form = new RenderForm(World.WindowTitle);
            Graphics.form.MinimumSize = Graphics.form.ClientSize;
            Graphics.form.Icon = new Icon(World.IconPath);
            if (World.WindowFullscreen == false)
            {
                Graphics.form.ClientSize = new Size(World.WindowWidth, World.WindowHeight);
            }
            else
            {
                Graphics.form.ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
            
        }
        static public void InitDevice()
        {
            Graphics.device = new Device(new Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters()
            {
                BackBufferWidth = form.ClientSize.Width,
                BackBufferHeight = form.ClientSize.Height,
                Windowed = true,
                EnableAutoDepthStencil = true,
                AutoDepthStencilFormat = Format.D16,
                BackBufferFormat = Format.A8R8G8B8

            });
            if (World.WindowFullscreen == true)
            {
                Graphics.device = new Device(new Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters()
                {
                    BackBufferWidth = form.ClientSize.Width,
                    BackBufferHeight = form.ClientSize.Height,
                    Windowed = false
                });
            }
        }
        static public void InitObjIDList()
        {
            Objects.ObjIDList = new List<string>();
        }
        static public void InitCharObjects()
        {
            foreach (CharObj CharObject in Objects.CharObjList)
            {
                Objects.ObjIDList.Add(CharObject.ID);
                Console.WriteLine("Loading Sprites of Char Object : " + CharObject.ID);
                foreach (SpriteObj SpriteObject in CharObject.AnimationList)
                {
                    foreach (string SpritePath in SpriteObject.SpriteList)
                    {
                        int imgx = SpriteObject.Width * CharObject.Scale;
                        int imgy = SpriteObject.Height * CharObject.Scale;
                        SpriteObject.TextureList.Add(Texture.FromFile(device, SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1));
                        Objects.SpriteLoadCount++;
                    }
                    SpriteObject.Loaded = true;
                }
                Objects.CharLoadCount++;
                
            }
        }
        static public void InitTileObjects()
        {
            foreach (TileObj TileObject in Objects.TileObjList)
            {
                Console.WriteLine("Loading Sprites of Tile Object : " + TileObject.ID);
                int imgx = TileObject.Width * TileObject.Scale;
                int imgy = TileObject.Height * TileObject.Scale;
                TileObject.TileTexture = Texture.FromFile(device, TileObject.SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1);
                Objects.TileLoadCount++;

            }
        }
        static public void InitTileGroupObjects()
        {
            foreach (TileGroup Tile_Group in Objects.TileGroupList)
            {
                Console.WriteLine("Loading Sprites of Tile Group Object : " + Tile_Group.Tile.ID);
                int imgx = Tile_Group.Tile.Width * Tile_Group.Tile.Scale;
                int imgy = Tile_Group.Tile.Height * Tile_Group.Tile.Scale;
                Tile_Group.Tile.TileTexture = Texture.FromFile(device, Tile_Group.Tile.SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1);
                Objects.ObjIDList.Add(Tile_Group.Tile.ID);
            }
        }
        static public void InitSolidObjects()
        {
            foreach (SolidObj SolidObject in Objects.SolidObjList)
            {
                Console.WriteLine("Loading Sprites of Solid Object : " + SolidObject.ID);
                int imgx = SolidObject.Width * SolidObject.Scale;
                int imgy = SolidObject.Height * SolidObject.Scale;
                SolidObject.SpriteTexture = Texture.FromFile(device, SolidObject.SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1);
                Objects.ObjIDList.Add(SolidObject.ID);
                Objects.SolidLoadCount++;
            }
        }
        public static void CheckNewObjects(){
            if (Objects.CharObjList.Count != Objects.CharLoadCount)
            {
                foreach (CharObj CharObject in Objects.CharObjList)
                {
                    if (Objects.ObjIDList.Contains(CharObject.ID) == false)
                    {
                        Console.WriteLine("Loading Sprites of New Object : " + CharObject.ID);
                        foreach (SpriteObj SpriteObject in CharObject.AnimationList)
                        {
                            Console.WriteLine("Width: " + SpriteObject.Width.ToString() + ", Height: " + SpriteObject.Height.ToString());
                            foreach (string SpritePath in SpriteObject.SpriteList)
                            {
                                int imgx = SpriteObject.Width * CharObject.Scale;
                                int imgy = SpriteObject.Height * CharObject.Scale;
                                SpriteObject.TextureList.Add(Texture.FromFile(device, SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1));
                            }
                        }
                    }
                }

            }
                foreach (TileObj TileObject in Objects.TileObjList)
                {
                    if (Objects.ObjIDList.Contains(TileObject.ID) == false)
                    {
                        int imgx = TileObject.Width * TileObject.Scale;
                        int imgy = TileObject.Height * TileObject.Scale;
                        TileObject.TileTexture = Texture.FromFile(device, TileObject.SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1);
                        Objects.ObjIDList.Add(TileObject.ID);
                    }
                }

                foreach (TileGroup Tile_Group in Objects.TileGroupList)
                {
                    if (Objects.ObjIDList.Contains(Tile_Group.Tile.ID) == false)
                    {
                        int imgx = Tile_Group.Tile.Width * Tile_Group.Tile.Scale;
                        int imgy = Tile_Group.Tile.Height * Tile_Group.Tile.Scale;
                        Tile_Group.Tile.TileTexture = Texture.FromFile(device, Tile_Group.Tile.SpritePath, imgx, imgy, 1, SlimDX.Direct3D9.Usage.None, SlimDX.Direct3D9.Format.A8B8G8R8, SlimDX.Direct3D9.Pool.Default, SlimDX.Direct3D9.Filter.Point, SlimDX.Direct3D9.Filter.Point, 1);
                        Objects.ObjIDList.Add(Tile_Group.Tile.ID);
                    }
                }
            
        }
        static public void DrawCharObjects()
        {
            foreach (CharObj CharObject in Objects.CharObjList)
            {
                if (CharObject.X > (World.CameraX - (CharObject.AnimationList[0].Width * 2)) & CharObject.X < (World.CameraX + World.WindowWidth + (CharObject.AnimationList[0].Width * 2)) & CharObject.Y > (World.CameraY - (CharObject.AnimationList[0].Height * 2)) & CharObject.Y < (World.CameraY + World.WindowHeight + (CharObject.AnimationList[0].Height * 2)))
                {
                    //Remove from OffscreenObjects
                    if (World.OffsceenObjects.Contains(CharObject.ID))
                    {
                        World.OffsceenObjects.Remove(CharObject.ID);
                    }
                    //Set the Physic Coordinates to the CharObj Coordinates
                    Objects.CharObjUpdate(CharObject);
                    sprite.Begin(SlimDX.Direct3D9.SpriteFlags.SortDepthBackToFront | SlimDX.Direct3D9.SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);
                    if (CharObject.AnimationList[CharObject.CurrentAnimation].TextureList.Count == 1)
                    {
                        //If the animation has 1 frame and therefore doesent need a frame counter, just draw the one frame
                        sprite.Draw(CharObject.AnimationList[CharObject.CurrentAnimation].TextureList[0], new Vector3(0, 0, 0), new Vector3(CharObject.PhysicsObject.X - World.CameraX, CharObject.PhysicsObject.Y - World.CameraY, 0), new Color4(1.0f, 1.0f, 1.0f));
                    }
                    else
                    {
                        //Set the animation frame taking into account the CharObj.Speed
                        int AnimationFrame = (int)Math.Round((double)(CharObject.AnimationList[CharObject.CurrentAnimation].CurrentFrame * CharObject.AnimationList[CharObject.CurrentAnimation].Frames) / (CharObject.AnimationList[CharObject.CurrentAnimation].Speed * CharObject.AnimationList[CharObject.CurrentAnimation].Frames), 0);
                        //Draw
                        sprite.Draw(CharObject.AnimationList[CharObject.CurrentAnimation].TextureList[AnimationFrame], new Vector3(0, 0, 0), new Vector3(CharObject.PhysicsObject.X - World.CameraX, CharObject.PhysicsObject.Y - World.CameraY, (float)CharObject.Depth / 100), new Color4(1.0f, 1.0f, 1.0f));
                        //Advance Current Frame
                        CharObject.AnimationList[CharObject.CurrentAnimation].CurrentFrame++;
                        //If at Max Frame(CharObj.Frames), reset Frame Counter(CurrentFrame) to 0
                        if ((int)Math.Round((double)(CharObject.AnimationList[CharObject.CurrentAnimation].CurrentFrame * CharObject.AnimationList[CharObject.CurrentAnimation].Frames) / (CharObject.AnimationList[CharObject.CurrentAnimation].Speed * CharObject.AnimationList[CharObject.CurrentAnimation].Frames), 0) == CharObject.AnimationList[CharObject.CurrentAnimation].Frames)
                        {
                            CharObject.AnimationList[CharObject.CurrentAnimation].CurrentFrame = 0;
                        }
                    }
                    sprite.End();
                }
                else
                {
                    if (!World.OffsceenObjects.Contains(CharObject.ID))
                    {
                        World.OffsceenObjects.Add(CharObject.ID);
                    }
                }
            }
        }
        static public void DrawSolidObjects()
        {
            //Console.WriteLine("Offscreen Objects: " + World.OffsceenObjects.Count.ToString());
            foreach (SolidObj SolidObject in Objects.SolidObjList)
            {
                if (SolidObject.X > (World.CameraX - (SolidObject.Width * 2)) & SolidObject.X < (World.CameraX + World.WindowWidth + (SolidObject.Width * 2)) & SolidObject.Y > (World.CameraY - (SolidObject.Height * 2)) & SolidObject.Y < (World.CameraY + World.WindowHeight + (SolidObject.Height * 2)))
                {
                    if (World.OffsceenObjects.Contains(SolidObject.ID))
                    {
                        World.OffsceenObjects.Remove(SolidObject.ID);
                    }
                    sprite.Begin(SlimDX.Direct3D9.SpriteFlags.SortDepthBackToFront | SlimDX.Direct3D9.SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);
                    sprite.Draw(SolidObject.SpriteTexture, new Vector3(0, 0, 0), new Vector3((float)SolidObject.X - World.CameraX, (float)SolidObject.Y - World.CameraY, 0), new Color4(1.0f, 1.0f, 1.0f));
                    sprite.End();
                }
                else
                {
                    if (!World.OffsceenObjects.Contains(SolidObject.ID))
                    {
                        World.OffsceenObjects.Add(SolidObject.ID);
                    }
                    //Console.WriteLine("SolidObject out of frame");
                }
            }
        }
        static public void DrawTileObjects()
        {
            foreach (TileObj TileObject in Objects.TileObjList)
            {
                sprite.Begin(SlimDX.Direct3D9.SpriteFlags.SortDepthBackToFront | SlimDX.Direct3D9.SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);
                if (TileObject.isBackground)
                {
                    int x = World.CameraX - World.TileWidth;
                    int y = World.CameraY - World.TileHeight;
                    while (x < World.CameraX + Graphics.form.ClientSize.Width + World.TileWidth)
                    {
                        while (y < World.CameraY + Graphics.form.ClientSize.Height + World.TileHeight)
                        {

                            sprite.Draw(TileObject.TileTexture, new Vector3(0, 0, 0), new Vector3(x - World.CameraX - World.TileOffsetX, y - World.CameraY - World.TileOffsetY, 0), new Color4(1.0f, 1.0f, 1.0f));
                            y += TileObject.Height;
                    }
                        y = World.CameraY - World.TileHeight;
                        x += TileObject.Width;
                    }
                }
                sprite.End();
            }
            foreach (TileGroup Tile_Group in Objects.TileGroupList)
            {
                sprite.Begin(SlimDX.Direct3D9.SpriteFlags.SortDepthBackToFront | SlimDX.Direct3D9.SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);
                foreach (Point point in Tile_Group.PointList)
                {
                    if (point.X > (World.CameraX - (Tile_Group.Tile.Width * 2)) & point.X < (World.CameraX + World.WindowWidth + (Tile_Group.Tile.Width * 2)) & point.Y > (World.CameraY - (Tile_Group.Tile.Height * 2)) & point.Y < (World.CameraY + World.WindowHeight + (Tile_Group.Tile.Height * 2)))
                    {
                        sprite.Draw(Tile_Group.Tile.TileTexture, new Vector3(0, 0, 0), new Vector3(point.X - World.CameraX, point.Y - World.CameraY, 0), new Color4(1.0f, 1.0f, 1.0f));
                    }
                    else
                    {
                        //Console.WriteLine("TileGroup point out of frame");
                    }
                } 
            }
            sprite.End();
        }
        static public void DrawDebugMarkers()
        {
            if (World.DebugMarkers)
            {
                sprite.Begin(SlimDX.Direct3D9.SpriteFlags.SortDepthBackToFront | SlimDX.Direct3D9.SpriteFlags.AlphaBlend | SpriteFlags.SortTexture);
                foreach (CharObj CharObject in Objects.CharObjList)
                {
                    sprite.Draw(World.MarkerTile.TileTexture, new Vector3(0, 0, 0), new Vector3((CharObject.PhysicsObject.X + (CharObject.AnimationList[CharObject.CurrentAnimation].Width / 2)), (CharObject.PhysicsObject.Y + (CharObject.AnimationList[CharObject.CurrentAnimation].Height) / 2), (float)CharObject.Depth + 50 / 100), new Color4(1.0f, 1.0f, 1.0f));
                }
                sprite.End();
            }
        }
        public static void Timer(bool start){
            if (start == true)
            {
                stopwatch = Stopwatch.StartNew();
            } else {
                stopwatch.Stop();
                int ms = 10 - (int)(stopwatch.ElapsedMilliseconds);
                if (ms > 0)
                {
                    Thread.Sleep(ms);
                }
            }

        }
        static public void Loop()
        {
            Graphics.sprite = new Sprite(device);
            MessagePump.Run(form, () =>
            {
                Timer(true);
                World.CameraUpdate();
                CheckNewObjects();
                Input.HandleInput();
                device.Clear(ClearFlags.Target | ClearFlags.ZBuffer , Color.Black, 1.0f, 0);
                device.BeginScene();
                DrawTileObjects();
                DrawSolidObjects();
                DrawCharObjects();
                DrawDebugMarkers();
                device.EndScene();
                try
                {
                    device.Present();
                }
                catch
                {
                   Console.WriteLine("Device Lost.");
                   Console.WriteLine("This is Unhandled. Exiting...");
                   Console.ReadLine();
                   Environment.Exit(1);
                 }
                Timer(false);
            });

            foreach (var item in ObjectTable.Objects)
                item.Dispose();
        }
    }
}