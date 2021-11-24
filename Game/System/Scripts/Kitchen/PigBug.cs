using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PigBug : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TextMeshProUGUI textComponent;
    private bool dialogueTriggered = false;
    [SerializeField] private JsonTextPath[] dialogues;

    public void ShowDialogue(){
        if(dialogueTriggered == false)
        {
            DisplayText(0);
            dialogueCanvas.SetActive(true);
            dialogueTriggered = true;
        }
    }

    public void CloseDialogue(){
        dialogueCanvas.SetActive(false);
    }

    public void DisplayText(int index){
        textComponent.text = dialogues[index].GetText();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowDialogue();
    }
}
