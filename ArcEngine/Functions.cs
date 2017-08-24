using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ArcEngine
{
    class Functions
    {
        static public bool saveChecker(string save)
        {
            bool result = true;

            return result;
        }

        static public void SaveGame(string save)
        {
            //User enters the save name
            string saveName;

            //Debug. Not real method 
            Console.WriteLine("Enter your save name: ");
            saveName = Console.ReadLine();
            if (saveChecker(saveName))
            {
                Console.WriteLine("Error. Save already exists, would you like to load it? Yes or No");//Debug. Not final code
                string choice = Console.ReadLine();
                if (choice == "yes" || choice == "Yes")
                {
                    //loads saveName 
                    LoadGame(saveName);
                }
                else if (choice == "no" || choice == "No")
                {
                    //asks the user for another saveName
                }
                else
                {
                    Console.WriteLine("Error, You did not enter Yes or No. Try again");
                    //redo that shit
                }
            }


        }

        static public void LoadGame(string save)
        {

        }
        static public void PlayerLeft(CharObj PlayerObj, bool sprint)
        {
            if (sprint == true)
            {
                PlayerObj.Speed = 1;
                PlayerObj.X -= World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.Speed = 10;
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
                PlayerObj.Speed = 5;
                PlayerObj.X += World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.Speed = 10;
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
                PlayerObj.Speed = 5;
                PlayerObj.Y -= World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.Speed = 10;
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
                PlayerObj.Speed = 5;
                PlayerObj.Y += World.PlayerSprintSpeed;
            }
            else
            {
                PlayerObj.Speed = 10;
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
                        if (Math.Abs(World.TileOffsetX) >= 32)
                        {
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
