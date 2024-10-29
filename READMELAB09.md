# 4778-Lab-8
Carnival shooting game that utilizes the object pool, builder, and observer design patterns.

## Demo
https://github.com/user-attachments/assets/7b2d6984-eb5e-413d-9e9d-7fcfc02b292c

## Saving Script Design Pattern
To implement the Saving Script Design pattern, we modified the player script to inherit the TransformSave script, which saves the position of the object, and assigns a SAVEID so that it can be referenced for later. The transformSave script inherits from SaveableBehaviour script, which generates the SaveID for the object, and checks to see if it is attached or not. The SavingService script uses multiple methods to perform saving and loading. To begin with, the SaveGame method creates a new Json file, finds any object that have the ISaveable object, and iterates over all objects to save their information. It also saves the scene information and writes it through JsonWriter, which is from the LitJson package. For saving scores, we stored them in a Binary file through the SaveGameBinary method. To load a game, we used the LoadGame method which first checks to see if a file exists, then afterwards loads the data. If there is no data, then Unity will print out an error that the save file doesn't exist.