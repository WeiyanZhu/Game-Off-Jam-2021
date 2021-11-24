using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SystemManager.instance.AudioManager.PlayMusic(BGMFileName.None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
