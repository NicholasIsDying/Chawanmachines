using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    [Header("Npc")]
    public GameObject npc;
    GameObject currentNpc;
    public int numberNpc=3;

    [Header("Destination")]
    public Transform initalDestination;
    public GameObject secondDestination;
    public GameObject finalDestination;

    [Header("Ending")]
    public GameObject endingScreen;
    public TextMeshProUGUI killCount  ;
    public int killCounter=0;
    public TextMeshProUGUI letThroughCount;
    public int letThroughCounter = 0;

    private void Awake()
    {
        
        if (Instance == null) Instance = this;
        else if(Instance!=this && Instance==null)Destroy(this);

    }

    private void Start()
    {
        killCounter =0; 
        letThroughCounter = 0;
         idManager = FindObjectOfType<IDManager>();
        PeopleInAlready.Clear();
        SpawnPerson();
    }

    public void SpawnPerson()
    {
        numberNpc -= 1;
        currentNpc = Instantiate(npc, initalDestination.position, Quaternion.identity);
        currentNpc.GetComponent<NPCController>().Destination = secondDestination;
    }

    public void KillNpc()
    {
        Destroy(currentNpc);
        if (idManager.isImposter)
        {
            killCounter += 1;
        }
        if (numberNpc != 0)
        {
            SpawnPerson();
        }
        else
        {
            EndGame();
        }
    }

    public void LetNpcPass()
    {
        currentNpc.GetComponent<NPCController>().Destination = finalDestination;
        currentNpc.GetComponent<NPCController>().StartTrigger(); 
        Destroy(currentNpc, 5f);
        if (idManager.isImposter)
        {
            letThroughCounter += 1;
        }
        if (numberNpc != 0)
        {
            SpawnPerson();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        killCount.text = killCounter.ToString();
        letThroughCount.text = letThroughCounter.ToString();
        endingScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void SpawningNextIdEntry()//call this when a new person is supposed to come in 
    {
        int index = Random.Range(0,4);
        if (index==3)//25% of it being imposter
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
