using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string content;
    public DialogueLine Copy()
    {
        DialogueLine copy = new DialogueLine();
        copy.content = this.content;
        return copy;
    }
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> speakerLines;

    public Dialogue Copy()
    {
        Dialogue copy = new Dialogue();
        copy.speakerLines = new List<DialogueLine>();
        for(int i =0; i < speakerLines.Count; i++)
        {
            copy.speakerLines.Add(speakerLines[i].Copy());
        }
        return copy;
    }

}

[System.Serializable]
public class SpeakerNames
{
    public List<string> names;
}

[System.Serializable]
public class PresetIDs
{
    public List<string> ids;
}

public class DialogueTrigger : MonoBehaviour
{
    IDManager IdManager;
    public Dialogue[] firstDialogue;

    public Dialogue introductionDIalogue;

    public Dialogue[] correctName;    
    public Dialogue[] wrongName;

    public Dialogue[] correctId;
    public Dialogue[] wrongId;

    public Dialogue[] entryCorrect;
    public Dialogue[] entryWrong;

    public Dialogue[] idRegardless;

    private void Start()
    {
        IdManager = FindObjectOfType<IDManager>();
    }

    public void FirstDialogue()
    {
        int indexe = Random.Range(0, firstDialogue.Length);
        DialogueManager.Instance.StartDialogue(firstDialogue[indexe]);
    }
    public void IntroDialogue()
    {
        DialogueManager.Instance.StartDialogue(introductionDIalogue);
    }
    public void ID()//the npc will say out the name that he is supposed to be imposting as
    {
        if (IdManager.isThereMistakeOnId == false)
        {
            int indexe = Random.Range(0, correctId.Length);
            DialogueManager.Instance.StartDialogue(correctId[indexe]);
        }
        else if(IdManager.isThereMistakeOnId == true)
        {
            int indexe = Random.Range(0, wrongId.Length);
            DialogueManager.Instance.StartDialogue(wrongId[indexe]);
        }
    }

    public void Name()
    {
        if (IdManager.isThereMistakeOnName == false)//no mistake
        {
            int indexe = Random.Range(0, correctName.Length);
            DialogueManager.Instance.StartDialogue(correctName[indexe]);
        }else if (IdManager.isThereMistakeOnName == true)//have mistakes
        {
            int indexe = Random.Range(0, wrongName.Length);
            DialogueManager.Instance.StartDialogue(wrongName[indexe]);
        }
    }

    public void EntryLog()
    {
        if (IdManager.isEntryWrong == true)
        {
            int indexe = Random.Range(0, entryWrong.Length);
            DialogueManager.Instance.StartDialogue(entryWrong[indexe]);
        }
        else if(IdManager.isEntryWrong == false)
        {
            int indexe = Random.Range(0, entryCorrect.Length);
            DialogueManager.Instance.StartDialogue(entryCorrect[indexe]);
        }
    }

    public void IdRegardless()
    {
        int indexe = Random.Range(0, idRegardless.Length);
        DialogueManager.Instance.StartDialogue(idRegardless[indexe]);
    }
}