using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallManager : MonoBehaviour
{
    
    IDManager idManager;
    public DialogueManager dialogueManager;
    public static OverallManager Instance;
    public List<int> PeopleInAlready=new List<int>();
    public GameObject ID;
    public GameObject Entry;
    public Transform spawnIDPosition;
    public Transform spawnEntryPosition;


    private void Awake()
    {
        
        if (Instance == null) Instance = this;
        else if(Instance!=this && Instance==null)Destroy(this);

    }

    private void Start()
    {
        idManager = FindObjectOfType<IDManager>();
        PeopleInAlready.Clear();
        SpawningNextIdEntry();
    }

    void SpawningNextIdEntry()//call this when a new person is supposed to come in 
    {
        int index = Random.Range(0,4);
        if (index> 1)//25% of it being imposter
        {
            idManager.isImposter = true;
            int imposterAs = Random.Range(0, 14);      
            Quaternion newRotation = Quaternion.Euler(ID.transform.eulerAngles.x, spawnIDPosition.eulerAngles.y, ID.transform.eulerAngles.z);

            int chance = Random.Range(0, 3);
            //if it is 1 then only the id has the error, if it is 2 then only the entry has the error, if chance is 2 then both have errors
            if (chance == 1)
            {
                //spawning id and setting up the id
                GameObject idObject = Instantiate(ID, spawnIDPosition.position, newRotation);
                ID id = idObject.GetComponent<ID>();
                idManager.SetWrongId(imposterAs, id);
                 newRotation = Quaternion.Euler(Entry.transform.eulerAngles.x, spawnIDPosition.eulerAngles.y, Entry.transform.eulerAngles.z);
                GameObject entryObject = Instantiate(Entry, spawnEntryPosition.position, newRotation);
                EntryPaper entry = entryObject.GetComponent<EntryPaper>();
                idManager.SetCorrectEntry(imposterAs, entry);

            }
            else if (chance == 0)
            {
                GameObject idObject = Instantiate(ID, spawnIDPosition.position, newRotation);
                ID id = idObject.GetComponent<ID>();
                idManager.SetCorrectId(imposterAs, id);
                
                newRotation = Quaternion.Euler(Entry.transform.eulerAngles.x, spawnIDPosition.eulerAngles.y, Entry.transform.eulerAngles.z);
                //spawning entry paper and setting up the entry
                GameObject entryObject = Instantiate(Entry, spawnEntryPosition.position, newRotation);
                EntryPaper entry = entryObject.GetComponent<EntryPaper>();
                idManager.SetWrongEntry(imposterAs, entry);
            }
            else if (chance == 2)
            {
                //spawning id and setting up the id
                GameObject idObject = Instantiate(ID, spawnIDPosition.position, newRotation);
                ID id = idObject.GetComponent<ID>();
                idManager.SetWrongId(imposterAs, id);
                newRotation = Quaternion.Euler(Entry.transform.eulerAngles.x, spawnIDPosition.eulerAngles.y, Entry.transform.eulerAngles.z);
                //spawning entry paper and setting up the entry
                GameObject entryObject = Instantiate(Entry, spawnEntryPosition.position, newRotation);
                EntryPaper entry = entryObject.GetComponent<EntryPaper>();
                idManager.SetWrongEntry(imposterAs, entry);
            }
        }
        else//this is the not imposter
        {
            idManager.isImposter = false;
            int person = Random.Range(0, 14);
            while (PeopleInAlready.Contains(person))//will randomly
            {
                person = Random.Range(0, 14);
            }
            PeopleInAlready.Add(person);

            Quaternion newRotation = Quaternion.Euler(ID.transform.eulerAngles.x, spawnIDPosition.eulerAngles.y, ID.transform.eulerAngles.z);
            //setting up the id             
            GameObject idObject = Instantiate(ID, spawnIDPosition.position, newRotation);
            ID id = idObject.GetComponent<ID>();
            idManager.SetCorrectId(person, id);
            newRotation = Quaternion.Euler(Entry.transform.eulerAngles.x, spawnIDPosition.eulerAngles.y, Entry.transform.eulerAngles.z);
            //seting up the entry paper
            GameObject entryObject = Instantiate(Entry, spawnEntryPosition.position, newRotation);
            EntryPaper entry = entryObject.GetComponent<EntryPaper>();
            idManager.SetCorrectEntry(person, entry);


        }
    } 
}
