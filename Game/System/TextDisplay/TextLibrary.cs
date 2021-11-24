using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLibrary : JSONLibrary
{
	private Dictionary<string, Dictionary<string, string>> textData = new Dictionary<string, Dictionary<string, string>>(); 
	
	//Load a dialogue data from JSON file, and store it in the dictionary
	public string GetText(string filePath, string key)
	{
        string fullPath = GetFullPath(filePath);
		if(!textData.ContainsKey(fullPath))
		{
            LoadTextJson(fullPath);
		}
		return textData[fullPath][key];
	}

    private void LoadTextJson(string path)
    {
        //read the json file to text
        try{
            string jsonData = Resources.Load<TextAsset>(path).text;
            TextFileData textFileData = JsonUtility.FromJson<TextFileData>(jsonData);
            textData.Add(path, TextDataToDict(textFileData));
        }catch{
            Debug.LogError("Fail to load file: " + path);
        }
    }

    private Dictionary<string, string> TextDataToDict(TextFileData textData)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        foreach(TextInfo textInfo in textData.textInfos)
        {
            result.Add(textInfo.key, textInfo.content);
        }
        return result;
    }

    private string GetFullPath(string relativePath)
    {
        string result = "Text/";
        result += languageToTextDict[SystemManager.instance.Language] + "/";
        result += relativePath;
        return result;
    }

}

[System.Serializable]
public class TextFileData
{
    public TextInfo[] textInfos;
}

[System.Serializable]
public class TextInfo
{
    public string key;
    public string content;
}
