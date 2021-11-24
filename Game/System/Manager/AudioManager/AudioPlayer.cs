using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// Made this file cause I cannot use function with Enum param in UnityEvent, unbelievable
public class AudioPlayer : MonoBehaviour
{
    enum AudioType{
        BGM,
        SFX
    }

    [SerializeField] private AudioType audioType;
    [SerializeField] [ShowIf("audioType", AudioType.BGM)] private BGMFileName bgmFile;
    [SerializeField] [ShowIf("audioType", AudioType.SFX)] private SFXFileName sfxFile;


    public void Play(){
        if(audioType == AudioType.BGM)
        {
            SystemManager.instance.AudioManager.PlayMusic(bgmFile);
        }else{
            SystemManager.instance.AudioManager.PlaySFX(sfxFile);
        }
    }
}
