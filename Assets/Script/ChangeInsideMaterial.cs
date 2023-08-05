using JetBrains.Annotations;
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
        ChangeMaterial(obj);
    }
    public void ChangeMaterial(GameObject o)
    {
        GameObject newObject = GameObject.Find($"{o.gameObject.name}_Inside");
        Material[] materials = Resources.LoadAll<Material>("Materials/");
        if ( newObject != null )
        {
            Renderer renderer = newObject.GetComponent<Renderer>();


            if (renderer != null)
            {
                foreach(Material material in materials)
                {
                    bool albedoMatch = CompareMaterialAlbedo(material, renderer.material);
                    if ( albedoMatch ) renderer.material = material;
                }
               
            }
            else
            {
                Debug.LogWarning("Renderer component not found on the new model!");
            }

            if (newObject.transform.childCount == 0) return;
            

            for (int i = 0; i < newObject.transform.childCount; i++)
            {
                ChangeMaterial(newObject.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            Debug.LogWarning("The new model object is null!");
        }
    }
    bool CompareMaterialAlbedo(Material m1, Material m2)
    {
        Color aldobe1 = m1.color;
        Color aldobe2 = m2.color;
        return aldobe1.Equals(aldobe2);
    }
}
