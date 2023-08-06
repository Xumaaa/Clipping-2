using JetBrains.Annotations;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Schema.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInsideMaterial : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newObject = GameObject.Find($"{obj.gameObject.name}_Inside");
        
    }

    
    
}
