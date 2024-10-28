using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableBehaviour : MonoBehaviour, ISaveable, ISerializationCallbackReceiver
{
    private string _saveID;

    public abstract string SaveID { get; set; }

    public abstract JsonData SavedData { get; }

    public abstract void LoadFromData(JsonData data);

    

    public void OnBeforeSerialize()
    {
        if(SaveID == null)
        {
            SaveID = System.Guid.NewGuid().ToString();
        }
    }
    public void OnAfterDeserialize()
    {
        if (string.IsNullOrEmpty(SaveID))
        {
            Debug.LogWarning("Deserialized object does not have a valid SaveID. Now we create an ID");
        }

    }



}
