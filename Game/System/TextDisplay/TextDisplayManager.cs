using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayManager : MonoBehaviour
{
    private IEnumerator DisplayOneLineRoutine(TextMeshProUGUI textBox, string text, float timeInterval = 0.01f)
    {
		//show text
        textBox.text = "";
        for(int x = 1; x< text.Length; ++x)
        {
            textBox.text = text.Substring(0, x) + "<color=#ffffff00>"+ text.Substring(x)+"</color>";
            yield return new WaitForSecondsRealtime(timeInterval);
        }
        textBox.text = text;
    }
}

