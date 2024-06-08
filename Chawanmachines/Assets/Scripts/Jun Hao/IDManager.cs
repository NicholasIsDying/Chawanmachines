using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
    public ID id;
    public List<IDData> correctIdentifcationCards;
    [Header("Lynx")]
    public Material lynxPicture;
    public Material lynxSignature;
    [Header("Leon")]
    public Material leonPicture;
    public Material leonSignature;
    [Header("Pigeon")]
    public Material eaglePicture;
    public Material eagleSignature;

    [Header("Current Date")]
    public int Year,month;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetId()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class IDData
{
    public string Name;
    public string platoonName;
    public string iDNumber;
    public Material profilePicture;
}
