Top Down Heist
==============

### Summary:
- Available at https://heist.indietasten.net
- Co-op game.
- In-Browser
- Top Down view
- Prison Architect graphics
- Pay Day 2-like gameplay

### Technology:
- ASP.NET Core Server
- Web Sockets Networking
- TypeScript business implementations for server and client shared
- PIXI.js WebGL rendering

### Extras:
- Community
    - Level Editor
    - Public level repository
    - User ratings for levels
    - Leaderboards
- Completion rating
- Character progression


## Gameplay

### Mechanics:
#### Fog of war
Upon loading a level, everything will be covered in fog. As players walk around, they can uncover building foundation, walls, objects, civilians and guards.
After a short period of time, unwatched civilians and guards disappear in fog again.

#### Suspicion Levels
As players walk or create other noises heard by nearby guards or civilians, they will raise the suspicion level of their current location. Guards will be attracted to suspicious locations

#### Defenses
##### Cameras (stationary, rotating)
Cameras are objects that can be placed as an object onto walls. They have a fixed field of view, in which they can detect suspicious activity. Cameras need to be operated by a guard to function. Cameras do not sense noises.

##### Guards
Guards are moving cameras. They will be attracted to suspicious locations. As they patrol around, every location they see that doesn't have anything suspicious in sight will be neutralized in their suspicion level for a period of time. (If you just looked at something, you don't expect something to be there the next second. Cat-pickle-phenomenon)
Once a guard completely detected suspicious activity, such as broken security measures, blood or players, they will use their pager to alert others. A guard in "alerted" state also counts as suspicious activity to other guards in sight. As a guard might shout callouts, he also creates suspicious sounds for surrounding guards and civilians.

##### Laser trips
Laser trips can trigger an alarm, if something interrupts the beam between a sending and a receiving unit. The beams are invisible to players, even if the sending and receiving units are no longer in fog of war. The water vapor euqipment might be used to temporarily make lasers visible again. A laser pointer can also be used to fool the receiving unit to think, that a beam is uninterrupted even though players might cross through

#### Civilians
Civilians are just like guards, but they do never carry pagers. Civilians also have a reduced sense for suspicious activity. Instead of challanging players that alerted them, they will either start running, or surrender to the ground, depending on the intimidation level of the source that alerted them.

#### Combination Lock
A combination lock is a lock that requires a sequence of numbers to be selected on a rotor. The numbers can either be obtained by authorized personell, or by trial and error. The combination lock can be a minigame in which you can get the correct sequence by having a good hearing and some knowledge about the brand/manufacturer of the lock.

#### Key card reader
A key card reader is a card reader that takes cards from authorized personell to unlock doors or disable alarm systems like lasers

#### Key pad
A keypad that requires a keycode to be unlocked. Can be used to shutdown alarm systems like lasers

#### Fingerprint Scanner
    - Fingerprint
- Security Offices
- Fog of War
- Hijacking Cameras
- Vents (Ventilation System)
- Pressure Plate maze
- Router boxes
- Power circuit boxes
- Throwing objects/equipment
- Putting on disguise
- Business owners / employees
- Stairs / Lifts to multiple stories

### Tools/Equipment:
- 9mm Pistol (silenced)
- Piano String
- Jackknife
- Tazer
- Vapor (Displaying laser trips)
- Laser pointer (Fooling laser trips)
- Glass cutter
- Smartphone (Used for hacking)
- Thermite
- Lockpick
- Screwdriver
- Ammunition
- Body bags
- Pickaxe


### Gamemodes:
- stealth
- 

## Content

### Heist Primary Objectives:
- Steal an object
- Break an object
- Gather intelligence
- Kill a target
- Clear the area
