using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
    public List<ID> correctIdentifcationCards;
    [Header("Lynx")]
    public Material lynxPicture;
    public Material lynxSignature;
    [Header("Leon")]
    public Material leonPicture;
    public Material leonSignature;
    [Header("Pigeon")]
    public Material pigeonPicture;
    public Material pigeonSignature;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class ID
{
    public string Name;
    public string platoonName;
    public string iDNumber;
    public Material profilePicture;
}
