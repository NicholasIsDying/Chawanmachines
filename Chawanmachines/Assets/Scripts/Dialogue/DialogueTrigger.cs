using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
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
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}