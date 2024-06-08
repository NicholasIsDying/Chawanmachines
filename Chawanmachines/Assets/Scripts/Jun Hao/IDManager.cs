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

    public void SetCorrectId(int random)
    {
        //this all is just to set up the id
        id.name.text = correctIdentifcationCards[random].Name;
        id.idNumber.text = correctIdentifcationCards[random].iDNumber;
        id.idPicture.GetComponent<MeshRenderer>().material = correctIdentifcationCards[random].profilePicture;
        string platoon = correctIdentifcationCards[random].platoonName;
        if (platoon == "Lynx")
        {
            id.platoonPicture.GetComponent<MeshRenderer>().material = lynxPicture;
        } else if (platoon == "Eagle")
        {
            id.platoonPicture.GetComponent<MeshRenderer>().material = eaglePicture;
        } else if (platoon == "Leon")
        {
            id.platoonPicture.GetComponent<MeshRenderer>().material = leonPicture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class IDData
{
    public string Name;//name of the person
    public string platoonName;//name of the platoon that the person is in
    public string iDNumber;//ID number of the person
    public Material profilePicture;//picture of the person
}
