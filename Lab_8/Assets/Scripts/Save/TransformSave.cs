using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class TransformSave : SaveableBehaviour
{
    private const string LOCAL_POSITION_KEY = "localPosition";
    private const string LOCAL_ROTATION_KEY = "localRotation";
    private const string LOCAL_SCALE_KEY = "localScale";
    private const string LOCAL_SAVEID_KEY = "$saveID";

    private JsonData SerializeValue(object obj)
    {
        return JsonMapper.ToObject(JsonUtility.ToJson(obj));
    }

    private T DeserializeValue<T>(JsonData data)
    {
        return JsonUtility.FromJson<T>(data.ToJson());
    }

    public override JsonData SavedData
    {
        get
        {
            var result = new JsonData();
            result[LOCAL_POSITION_KEY] = SerializeValue(transform.localPosition);
            result[LOCAL_ROTATION_KEY] = SerializeValue(transform.localRotation);
            result[LOCAL_SCALE_KEY] = SerializeValue(transform.localScale);
            result[LOCAL_SAVEID_KEY] = SaveID;
            return result;
        }
    }

    public override void LoadFromData(JsonData data)
    {
        if (data.ContainsKey(LOCAL_POSITION_KEY))
        {
            transform.localPosition = DeserializeValue<Vector3>(data[LOCAL_POSITION_KEY]);
        }
        if (data.ContainsKey(LOCAL_ROTATION_KEY))
        {
            transform.localRotation = DeserializeValue<Quaternion>(data[LOCAL_ROTATION_KEY]);
        }
        if (data.ContainsKey(LOCAL_SCALE_KEY))
        {
            transform.localScale = DeserializeValue<Vector3>(data[LOCAL_SCALE_KEY]);
        }
        if (data.ContainsKey(LOCAL_SAVEID_KEY))
        {
            SaveID = (string)data[LOCAL_SAVEID_KEY]; // Update the SaveID from the datas
        }
    }
}