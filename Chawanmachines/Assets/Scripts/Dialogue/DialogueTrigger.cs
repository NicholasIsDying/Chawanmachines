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

    private void Start()
    {
        IdManager = FindObjectOfType<IDManager>();
    }

    public void FirstDialogue()
    {
        int indexe = Random.Range(0, 3);
        DialogueManager.Instance.StartDialogue(firstDialogue[indexe]);
    }
    public void IntroDialogue()
    {
        DialogueManager.Instance.StartDialogue(introductionDIalogue);
    }
    public void ID()
    {
        if (IdManager.isThereMistakeOnId == false)
        {

        }else if(IdManager.isThereMistakeOnId == true)
        {

        }
    }

    public void Name()
    {

    }

    public void EntryLog()
    {

    }
}