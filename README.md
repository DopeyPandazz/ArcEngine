# ArcEngine
2D game engine written in C# using DirectX 9 (SlimDX)

# Todo
- [x] Add SolidOject(Single Frame CharObj, or TileObj with physics) (26/07)
- [x] Fix Follow Camera - Y axis (26/07)
- [x] Add Effect Object (Play Animation then dispose) (27/07)
- [ ] Modify Physics Engine to work with top down 2D
- [ ] Add Event Detection (Example: Player reached coordinates, or Player interacted with the NPC)
- [ ] Add Char and Solid Object classification (enemy, furniture, etc)
- [ ] Add StatObj(statistic object, health, mana ect) to Char and Solid 
- [ ] Add MultiPurpose function handler (pass various events and functions to World, Example: player lost health, CharObj enemy sighted player)
- [ ] Add UIObj (unsure how this will work yet)
- [ ] Add ProjObj (projectile object)
- [ ] Add Seemless Level Changing

# Latest Commit
Added EffectObj: play animation once, currently no support for the same effect playing at different places.
Will add a 3d point list of 2d coordinates + the current animation to each EffectObj for simultaneous, independent EffectObj deployment

Added a name based object ID system: this adds a layer of abstraction from the ObjID system and allows the player to find an object based off a name they assign at creation.
Currently only supported by EffectObj and CharObj.

# Previous Commits
Y-Axis Camera: Fixed
Draw Filter: Filters out objects not on screen and doesn't try to draw them
Dynamic Player Movement: Better Key Filtering (w,a,s,d controls will work even with another key pressed down)
Also added sprinting

Initial Commit
