using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class JsonTextPath{
    public string filePath;
    public string textKey;

    public string GetText(){
        return SystemManager.instance.TextLibrary.GetText(filePath, textKey);
    }
}

public class SetTextWithJSON : MonoBehaviour
{
    [SerializeField] private JsonTextPath path;
    void Start()
    {
        UpdateValue();
    }

    public void UpdateValue()
    {
        GetComponent<TextMeshProUGUI>().text = path.GetText();
    }
}
