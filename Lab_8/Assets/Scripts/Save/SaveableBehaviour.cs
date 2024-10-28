using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableBehaviour : MonoBehaviour, ISaveable, ISerializationCallbackReceiver
{
    private string _saveID;

   
    public virtual string SaveID
    {
        get => _saveID;         
        set => _saveID = value;
    }

    public abstract JsonData SavedData { get;}

    public abstract void LoadFromData(JsonData data);

    public void OnBeforeSerialize()
    {
        if (SaveID==null)
        {
            SaveID = System.Guid.NewGuid().ToString(); // Generate a new ID if none exists
        }
    }
    public void OnAfterDeserialize()
    {
        // Perform any adjustments or checks after deserialization
        if (string.IsNullOrEmpty(SaveID))
        {
            Debug.LogWarning("Deserialized object does not have a valid SaveID. now we create an ID");


        }
    }
}




