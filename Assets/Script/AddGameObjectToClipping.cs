using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddGameObjectToClipping : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private ClippingPlane clipping;
    // Start is called before the first frame update
    void Start()
    {
        GetRendererRecursive(obj);
    }

    private void GetRendererRecursive(GameObject o)
    {
        var renderer = o.GetComponent<MeshRenderer>();
        if (renderer != null) 
            clipping.AddRenderer(renderer);

        if (o.transform.childCount == 0) return;

        for (int i = 0; i < o.transform.childCount; i++)
        {
            GetRendererRecursive(o.transform.GetChild(i).gameObject);
        }
    }

    
    
}
