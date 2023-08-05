using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyClippingPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject clipping;
    // Start is called before the first frame update
    void Start()
    {
        CopyPlane(clipping);
    }

    private int numberOfCopies = 1;
    private static string groupName = "Clipping";
    
    private void CopyPlane(GameObject plane)
    {
        GameObject mixedRealitySceneContentFolder = GameObject.Find("MixedRealitySceneContent");
        GameObject groupObject = new GameObject(groupName);
        groupObject.transform.SetParent(mixedRealitySceneContentFolder.transform);
        plane.transform.SetParent(groupObject.transform,false);
        for(int i = 0; i < numberOfCopies; i++)
        {
            GameObject newPlane = Instantiate(plane.gameObject, groupObject.transform);
            newPlane.name = "clippingPlane_2";
            newPlane.transform.position = plane.transform.position;
            newPlane.transform.rotation = plane.transform.rotation;
        }
    }
    
}
