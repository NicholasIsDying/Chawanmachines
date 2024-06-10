using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string content;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> speakerLines;
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
    public Dialogue[] firstDialogue;


    public void FirstDialogue()
    {
        int indexe = Random.Range(0, 3);
        DialogueManager.Instance.StartDialogue(firstDialogue[indexe]);
    }
}