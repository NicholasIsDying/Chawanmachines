using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallManager : MonoBehaviour
{
    
    IDManager idManager;
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
        PeopleInAlready.Add(15);
        SpawningNextIdEntry();
    }

    void SpawningNextIdEntry()//call this when a new person is supposed to come in 
    {
        int index = Random.Range(0,4);
        if (index == 3)//25% of it being imposter
        {
            int imposterAs = Random.Range(0, 14);
            Vector3 rotation = new Vector3(ID.transform.rotation.x, spawnIDPosition.rotation.y, ID.transform.rotation.z);
            Quaternion newRotation = Quaternion.Euler(rotation);
            //spawning id and setting up the id
            GameObject idObject = Instantiate(ID, spawnIDPosition.position, newRotation);
            ID id = idObject.GetComponent<ID>();
            idManager.SetWrongId(imposterAs,id);

            //spawning entry paper and setting up the entry
            GameObject entryObject = Instantiate(Entry, spawnEntryPosition.position, newRotation);
            EntryPaper entry = entryObject.GetComponent<EntryPaper>();
            idManager.SetWrongEntry(imposterAs, entry);
        }
        else
        {
            int person = 15;//the inital value have to be outside the range from 0-14 and already part of the list so at start it will add 15 to the list
            while (PeopleInAlready.Contains(person))
            {
                person = Random.Range(0, 14);
            }
            PeopleInAlready.Add(person);

            //setting up the id 
            Vector3 rotation = new Vector3(ID.transform.rotation.x, spawnIDPosition.rotation.y, ID.transform.rotation.z);
            Quaternion newRotation = Quaternion.Euler(rotation);
            GameObject idObject = Instantiate(ID, spawnIDPosition.position, newRotation);
            ID id = idObject.GetComponent<ID>();
            idManager.SetCorrectId(person,id);

            //seting up the entry paper
            GameObject entryObject = Instantiate(Entry, spawnEntryPosition.position, newRotation);
            EntryPaper entry = entryObject.GetComponent<EntryPaper>();
            idManager.SetCorrectEntry(person, entry);
        }
    } 
}
