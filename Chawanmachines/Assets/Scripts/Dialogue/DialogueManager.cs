
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    IDManager idmanager;
    public TextMeshProUGUI dialogueArea;

    public Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.5f;

    public GameObject dialogueBox;
    public GameObject continueBox;

    //public Animator animator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    [Header("Dialogue Settings")]
    public Dialogue dialogue;

    [Header("Speaker Names Settings")]
    public SpeakerNames speakerNames;

    [Header("Preset IDs Settings")]
    public PresetIDs presetIDs;

    private void Start()
    {
        idmanager = FindObjectOfType<IDManager>();
        /*AssignRandomNames();
        AssignRandomIDs();
        StartCoroutine(DisplayDialogue());*/
    }

    private void ReplaceName(Dialogue dialogue)
    {
        Dictionary<string, string> namePlaceholders = new Dictionary<string, string>();

        for (int i = 0; i < dialogue.speakerLines.Count; i++)
        {
            foreach (var placeholder in GetPlaceholders(dialogue.speakerLines[i].content))
            {
                if (!namePlaceholders.ContainsKey(placeholder))
                {
                    namePlaceholders[placeholder] = idmanager.nameOfIndividual;
                }
            }

            foreach (var placeholder in namePlaceholders.Keys)
            {
                dialogue.speakerLines[i].content = dialogue.speakerLines[i].content.Replace(placeholder, namePlaceholders[placeholder]);
                Debug.Log("name placeholder switched");
            }
        }
    }


    private void ReplaceIDs(Dialogue dialogue)
    {
        print("yes");
        Dictionary<string, string> idPlaceholders = new Dictionary<string, string>();

        for (int i = 0; i < dialogue.speakerLines.Count; i++)
        {
            foreach (var placeholder in GetIdPlaceholders(dialogue.speakerLines[i].content))
            {
                if (!idPlaceholders.ContainsKey(placeholder))
                {

                    idPlaceholders[placeholder] = idmanager.idOfTheIndividual;
                }
            }

            foreach (var placeholder in idPlaceholders.Keys)
            {
                dialogue.speakerLines[i].content = dialogue.speakerLines[i].content.Replace(placeholder, idPlaceholders[placeholder]);
                Debug.Log("id placeholder switched");
            }
        }
    }


    /*private void AssignRandomIDs()
    {
        foreach (var line in dialogue.speakerLines)
        {
            *//*if (line.content.Contains("{id}"))
            {
                string randomID = GenerateRandomID();
                line.content = line.content.Replace("{id}", randomID);
                Debug.Log(line.content);
            }*//*

            string randomID = GenerateRandomID();
            line.content = line.content.Replace("[id]", randomID);
            Debug.Log(line.content);
            print(randomID);

        }
    }

    private string GenerateRandomID()
    {
        return System.Guid.NewGuid().ToString(); // Generate a random unique identifier

    }*/

    private IEnumerable<string> GetPlaceholders(string content)
    {
        var placeholders = new List<string>();
        int startIndex = 0;

        while ((startIndex = content.IndexOf('{', startIndex)) != -1)
        {
            int endIndex = content.IndexOf('}', startIndex);
            if (endIndex != -1)
            {
                string placeholder = content.Substring(startIndex, endIndex - startIndex + 1);
                placeholders.Add(placeholder);
                startIndex = endIndex + 1;
            }
            else
            {
                break;
            }
        }

        return placeholders;
    }

    private IEnumerable<string> GetIdPlaceholders(string content)
    {
        var placeholders = new List<string>();
        int startIndex = 0;

        while ((startIndex = content.IndexOf('[', startIndex)) != -1)
        {
            int endIndex = content.IndexOf(']', startIndex);
            if (endIndex != -1)
            {
                string placeholder = content.Substring(startIndex, endIndex - startIndex + 1);
                placeholders.Add(placeholder);
                startIndex = endIndex + 1;
                print(placeholder);
            }
            else
            {
                break;
            }
        }

        return placeholders;
    }

    /*private IEnumerator DisplayDialogue()
    {
        /*foreach (var dialogueLine in dialogue.speakerLines)
        {
            Debug.Log(dialogueLine.content);
            isDialogueActive = true;
            lines.Enqueue(dialogueLine);
            yield return new WaitForSeconds(2); // Wait for 2 seconds before showing the next line
        }
        foreach (DialogueLine dialogueLine in dialogue.speakerLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
        yield return new WaitForSeconds(2);
    }*/


    //play dialogue function
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        dialogueBox.SetActive(true);
        continueBox.SetActive(true);
        //animator.Play("show");

        lines.Clear();

        Dialogue temp = dialogue.Copy();

        ReplaceIDs(temp);
        ReplaceName(temp);


        foreach (DialogueLine dialogueLine in temp.speakerLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        Debug.Log("button pressed");

        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();
        

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.content.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        continueBox.SetActive(false);
        isDialogueActive = false;
        //animator.Play("hide");
    }
}