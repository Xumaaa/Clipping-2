using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterialToAsset : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        ExportMaterial(obj);
    }

    private void ExportMaterial(GameObject o)
    {
        Renderer renderer = o.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = renderer.material;
            if (!UnityEditor.AssetDatabase.Contains(material))
            {
                Material newMaterial = new Material(material);
                newMaterial.SetFloat("_DirectionalLight", 0);
                newMaterial.SetFloat("_ReflectionProbe", 0);
                newMaterial.SetFloat("_CullMode", (int)UnityEngine.Rendering.CullMode.Front);

                string path = "Assets/Materials/" + material.name + ".mat";
                UnityEditor.AssetDatabase.CreateAsset(newMaterial, path);
            }

            
        }
        if (o.transform.childCount == 0) return;

        for(int i = 0; i < o.transform.childCount; i++)
        {
            ExportMaterial(o.transform.GetChild(i).gameObject);
        }
    }
    
}
