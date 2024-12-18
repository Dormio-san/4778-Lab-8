# 4778-Lab-9
Continuation of Lab 8 that now includes saving and loading functionality for the player, enemies, score, and health!  
  
## Saving Script Design Pattern
To implement the Saving Script Design pattern, we modified the player script to inherit the TransformSave script, which saves the position of the object, and assigns a SAVEID so that it can be referenced for later. The transformSave script inherits from SaveableBehaviour script, which generates the SaveID for the object, and checks to see if it is attached or not. The SavingService script uses multiple methods to perform saving and loading. To begin with, the SaveGame method creates a new Json file, finds any object that have the ISaveable object, and iterates over all objects to save their information. It also saves the scene information and writes it through JsonWriter, which is from the LitJson package. For saving scores, we stored them in a Binary file through the SaveGameBinary method. To load a game, we used the LoadGame method which first checks to see if a file exists, then afterwards loads the data. If there is no data, then Unity will print out an error that the save file doesn't exist.  

## Demo
https://github.com/user-attachments/assets/a06e7bf0-cbf3-46cf-815f-a168b687e768  


  
  

# 4778-Lab-8
Carnival shooting game that utilizes the object pool, builder, and observer design patterns.

## Demo
https://github.com/user-attachments/assets/7b2d6984-eb5e-413d-9e9d-7fcfc02b292c

## Object Pool Design Pattern
To implement the object pool design pattern, we first created a script that creates a new object pool when the game begins. The object pool defines things such as what to spawn, what to do when the object is gotten or released, the pool size, and more. With the pool created, we spawn five bullets to begin with.  
When the player presses the fire button, we get a bullet from the pool, place it at the firing point (just above the player), and set it active. If there is no bullet in the pool, a new one is spawned and added to the pool. Once the bullet is active, it begins moving upwards.  
If the bullet exits the screen or hits an enemy, it is set to not active and awaits its turn to be called again from the pool.  

![Object Pool Design Pattern](<Diagrams/Object-Pool-Diagram.png>)

## Builder Design Pattern
To implement the builder design pattern, we first created an enemy script that sets and gets the necessary information for the enemy. In this case it was the number of points it has, and the speed.  We then created an EnemyBuilder script that creates the interface for the enemy, such as assigning its speed and points. We also had to create two scripts for the different enemy types 
that use the same interface to assign these values. We then created a builder script that assigns the type of enemy based on its tag, and calls the necessary classes and interfaces for either enemy type. This also led to the creation of the Shop script which is called in the Builder script, where depending on the type of EnemyBuilder is used, will assign the values based on a method call 
to the BuildPoints and BuildSpeed scripts.  

![Builder Design Pattern Diagram](<Diagrams/Builder Diagram.jpg>)

## Observer Design Pattern
To implement the observer design pattern, we began by making an interface for the observers, and another one for the object being observed (subject). Our UI elements, for example score, derive from the IObserver interface, and attach themselves to the subject (the player). The score UI script implements an OnNotify function that runs code whenever the object has been notified by the player.  
In the player script, when the change score function is called, which changes the score variable housed in the PlayerScore script, its observers are notified of the change. Once notified, the score UI script updates its UI text to display the player's new score.  

![Observer Design Pattern Diagram](<Diagrams/Observer-Diagram.png>)
