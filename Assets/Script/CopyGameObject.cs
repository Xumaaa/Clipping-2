using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        ManageGameObject(obj);
    }

    private int numberOfCopies = 1;
    private static string groupName = "ObjectGroup";

    private void ManageGameObject(GameObject o)
    {
        GameObject mixedRealitySceneContentFolder = GameObject.Find("MixedRealitySceneContent");
        GameObject groupObject = new GameObject(groupName);
        groupObject.transform.SetParent(mixedRealitySceneContentFolder.transform);
        o.transform.SetParent(groupObject.transform, false);

        for(int i = 0; i<numberOfCopies; i++)
        {
            GameObject newObject = Instantiate(o.gameObject, groupObject.transform);
            newObject.name = $"{o.gameObject.name}_Inside";
            newObject.transform.position = o.transform.position;
        }
        
    }
    
    
}
