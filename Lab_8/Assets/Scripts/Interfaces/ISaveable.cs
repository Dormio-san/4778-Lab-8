using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Linq;

public interface ISaveable 
{
    string SaveID { get; }
    JsonData SavedData { get; }
    void LoadFromData(JsonData data);
}
public static class SavingService
{
    private const string ACTIVE_SCENE_KEY = "activeScene";
    private const string SCENES_KEY = "scenes";
    private const string OBJECTS_KEY = "objects";
    private const string SAVEID_KEY = "$saveID";
    public static void SaveGame(string fileName)
    {
        var result = new JsonData();
        var allSaveableObjects = Object.FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>();
        if (allSaveableObjects.Count() > 0)
        {
            var savedObjects = new JsonData();
            foreach (var saveableObject in allSaveableObjects)
            {
                var data = saveableObject.SavedData;
                if (data.IsObject)
                {
                    data[SAVEID_KEY] = saveableObject.SaveID;
                    savedObjects.Add(data);
                }
                else
                {
                    var behaviour = saveableObject as MonoBehaviour;
                    Debug.LogWarningFormat(behaviour, "{0}'s save data is not a dictionary. The object was not saved.", behaviour.name );
                }
            }
            result[OBJECTS_KEY] = savedObjects;
        }
        else { Debug.LogWarningFormat("The scene did not include any saveable objects."); }
     }
}


