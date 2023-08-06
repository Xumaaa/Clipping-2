using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;

public class AddMeshColliderToObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        AddMeshCollider(obj);
        
    }

    private List<Mesh> addedMeshes = new List<Mesh>();
    private void AddMeshCollider(GameObject o)
    {
        MeshFilter meshFilter = o.GetComponent<MeshFilter>();
        
        if (meshFilter != null)
        {
            Transform parent = o.transform.parent;
            Mesh mesh = meshFilter.sharedMesh;
            if (!addedMeshes.Contains(mesh))
            {
                MeshCollider meshCollider = parent.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = meshFilter.sharedMesh;
                meshCollider.convex = true;
                addedMeshes.Add(mesh);
            }

           
       
        }
        if (o.transform.childCount == 0) return;

        for (int i = 0; i < o.transform.childCount; i++)
        {
            AddMeshCollider(o.transform.GetChild(i).gameObject);
        }
    }
    
}
