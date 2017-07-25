using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ArcEngine
{
    class PhysObj
    {
        public double Mass { get; set; }
        public double Rotation { get; set; }
        public int Radius { get; set; }
        public double XV { get; set; }
        public double YV { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool HasGravity { get; set; }

        public void Update()
        {
            X += (float)XV / 10;
            Y += (float)YV / 10;
        }
        public void CollisionCheck()
        {
            foreach (PhysObj PhyObj in Physics.PhysObjList)
            {
                foreach (PhysObj PhyObj2 in Physics.PhysObjList)
                {
                    double distance = (Math.Sqrt(Math.Pow((PhyObj.X - PhyObj2.X), 2) + Math.Pow((PhyObj.Y - PhyObj2.Y), 2)));
                    if (distance < (PhyObj.Radius + PhyObj2.Radius) && distance > 0)
                    {

                        //Console.WriteLine("Collision : " + (Math.Sqrt(Math.Pow((PhyObj.X - PhyObj2.X), 2) + Math.Pow((PhyObj.Y - PhyObj2.Y), 2))).ToString());
                        //Console.WriteLine("XV Old: " + PhyObj.XV + " " + PhyObj2.XV);
                        //Collision
                        double ColPointX = ((PhyObj.X * PhyObj2.Radius) + (PhyObj2.X * PhyObj.Radius)) / (PhyObj.Radius + PhyObj2.Radius);
                        double ColPointY = ((PhyObj.Y * PhyObj2.Radius) + (PhyObj2.Y * PhyObj.Radius)) / (PhyObj.Radius + PhyObj2.Radius);
                        double NXV = (PhyObj.XV * (PhyObj.Mass - PhyObj2.Mass) + (2 * PhyObj2.Mass * PhyObj2.XV)) / (PhyObj.Mass + PhyObj2.Mass);
                        double NYV = (PhyObj.YV * (PhyObj.Mass - PhyObj2.Mass) + (2 * PhyObj2.Mass * PhyObj2.YV)) / (PhyObj.Mass + PhyObj2.Mass);
                        double NXV2 = (PhyObj2.XV * (PhyObj2.Mass - PhyObj.Mass) + (2 * PhyObj.Mass * PhyObj.XV)) / (PhyObj.Mass + PhyObj2.Mass);
                        double NYV2 = (PhyObj2.YV * (PhyObj2.Mass - PhyObj.Mass) + (2 * PhyObj.Mass * PhyObj.YV)) / (PhyObj.Mass + PhyObj2.Mass);
                        PhyObj.XV = (NXV / 100) * 90;
                        PhyObj.YV = (NYV / 100) * 90;
                        PhyObj2.XV = (NXV2 / 100) * 90;
                        PhyObj2.YV = (NYV2 / 100) * 90;
                        distance = (Math.Sqrt(Math.Pow((PhyObj.X - PhyObj2.X), 2) + Math.Pow((PhyObj.Y - PhyObj2.Y), 2)));
                        while (distance < (PhyObj.Radius + PhyObj2.Radius) && distance > 0)
                        {
                            PhyObj.X = (float)(PhyObj.X + (PhyObj.XV / 10));
                            PhyObj.Y = (float)(PhyObj.Y + (PhyObj.YV / 10));
                            PhyObj2.X = (float)(PhyObj2.X + (PhyObj2.XV / 10));
                            PhyObj2.Y = (float)(PhyObj2.Y + (PhyObj2.YV / 10));
                            distance = (Math.Sqrt(Math.Pow((PhyObj.X - PhyObj2.X), 2) + Math.Pow((PhyObj.Y - PhyObj2.Y), 2)));

                        }
                    }
                }
            }
        }
        public void CollisionCheckBorder()
        {
            if (Y + Radius > World.WindowHeight)
            {
                YV = (YV / 100) * 85;
                YV *= -1;
                Y = World.WindowHeight - Radius;
            }
            if (Y - Radius < 20)
            {
                YV = (YV / 100) * 85;
                YV *= -1;
                Y = 20 + Radius;
            }
            if (X + Radius > World.WindowWidth)
            {
                XV = (XV / 100) * 85;
                XV *= -1;
                X = World.WindowWidth - Radius;
            }
            if (X - Radius < 20)
            {
                XV = (XV / 100) * 85;
                XV *= -1;
                X = 20 + Radius;
            }
        }
        public void Gravity()
        {
            if (HasGravity)
            {
                if (Y < World.WindowHeight - Radius - 0.1)
                {
                    YV += 0.98;
                }
            }
        }
        public PhysObj(float ycoord, float xcoord, double xvelocity, double yvelocity, int radius, double mass, bool hasgravity)
        {
            Radius = radius;
            X = xcoord;
            Y = ycoord;
            XV = xvelocity;
            YV = yvelocity;
            Mass = mass;
            HasGravity = hasgravity;
        }
        public PhysObj()
        {
            Radius = 0;
            X = 0;
            Y = 0;
            XV = 0;
            YV = 0;
            Mass = 0;
            HasGravity = false;
        }
    }
    class PhysCollision
    {
        public double XV1 { get; set; }
        public double YV1 { get; set; }
        public double XV2 { get; set; }
        public double YV2 { get; set; }
        public PhysCollision(double XVel1, double YVel1, double Mass1, double XVel2, double YVel2, double Mass2)
        {
            XV1 = (XVel1 * (Mass1 - Mass2) + (2 * Mass2 * XVel1)) / (Mass1 + Mass2);
            XV2 = (XVel2 * (Mass2 - Mass1) + (2 * Mass1 * XVel2)) / (Mass2 + Mass1);
            YV1 = (YVel1 * (Mass1 - Mass2) + (2 * Mass2 * YVel1)) / (Mass1 + Mass2);
            YV2 = (YVel2 * (Mass2 - Mass1) + (2 * Mass1 * YVel2)) / (Mass2 + Mass1);
        }
        internal void Update()
        {

        }
    }
    class Physics
    {
        static public List<PhysObj> PhysObjList = new List<PhysObj>();
        static public void Start()
        {
            Console.WriteLine("Creating Physics Objects");
            //int ObjCount = 1;
            //for(int x = 0; x != ObjCount; x++){
            //    Random Ran = new Random(x);
            //    double XC = ((SlimDirectX.width - 100) / (Ran.NextDouble() * 100)) + 50;
            //    Ran = new Random(Ran.Next(100));
            //    double YC = ((SlimDirectX.height - 100) / (Ran.NextDouble() * 100)) + 50;
            //    Ran = new Random(Ran.Next(100));
            //    double VX = Ran.NextDouble() * 100;
            //    Ran = new Random(Ran.Next(100));
            //    double VY = Ran.NextDouble() * 100;
            //    Ran = new Random(Ran.Next(100));
            //    int R = Ran.Next(4, 30);
            //    Ran = new Random(Ran.Next(100));
            //    double M = (Ran.NextDouble() * 100) / 2;
            //}
            //PhysObjList.Add(new PhysObj(200.0f, 200.0f, 50.0, 50.0, 10, 20.0, true));
            // Main loop
            Console.WriteLine("Ready to Begin Loop, Press Enter to Start..." + Physics.PhysObjList.Count.ToString());
            Console.ReadLine();
        }
        static public void Calculate()
        {
            foreach (PhysObj ellipse in PhysObjList)
            {
                ellipse.Update();
                Console.WriteLine("X: " + ellipse.X.ToString());
            }
            foreach (PhysObj ellipse in PhysObjList)
            {
                ellipse.CollisionCheck();
                Console.WriteLine("X: " + ellipse.X.ToString());
            }
            foreach (PhysObj ellipse in PhysObjList)
            {
                ellipse.Gravity();
                Console.WriteLine("X: " + ellipse.X.ToString());
            }
            foreach (PhysObj ellipse in PhysObjList)
            {
                ellipse.CollisionCheckBorder();
                Console.WriteLine("X: " + ellipse.X.ToString());
                Console.ReadLine();
            }
        }
    }
}