# 4778-Lab-8
Carnival shooting game that utilizes the object pool, builder, and observer design patterns.

## Demo
https://github.com/user-attachments/assets/7b2d6984-eb5e-413d-9e9d-7fcfc02b292c

## Saving Script Design Pattern
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
