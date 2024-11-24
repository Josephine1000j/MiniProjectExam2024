Mini-Project

Project Name: Hometown Runner 
Name: Josephine Møldrup Møller Holm
Student Number: 20233509
Link to Project: https://github.com/Josephine1000j/MiniProjectExam2024.git

Overview of the Game:
The game is a "but worse" take on popular endless runner games like Temple Run and Subway Surfers. The player controls a character who continuously runs forward after pressing the forward key (W or up arrow). The objective is to avoid obstacles scattered along the road, dodging them by running left or right or jumping, as the player’s character speeds up overtime.
The game offers an element of chaos, with randomly spawned obstacles, the players speed increasing, and coins, which the player can collect while they run – all of this results in the player having to react quickly to survive the game, or else when they hit the obstacles the restart screen will show, where the player can see restart the game, see their distance and coins, along with the games prior distance and coin high scores. 
 The goal is to run as far as possible, collecting points along the way by avoiding obstacles and overcoming challenges while trying to keep the character on the path without crashing.
The game is fast-paced, and as the player progresses the speed and therefore the difficulty increases, making it harder to avoid obstacles and collect coins. 

The main parts of the game are:
•	Player – The player controls a woman character, who is moved using the keyboard (WASD or arrow keys).
•	Camera – The camera follows the player throughout the game, keeping them in view as they run and navigate obstacles.
•	Coins – Collectible coin objects/prefabs that the player can pick up while running, adding to the score and providing a goal for the player to reach.
•	Obstacles - Prefab objects that the player/runner must dodge while running. If the player collides with an obstacle, they will have to start the game over.
•	Enemies – FUTURE WORK

Game features:
•	Positions of coins and obstacles are randomly spawned each time helping with replayability.
•	The difficulty of the game changes with time, making it harder (the runners’ speed increases)
•	The game keeps track of a score (coins and distance), and the high scores for prior games

How the Different Parts of the Course Were Utilized:
In this project, I applied several key concepts from the course to develop an endless runner game in Unity. I implemented C# scripts to control core gameplay mechanics, including player movement, jumping, and collision detection with obstacles and coins. The camera system was configured to follow the player seamlessly as they navigated the environment. I also designed dynamic spawning systems to generate roads, coins, and obstacles, ensuring a continuous gameplay experience. The user interface was designed to display the player’s score and distance ran, providing real-time feedback. Additionally, Unity’s physics engine was utilized for accurate collisions, and object pooling techniques were used to optimize performance by reusing game objects.

Project Parts:
•	Scripts:
o	Rotate: Rotates the object continuously at a specified speed.
o	RoadSpawner: Moves roads in a loop, ensuring a continuous flow by repositioning the first road segment to the end.
o	Plotspawner: Generates plots on the left and right sides of the road, spaced evenly as the player progresses.
o	ObstacleSpawner: Spawns obstacles at random intervals along the road, with a chance of appearing on each segment.
o	GameManager: Manages the UI for displaying player distance and coin count and tracks the number of collected coins.
o	CoinSpawner: Spawns coins at random positions along the road, avoiding overlap with obstacles and other coins.
o	CharControl: Handles player movement, jumping, and collisions, while increasing speed over time and triggering events like coin collection or game/scene restart.
o	CameraControl: Follows the player with a fixed offset to keep them in view while running.
o	AnimationStateController: NOT used, came with a assets import

•	Models & Prefabs:
o	Coin, was self-made in blender
o	Player/Runner, woman, is prefab from the package City People Life: https://assetstore.unity.com/packages/3d/characters/city-people-lite-260446 
o	Various prefabs from the package SimplePoly City - Low Poly Assets was used (for e.g. trees, stones, bushes, car, cones, street lamp, road) https://assetstore.unity.com/packages/3d/environments/simplepoly-city-low-poly-assets-58899 
o	Some tree prefabs from the package Low Poly Houses Free Pack https://assetstore.unity.com/packages/3d/props/exterior/low-poly-houses-free-pack-243926 
o	Various prefabs from the package CITY package was used for e.g. street lamp, bushes, obstacles, houses) https://assetstore.unity.com/packages/3d/environments/urban/city-package-107224 
•	Materials:
o	Basic Unity materials for coin, road, pavement, and grass
•	Scenes:
o	Game consists of three scenes, but only the ‘Main2’ is where the game is, the other two came with imported packages. 
•	Testing:
o	Game was tested on Windows, game cannot be currently played on a mobile platform

Time Management
Task	Time it Took (in hours)
Setting up Unity, making a project in GitHub + making word report document	2
Research and conceptualization of game idea	1
Searching for 3D models – Houses, animals, player etc. 	0.5
Making camera movement controls and initial testing	1
Player movement	2
Combining player movement with camera orientation, bugfixing	0.5
Building the prefabs of roads and side content (houses)	3
Making the spawning of roads and houses, and having them spawn endlessly as the player runs	3
Building random obstacle spawners, and coding randomizing starting positions	4
Making 3D Coin in Blender	0.5

Building random coin spawner, randomizing their spawning 
	1.5
Making UI elements with Text (Legacy) (coin and distance text) 	1
Colliders/Collisions and bugfixing errors (on player, coins, obstacles)	3
Playtesting and bugfixing 	2
Code documentation / Rapport / PowerPoint	2.5
Making readme	0.5
All	27



Used Resources
•	CHATGPT – The website has been used throughout this miniproject to help on the code, when bugs and errors happened, and some help on making some of the code/scripts. 
•	3D Endless Runner in Unity: #1 - #8
https://www.youtube.com/playlist?list=PL2xbYe8TgQDPsXgVmd8RJdoIJ3eLio7R6 








