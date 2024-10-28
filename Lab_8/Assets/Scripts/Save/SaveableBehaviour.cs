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
        
        if (string.IsNullOrEmpty(_saveID))
        {
            _saveID = System.Guid.NewGuid().ToString(); 
           Debug.Log("Generated SaveIDs: " + _saveID);
               
        }
        
    }
    public void OnAfterDeserialize()
    {
        Debug.LogWarning("OnAfterDeserialize is activated");
        // Perform any adjustments or checks after deserialization
        if (string.IsNullOrEmpty(_saveID))
        {
          
            Debug.LogWarning("Deserialized object does not have a valid SaveID.");
            _saveID = System.Guid.NewGuid().ToString();

        }
        
    }
}




