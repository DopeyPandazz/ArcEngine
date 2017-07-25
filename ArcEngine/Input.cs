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
            
            string key = Input.GetKey();
            if (KeyPressed())
            {
                if (key.ToLower() != lastkey)
                {
                    Console.WriteLine(key);
                }
                lastkey = key.ToLower();
                if ((key.ToLower()).EndsWith("w"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerUp(CharObject);
                            return;
                        }
                    }
                }
                if ((key.ToLower()).EndsWith("a"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerLeft(CharObject);
                            return;
                        }
                    }
                }
                if ((key.ToLower()).EndsWith("s"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerDown(CharObject);
                            return;
                        }
                    }
                }
                if ((key.ToLower()).EndsWith("d"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerRight(CharObject);
                            return;
                        }
                    }
                }
            }
            else
            {
                if (lastkey.EndsWith("w"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseUp(CharObject);
                        }
                    }
                }
                if (lastkey.EndsWith("a"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseLeft(CharObject);
                        }
                    }
                }
                if (lastkey.EndsWith("s"))
                {
                    foreach (CharObj CharObject in Objects.CharObjList)
                    {
                        if (CharObject.isPlayer)
                        {
                            World.PlayerReleaseDown(CharObject);
                        }
                    }
                }
                if (lastkey.EndsWith("d"))
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
