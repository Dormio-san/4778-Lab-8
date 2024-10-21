# 4778-Lab-8
Carnival shooting game that utilizes the object pool, builder, and observer design patterns.

## Object Pool Design Pattern
To implement the object pool design pattern, we first created a script that creates a new object pool when the game begins. The object pool defines things such as what to spawn, what to do when the object is gotten or released, the pool size, and more. With the pool created, we spawn five bullets to begin with. 
When the player presses the fire button, we get a bullet from the pool, place it at the firing point (just above the player), and set it active. If there is no bullet in the pool, a new one is spawned and added to the pool. Once the bullet is active, it begins moving upwards.
If the bullet exits the screen or hits an enemy, it is set to not active and awaits its turn to be called again from the pool.

## Builder Design Pattern
To implement the builder design pattern, we created 

## Observer Design Pattern
To implement the observer design pattern, we began by making an interface for the observers, and another one for the object being observed (subject). Our UI elements, for example score, derive from the IObserver interface, and attach themselves to the subject (the player). The score UI script implements an OnNotify function that runs code whenever the object has been notified by the player.
In the player script, when the change score function is called, which changes the score variable housed in the PlayerScore script, its observers are notified of the change. Once notified, the score UI script updates its UI text to display the player's new score.