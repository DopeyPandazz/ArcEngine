# What does what
## Core.cs
Entry point into the program, this starts the inizialization functions for all the other stuff.
## Functions.cs
This hold all the functions that need to be modifyed to fit each game: player pressed left, player jumped, update camera etc.<br>
_This is what the game developer will edit_
## Graphics.cs
Handles drawing the objects and keeping the game time right.
## Input.cs
Handles: getting, filtering and handleing player input.
## Objects.cs
This is where the custom object definitions are held, and object creation functions.
## Physics.cs
This is where PhysObj is defined and the physics functions are (collision, etc).
## World.cs
This is where all the objects are created and where the important variables are.<br>
_This is what the game developer will edit_

