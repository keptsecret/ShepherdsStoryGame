i. start scene file is StartMenu
ii. How to play the game:
To begin the game, the player uses their mouse to navigate through the UI. Once the user gets into a level, the player can use their mouse/controller to adjust the camera angle of the player. To move around, the player has the option to move using WASD or the arrow keys.

Depending on the level, there are different puzzles for the player to complete. The end objective of each level though is to herd all the sheep within the pen before the timer runs out. The timer is able to be seen in the top right corner, and the number of sheep that are still alive can be seen in the top left corner. 

Technology Requirements:
For the first part, with a 3D game feel, you can see that within any of the levels, with an objective to get the sheep in a pen. The player is controlled in a third-person perspective and general game design like replaying/resetting can be accessed in the menu when the user presses ESC.

For fun gameplay, we are working on implementing the goals, we display the amount of sheep alive and a timer to add urgency to the player. The goal/area that the user needs to head towards is a green area currently. The player is able to walk around and bump into different areas and environments like trees and have things that run away from it such as the sheep which is the main gameplay mechanic. 

For real-time control, we used controls from the things we learned in class to control movement. We added different ways for the character to manipulate the angle that they view the character through the camera movement being tied to the mouse as well. As well, other of the general features that were requested can be seen with any of the levels where you control the character.

For physics and spatial simulation, when we created the levels, we created the terrain and environment from scratch. We kept the clipping to a minimum and bodies that are able to move around, like the sheep who are able to move around in any direction. The other features are able to be seen as the player explores each level. 


For AI and behaviors, the AI has fluid animations in chasing the sheep in terms of the wolf, adding difficulty to completing the level. The wolf prevents the user from collecting all the sheep and the animation is fluid whether it’s the sheep running away from you or getting killed by the wolf. 

iii. Known Problem Areas
No game over screen yet
Sheep do not flock yet
Player does not respawn if they fall off the world

iv. Manifest of which files authored by each teammate
Steven was in charge of character control and the creation of the first level. Courtney contributed to the sheep and created the second level. Sorakrit implemented sheep control along with the camera, background, and sky. Seo Hyun created game menus and other UI components and implemented the wolf.

Assets Implemented:
Player - Steven
Wolf - Seohyun
Sheep - Sorakrit and Courtney
Background/Sky - Sorakrit
Environment/Terrain - Courtney (Level 2) and Steven (Level 1)
UI Elements- Seohyun
Third Person Camera Controller - Sorakrit

File Manifest:
AnimationAndMovementController.cs (merged into PlayerController.cs) - Steven
ButtonGate.cs - Steven
CameraController.cs - Sorakrit
CharacterInputController.cs (merged into Playercontroller.cs) - Steven
Flock.cs - Courtney
FlockManager.cs - Courtney
GameManager.cs - Seo Hyun
GameQuitter.cs - Seo Hyun
GameStarter.cs - Seo Hyun
GoalTriggerScript.cs - Sorakrit
LevelStateManager.cs - Sorakrit
PauseMenuToggle.cs - Seo Hyun
PlayerController.cs - Sorakrit
SheepController.cs - Sorakrit
SheepCountUI.cs - Seo Hyun
SheepGroupManager.cs - Courtney
SkyState.cs - Sorakrit
StumpLevel1.cs - Steven
TimerUI.cs - Seo Hyun
WolfAI.cs - Seo Hyun
WolfController.cs - Seo Hyun
FlowerManager.cs - Courtney
Elevator.cs - Courtney
BlueSphere.cs - Courtney

