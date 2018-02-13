## Pak Pak Ed

Pak Pak Editor is a level editor for [Treasure Adventure World's](http://treasureadventureworld.com/) Pak Pak Mini game. It allows editing existing levels and the creation of new levels. The editor currently does not support any error checking for issues with the level design.

![ ](https://github.com/Daniel-McCarthy/PakPakEd/blob/master/Images/Preview-01.png)
  
# How to use:
- All mini game levels for Pak Pak can be found in the directory: Treasure Adventure World\taw_files\data\minigame
- These levels can be opened from and saved to this directory. It is possible to save over the existing Pak Pak levels but this is not recommended as they are tied to the game's hacking system and are balanced appropriately. 
- Instead: New levels can be added by saving as level09.png or the next number available. They will appear as an extra level in the Pak Pak arcade machine.

- The program requires you to select an object type then click on the canvas where you want a level piece to be. For objects like the enemy, a direction can be selected. Left/right/up/down will cause the enemy to move that direction and flip around when it hits a wall. If no direction is selected with the enemy then it will be set to a wander AI. Direction can also be selected for One-Way Directional pads.
- A timer slider can be changed which will select how much time is allowed for the level before it auto-fails the player. (0-255 seconds)
- A level requires a single player spawner to be placed and at least 1 collectible object, but this is not enforced. The designer is not restricted to any rules and therefore must design accordingly.
  
![ ](https://github.com/Daniel-McCarthy/PakPakEd/blob/master/Images/Preview-02.png)
