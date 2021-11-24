using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    English,
    Chinese
}

public class JSONLibrary : MonoBehaviour
{
    protected Dictionary<Language, string> languageToTextDict = new Dictionary<Language, string>(){
        {Language.English, "English"},
        {Language.Chinese, "Chinese"}
    };
}
