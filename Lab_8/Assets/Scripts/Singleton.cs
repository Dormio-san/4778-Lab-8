using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Instance that is referenced in other scripts.
    public static T instance
    {
        get
        {
            // If the instance is null, find or create an instance.
            if (_instance == null)
            {
                _instance = FindOrCreateInstance();
            } 
            return _instance; 
        }

    }

    // Instance set in this script.
    private static T _instance;

    // Search for an instance of the singleton in the scene.
    // If it can't find one, create a new game object and add the singleton component to it.
    private static T FindOrCreateInstance()
    {
        var instance = GameObject.FindObjectOfType<T>();

        // If the instance is found, return it.
        if (instance != null)
        {
            return instance;
        }

        // If the instance is not found, create a new game object called the script name + Singleton.
        // Then, add the script to the game object.
        // For example, my InputManager scipt would be on a game object called InputManagerSingleton, if it wasn't found.
        var name = typeof(T).Name + "Singleton";
        var containerGameObject = new GameObject(name);
        var singletonComponent = containerGameObject.AddComponent<T>();
        return singletonComponent;
    }
}