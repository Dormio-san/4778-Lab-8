

using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.Events;

public class SavingService 
{

    private const string ACTIVE_SCENE_KEY = "activeScene";
    private const string SCENES_KEY = "scenes";
    private const string OBJECTS_KEY = "objects";
    private const string SAVEID_KEY = "$saveID";

    public static  UnityAction<Scene, LoadSceneMode> LoadObjectsAfterSceneLoad;

    public static void SaveGame(string fileName) 
    {
        var result = new JsonData(); // Create an empty JSON data object.
        var allSaveableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>(); // Get all ISaveable objects in the scene.

        if (allSaveableObjects.Count() > 0) // Check if there are any saveable objects.
        {
            var savedObjects = new JsonData(); // Create an empty JSON array for saving the objects.

            foreach (var saveableObject in allSaveableObjects) // Iterate over each saveable object.
            {                                                   
                var data = saveableObject.SavedData; // Get the save data from the object.

                if (data.IsObject) // Check if the saved data is a dictionary-like structure.
                { 
                    data[SAVEID_KEY] = saveableObject.SaveID; // Add the save ID to the data.
                    savedObjects.Add(data); // Add the object's data to the list of saved objects.
                } 
                else // If the data is not in the correct format, log a warning with the object's name.
                {
                    var behaviour = saveableObject as MonoBehaviour;
                    Debug.LogWarningFormat(behaviour, "{0}'s save data is not a dictionary. The object was not saved.", behaviour.name);
                }
            }

            result[OBJECTS_KEY] = savedObjects; // Store all saved objects under the key "objects".

            // Add scene data (active scene and open scenes)
            var openScenes = new JsonData();
            var sceneCount = SceneManager.sceneCount;
            for (int i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                openScenes.Add(scene.name);
            }
            result[SCENES_KEY] = openScenes;
            result[ACTIVE_SCENE_KEY] = SceneManager.GetActiveScene().name;

            // Save the result to a file
            var outputPath = Path.Combine(Application.persistentDataPath, fileName);
            var writer = new JsonWriter { PrettyPrint = true };
            result.ToJson(writer);
            File.WriteAllText(outputPath, writer.ToString());
            Debug.LogFormat("Wrote saved game to {0}", outputPath);
            result = null; // Clear the result to free memory.
            System.GC.Collect(); // Run the garbage collector.
        } 
        else 
        { 
            // If there are no saveable objects, log a warning.
            Debug.LogWarning("The scene did not include any saveable objects."); 
        }
    }

/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static bool LoadGame(string fileName) 
    {
        var dataPath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(dataPath) == false) 
        { 
            Debug.LogErrorFormat("No file exists at {0}", dataPath); 
            return false; 
        }

        var text = File.ReadAllText(dataPath);
        var data = JsonMapper.ToObject(text);
    
        if (data == null || data.IsObject == false) 
        { 
            Debug.LogErrorFormat("Data at {0} is not a JSON object", dataPath); 
            return false; 
        }

        if (!data.ContainsKey(SCENES_KEY)) 
        { 
            Debug.LogWarningFormat("Data at {0} does not contain any scenes; not loading any!", dataPath); 
            return false; 
        }

        var scenes = data[SCENES_KEY];
        int sceneCount = scenes.Count;

        if (sceneCount == 0) 
        { 
            Debug.LogWarningFormat("Data at {0} doesn't specify any scenes to load.", dataPath); 
            return false; 
        }

        for (int i = 0; i < sceneCount; i++) 
        {
            var scene = (string)scenes[i];
        
            if (i == 0) 
            { 
                SceneManager.LoadScene(scene, LoadSceneMode.Single); 
            } 
            else 
            { 
                SceneManager.LoadScene(scene, LoadSceneMode.Additive); 
            } 
        }

        if (data.ContainsKey(ACTIVE_SCENE_KEY)) 
        {
            var activeSceneName = (string)data[ACTIVE_SCENE_KEY];
            var activeScene = SceneManager.GetSceneByName(activeSceneName);
        
            if (activeScene.IsValid() == false) 
            {
                Debug.LogErrorFormat("Data at {0} specifies an active scene that doesn't exist. Stopping loading here.", dataPath); 
                return false; 
            }

            SceneManager.SetActiveScene(activeScene);
        } 
        else 
        {
            Debug.LogWarningFormat("Data at {0} does not specify an active scene.", dataPath); 
        }

        if (data.ContainsKey(OBJECTS_KEY)) 
        {
            var objects = data[OBJECTS_KEY];
    
            // Assigning a proper function to LoadObjectsAfterSceneLoad
            LoadObjectsAfterSceneLoad = (scene, loadSceneMode) => 
            {
                // This block will execute after scenes are loaded.
                var allLoadableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToDictionary(o => o.SaveID, o => o);
                var objectsCount = objects.Count;

                for (int i = 0; i < objectsCount; i++) 
                {
                    var objectData = objects[i];
                    var saveID = (string)objectData[SAVEID_KEY];

                    if (allLoadableObjects.ContainsKey(saveID)) 
                    {
                        var loadableObject = allLoadableObjects[saveID];
                        loadableObject.LoadFromData(objectData);
                    }
                }
                SceneManager.sceneLoaded-= LoadObjectsAfterSceneLoad;
                LoadObjectsAfterSceneLoad = null;
                System.GC.Collect();
            };

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += LoadObjectsAfterSceneLoad;
        }

    
        return true;
    }


}
