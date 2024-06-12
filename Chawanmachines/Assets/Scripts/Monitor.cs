using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] GameObject[] monitorPages = new GameObject[8];
    int monitorMaterialIndex;

    // Start is called before the first frame update
    void Start()
    {
        monitorMaterialIndex = 0;
        monitorPages[monitorMaterialIndex].SetActive(true);
        //int i = 0; i < monitorMaterials.Length; i++
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Material Index" + monitorMaterialIndex);

    }

    public void NextPage()
    {
        
       if (monitorPages[monitorMaterialIndex].activeInHierarchy && monitorMaterialIndex >= 0 && monitorMaterialIndex <=6)
        {
            monitorPages[monitorMaterialIndex].SetActive(false);
            monitorMaterialIndex++;
            monitorPages[monitorMaterialIndex].SetActive(true);
        }
    }

    public void BackPage()
    {
        
        if (monitorPages[monitorMaterialIndex].activeInHierarchy && monitorMaterialIndex >= 1)
        {
            monitorPages[monitorMaterialIndex].SetActive(false);
            monitorMaterialIndex--;
            monitorPages[monitorMaterialIndex].SetActive(true);
        }
    }
}
