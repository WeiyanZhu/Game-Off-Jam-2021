using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ObjectInfo{
    public string textFilePath; //json file storing the text
    public string nameKey;
    public Sprite sprite;
    public string isBugTextKey;
    public Color isBugTextColor = Color.black;
    public string descriptionKey;
    public ObjectButtonInfo[] buttons;
}

[System.Serializable]
public class ObjectButtonInfo{
    public JsonTextPath text;
    public Color color;
    public UnityEvent onClick;
}