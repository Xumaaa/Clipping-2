using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponentToGameObject : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        AddComponent(obj);
    }

    private void AddComponent(GameObject o)
    {
        if(o.GetComponent<ObjectManipulator>() == null)
        {
            o.AddComponent<ObjectManipulator>();
        }
        if (o.GetComponent<NearInteractionGrabbable>() == null)
        {
            o.AddComponent<NearInteractionGrabbable>();
        }
    }
}
