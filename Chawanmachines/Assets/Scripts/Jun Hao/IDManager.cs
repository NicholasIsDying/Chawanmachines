using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
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

    public void SetCorrectId(int random, ID id)
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
    public void SetWrongId(int random, ID id)
    {

        //this all is just to set up the id
        id.name.text = correctIdentifcationCards[random].Name;
        id.idNumber.text = correctIdentifcationCards[random].iDNumber;
        id.idPicture.GetComponent<MeshRenderer>().material = correctIdentifcationCards[random].profilePicture;
        string platoon = correctIdentifcationCards[random].platoonName;
        if (platoon == "Lynx")
        {
            id.platoonPicture.GetComponent<MeshRenderer>().material = lynxPicture;
        }
        else if (platoon == "Eagle")
        {
            id.platoonPicture.GetComponent<MeshRenderer>().material = eaglePicture;
        }
        else if (platoon == "Leon")
        {
            id.platoonPicture.GetComponent<MeshRenderer>().material = leonPicture;
        }

        
        int amountOfErrors = Random.Range(1, 5);
        List<int> index = new List<int>(amountOfErrors);
        while (amountOfErrors > 0)
        {
            index[amountOfErrors] = noReptitionLoop(index,4);
            if (index[amountOfErrors] == 0)
            {
                id.name.text = correctIdentifcationCards[NotRandom(random,15)].Name;
            }
            else if (index[amountOfErrors] == 1)
            {
                id.idNumber.text = correctIdentifcationCards[NotRandom(random, 15)].iDNumber;
            }
            else if (index[amountOfErrors] == 2)
            {
                id.idPicture.GetComponent<MeshRenderer>().material = correctIdentifcationCards[NotRandom(random, 15)].profilePicture;
            }
            else if (index[amountOfErrors] == 3)
            {
                platoon = correctIdentifcationCards[NotRandom(random, 15)].platoonName;
                if (platoon == "Lynx")
                {
                    id.platoonPicture.GetComponent<MeshRenderer>().material = lynxPicture;
                }
                else if (platoon == "Eagle")
                {
                    id.platoonPicture.GetComponent<MeshRenderer>().material = eaglePicture;
                }
                else if (platoon == "Leon")
                {
                    id.platoonPicture.GetComponent<MeshRenderer>().material = leonPicture;
                }
            }
            amountOfErrors -= 1;
        }
    }
    int noReptitionLoop(List<int> index, int max)
    {
        int notRandom = 0;
        while (index.Contains(notRandom))
        {
            notRandom = Random.Range(0, max);
        }
        return notRandom;
    }
    int NotRandom(int impostingAs, int maxOptions)
    {
        int notRandom=0;
        while(notRandom ==impostingAs)
        {
            notRandom = Random.Range(0, maxOptions);
        }
        return notRandom;
    }

    public void SetCorrectEntry(int random, EntryPaper entry)
    {
        entry.nameOfTheIndividual.text = correctIdentifcationCards[random].Name;
        entry.idNumber.text = correctIdentifcationCards[random].iDNumber;        
        string platoon = correctIdentifcationCards[random].platoonName;
        entry.platoonName.text = platoon;
        if (platoon == "Lynx")
        {
            entry.signature.GetComponent<MeshRenderer>().material = lynxSignature;
        }
        else if (platoon == "Eagle")
        {
            entry.signature.GetComponent<MeshRenderer>().material = eagleSignature;
        }
        else if (platoon == "Leon") {
            entry.signature.GetComponent<MeshRenderer>().material = leonSignature;
        } 
    }

    public void SetWrongEntry(int impostingAs, EntryPaper entry)
    {
        SetCorrectEntry(impostingAs, entry);
        int amountOfErrors = Random.Range(1, 5);
        List<int> index = new List<int>(amountOfErrors);
        while (amountOfErrors > 0)
        {
            index[amountOfErrors] = noReptitionLoop(index,3);
            if (index[amountOfErrors] == 0)
            {
                entry.nameOfTheIndividual.text = correctIdentifcationCards[NotRandom(impostingAs,15)].Name;
            }else if(index[amountOfErrors] == 1)
            {
                entry.idNumber.text = correctIdentifcationCards[NotRandom(impostingAs, 15)].iDNumber;
            }
            else if (index[amountOfErrors] == 2)
            {
                string platoon = correctIdentifcationCards[NotRandom(impostingAs, 15)].platoonName;
                entry.platoonName.text = platoon;
                if (platoon == "Lynx")
                {
                    entry.signature.GetComponent<MeshRenderer>().material = lynxSignature;
                }
                else if (platoon == "Eagle")
                {
                    entry.signature.GetComponent<MeshRenderer>().material = eagleSignature;
                }
                else if (platoon == "Leon")
                {
                    entry.signature.GetComponent<MeshRenderer>().material = leonSignature;
                }

            }
            amountOfErrors -= 1;
            
        }
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
