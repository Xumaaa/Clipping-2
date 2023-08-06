using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CopyGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private ClippingPlane clippingplane;
    // Start is called before the first frame update
    void Start()
    {
        ManageGameObject(obj);
        ChangeMaterialOfChildNodes(obj, generatedObj);
        AddMeshCollider(generatedObj);
       
    }

    private static string groupName = "ObjectGroup";
    public GameObject generatedObj;

    private void ManageGameObject(GameObject o)
    {
        GameObject mixedRealitySceneContentFolder = GameObject.Find("MixedRealitySceneContent");
        GameObject groupObject = new GameObject(groupName);
        groupObject.transform.SetParent(mixedRealitySceneContentFolder.transform);
        o.transform.SetParent(groupObject.transform, false);

        generatedObj = Instantiate(o.gameObject, groupObject.transform);
        generatedObj.name = $"{o.gameObject.name}_Inside";
        generatedObj.transform.position = o.transform.position;

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

    private void ChangeMaterialOfChildNodes(GameObject originalObj, GameObject newObj)
    {
        Renderer renderer = originalObj.GetComponent<Renderer>();
        Renderer newrenderer = newObj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // handle material -> get new material
            Material material = renderer.material;
            Material newmaterial = new Material(material);
            List<string> shaderKeywords = newmaterial.shaderKeywords.ToList();
            shaderKeywords.Remove("shaderKeywords");
            newmaterial.shaderKeywords = shaderKeywords.ToArray();
            //newmaterial.SetFloat("_DirectionalLight", 0);
            newmaterial.SetInteger("_Cull", (int)UnityEngine.Rendering.CullMode.Front);
            // apply new material
            newrenderer.material = newmaterial;
        }

        if (originalObj.transform.childCount == 0) return;
        for (int i = 0; i < originalObj.transform.childCount; i++)
        {
            ChangeMaterialOfChildNodes(originalObj.transform.GetChild(i).gameObject, newObj.transform.GetChild(i).gameObject);

            // recursive call this method for sub-nodes
        }
    }

    //public void ChangeMaterial(GameObject o)
    //{

    //    Material[] materials = Resources.LoadAll<Material>("Materials");
    //    if (o != null)
    //    {
    //        Renderer renderer = o.GetComponent<Renderer>();


    //        if (renderer != null)
    //        {
    //            foreach (Material newmaterial in materials)
    //            {
    //                bool albedoMatch = CompareMaterialAlbedo(newmaterial, renderer.material);
    //                if (albedoMatch) renderer.material = newmaterial;
    //                break;
    //            }

    //        }


    //        if (o.transform.childCount == 0) return;


    //        for (int i = 0; i < o.transform.childCount; i++)
    //        {
    //            ChangeMaterial(o.transform.GetChild(i).gameObject);
    //        }
    //    }

    //}
    //bool CompareMaterialAlbedo(Material m1, Material m2)
    //{
    //    Color aldobe1 = m1.color;
    //    Color aldobe2 = m2.color;
    //    return aldobe1.Equals(aldobe2);
    //}
   


}
