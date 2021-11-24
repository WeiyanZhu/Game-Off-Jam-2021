using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{    
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    [SerializeField] private BGMFile[] bgmFiles;
    private Dictionary<BGMFileName, AudioClip> bgmLibrary;
    [SerializeField] private SFXFile[] sfxFiles;
    private Dictionary<SFXFileName, AudioClip> sfxLibrary;
    private BGMFileName bgmPlaying = BGMFileName.None; //the BGM that is being played
    public BGMFileName BGMPlaying {get => bgmPlaying; private set => bgmPlaying = value;}

    void Awake()
    {
        InitializeLibrary();
    }

    void Start()
    {
        DOTween.Init();
    }

    //==========================================================================================
    //Play Music
    //==========================================================================================
    public void InitializeLibrary()
    {
        bgmLibrary = new Dictionary<BGMFileName, AudioClip>();
        foreach(BGMFile audioFile in bgmFiles)
        {  
            bgmLibrary.Add(audioFile.name, audioFile.clip);
        }

        sfxLibrary = new Dictionary<SFXFileName, AudioClip>();
        foreach(SFXFile audioFile in sfxFiles)
        {  
            sfxLibrary.Add(audioFile.name, audioFile.clip);
        }
    }

    public void PlaySFX(AudioClip clip, float volumeScale = 1)
    {
        sfxAudioSource.PlayOneShot(clip, volumeScale);
    }

    public void PlaySFX(SFXFileName clipName, float volumeScale = 1)
    {
        if(sfxLibrary.ContainsKey(clipName))
            PlaySFX(sfxLibrary[clipName], volumeScale);
        else
            Debug.LogError("AudioManager.PlaySFX(): " + clipName + " does not exist in the audio library.");
    }

    public void PlayMusic(AudioClip clip, bool loop = true, float volumeScale = 1)
    {
        if(clip == null)
        {
            musicAudioSource.Stop();
            musicAudioSource.clip = null;
            return;
        }
        musicAudioSource.loop = loop;
        if(!musicAudioSource.clip || musicAudioSource.clip.name != clip.name)
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(musicAudioSource.DOFade(0, 0.5f));
            mySequence.AppendCallback(()=>musicAudioSource.clip = clip);
            mySequence.AppendCallback(()=>musicAudioSource.Play());
            mySequence.Append(musicAudioSource.DOFade(volumeScale, 0.5f));
        }
    }

    public void PlayMusic(BGMFileName clipName, bool loop = true, float volumeScale = 1)
    {
        if(clipName == BGMFileName.None){
            bgmPlaying = BGMFileName.None;
            PlayMusic(null);
        }else if(bgmLibrary.ContainsKey(clipName))
        {
            bgmPlaying = clipName;
            PlayMusic(bgmLibrary[clipName], loop, volumeScale);
        }
        else
            Debug.LogError("AudioManager.PlayMusic(): " + clipName + " does not exist in the audio library.");
    }

    //==========================================================================================
    //Change/Get Mixer Values
    //==========================================================================================

    public void SetMixerVolume(string param, float value){
        float volume = Mathf.Log10(value) * 20;
        mixer.SetFloat(param, volume);
    }
}

