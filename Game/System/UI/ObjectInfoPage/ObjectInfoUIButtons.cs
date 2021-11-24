using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInfoUIButtons : MonoBehaviour
{
    [SerializeField] private GameObject buttonPref;
    private List<GameObject> buttons = new List<GameObject>();

    public void UpdateButtons(ObjectButtonInfo[] buttonInfo)
    {
        ResizeButtons(buttonInfo.Length);
        foreach(GameObject button in buttons){
            button.SetActive(false);
        }

        for(int i = 0; i < buttonInfo.Length; ++i){
            ObjectButtonInfo info = buttonInfo[i];
            GameObject button = buttons[i];
            button.GetComponent<Image>().color = info.color;
            button.GetComponent<Button>().onClick.RemoveAllListeners();
            button.GetComponent<Button>().onClick.AddListener(()=>info.onClick.Invoke());
            button.GetComponentInChildren<TextMeshProUGUI>().text = info.text.GetText();
            button.SetActive(true);
        }
    }

    private void ResizeButtons(int targetSize){
        while(buttons.Count < targetSize){
            buttons.Add(Instantiate(buttonPref, transform));
        }
    }
}
