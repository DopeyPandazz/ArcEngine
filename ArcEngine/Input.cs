using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectInput;
namespace ArcEngine
{
    class Input
    {
        static public DirectInput directInput;
        static public Keyboard keyboard;
        static public string lastkey = "";
        static public string currentkey = "";
        static public void Start()
        {
            directInput = new DirectInput();
            keyboard = new Keyboard(directInput);
            keyboard.SetCooperativeLevel(Graphics.form, CooperativeLevel.Nonexclusive | CooperativeLevel.Background);
            keyboard.Acquire();
            Console.WriteLine("Got Keyboard Input");
        }
        static public string GetKey()
        {
            KeyboardState keys = keyboard.GetCurrentState();
            string keysstring = "";
            foreach (Key key in keys.PressedKeys)
            {
                keysstring = keysstring + key.ToString();
            }
            return keysstring;
        }
        static public bool KeyPressed()
        {
            KeyboardState keys = keyboard.GetCurrentState();
            bool pressed = false;
            if (keys.IsPressed(Key.W)) { pressed = true; }
            if (keys.IsPressed(Key.A)) { pressed = true; }
            if (keys.IsPressed(Key.S)) { pressed = true; }
            if (keys.IsPressed(Key.D)) { pressed = true; }
            return pressed;
        }
        public static void HandleInput()
        {
            
            KeyboardState key = keyboard.GetCurrentState();
            if (KeyPressed() & key.PressedKeys.Count > 0)
            {
                //if (key.ToLower() != lastkey)
                //{
                //    Console.WriteLine(key);
                //}
                lastkey = "null";
                currentkey = "null";
                foreach (Key akey in key.PressedKeys.Reverse())
                {
                    if (lastkey == "null")
                    {
                        if (akey == Key.W) { lastkey = "w"; }
                        if (akey == Key.A) { lastkey = "a"; }
                        if (akey == Key.S) { lastkey = "s"; }
                        if (akey == Key.D) { lastkey = "d"; }
                    }
                }
                foreach (Key akey in key.PressedKeys)
                {
                    if (currentkey == "null")
                    {
                        if (akey == Key.W) { currentkey = "w"; }
                        if (akey == Key.A) { currentkey = "a"; }
                        if (akey == Key.S) { currentkey = "s"; }
                        if (akey == Key.D) { currentkey = "d"; }
                    }
                }
                bool sprint = key.IsPressed(Key.LeftShift);
                if (currentkey == "w")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerUp(CharObject,sprint);
                            return;
                        }
                    }
                }
                if (currentkey == "a")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerLeft(CharObject, sprint);
                            return;
                        }
                    }
                }
                if (currentkey == "s")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerDown(CharObject, sprint);
                            return;
                        }
                    }
                }
                if (currentkey == "d")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerRight(CharObject, sprint);
                            return;
                        }
                    }
                }
            }
            else
            {
                if (lastkey == "w")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseUp(CharObject);
                        }
                    }
                }
                if (lastkey == "a")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseLeft(CharObject);
                        }
                    }
                }
                if (lastkey == "s")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseDown(CharObject);
                        }
                    }
                }
                if (lastkey == "d")
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseRight(CharObject);
                        }
                    }
                }
            }
            
        }
    }
}
