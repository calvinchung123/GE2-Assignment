# GE2-Assignment
Games engines 2 assignment- recreating a sci-fi scene of choice using steering behaviours
## Description Of Project
This project has 3 scenes in total. They take place on a futuristic post war earth. A task force was appointed a mission to find an old mecha suit. The team set course to find it. 

## Instructions
Load the 'Spaceship' scene. This is the first scene. You can then press play and the scenes will transition. The last scene is not automated. The camera switch is switched with the number keys 1 - 7 (discussed in detail in 'How it works: Scene 3 - Ground troops search'). 
## How It Works 
### Scene 1 - Space Ship Scene
This scene consists of the space ship approaching the planet. This scene uses the seek and arrive steering behaviours to steer the ship. The ships target is set to the planet.The scene change is changed using an OnTriggerEnter(). The scene changes when the ship collides with the planet. The two steering behaviours used were from the class repository. The scene switch was written by myself.

### Scene 2 - Planet Landing
The ship has approached the planet and sent a drop pod with a task force inside. This scene uses the arrive and seek steering behaviours to direct the pod to the planet. The same method for scene change was used here. The game object collides with was a plane and the mesh renderer was turned off. The two steering behaviours used were from the class repository. The scene switch was written by myself.

### Scene 3 - Ground troops search
This is the last scene of the short film. The ground troops have landed and are searching for the lost mech suit. The steering behaviours used in this scene consists of path following to navigate through the city aswell as obstacle avoidance to avoid the terrain where neccessary. Each squad had 4 members, these members used the offset pursue steering behaviour to align themselves to the leader.

There are 7 camera angles in this scene. The first two (keys 1 & 2) are attached to the individual squads. These cameras were atached to the leaders. The other 5 cameras (keys 3-7) were attached to places along the path that the units moved. The cameras along the scene were attached 2 scripts, cameraSwitch and FieldOfView. The first script switches between the cameras. The second script detects when a unit enters its field of view using raycasting. When a unit enters the view a debug was used to tell the user which camera to switch to. The last part of this short movie is them finding the mech. 

The steering behaviours used here were from the class repository. The camera change was written by me. The fieldOfView script was inspired from other sources but was altered to fit my project. 

### What I Am Most Proud Of In The Assignment
The part of the project i am most proud of was how the project looked. I liked the mulitple camera angles along with the animation of the soldiers walking. 


