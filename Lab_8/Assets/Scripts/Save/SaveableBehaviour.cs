using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveableBehaviour : MonoBehaviour, ISaveable, ISerializationCallbackReceiver
{
    public abstract string SaveID { get; set;}

    public abstract JsonData SavedData { get; }

    public abstract void LoadFromData(JsonData data);

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
       
    }

    
   
}
