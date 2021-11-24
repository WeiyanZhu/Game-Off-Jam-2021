using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public enum BGMFileName
{
    None = 0,
    MainMenu = 1,
    Tutorial = 2,
    Forest = 3,
    Sea = 4,
    Kitchen = 5,
    BuggedWorld = 6
}

public enum SFXFileName
{
    UIConfirm = 3,
    UIHover = 0,
    Eat = 1,
    UIFail = 2,
    UIViewInfo = 4,
    UICloseInfo = 5,
    Shoot = 6,
    TestExplode = 7,
    TestPass = 8,
    TestBug = 9,
    Stab = 10,
    Delete = 11,
    WarpOut = 12,
    WarpIn = 13,
    Cook = 14,
    Debug = 15,
    Teleport = 16
}

[System.Serializable]
public class BGMFile
{
    public BGMFileName name;
    public AudioClip clip;
}

[System.Serializable]
public class SFXFile
{
    public SFXFileName name;
    public AudioClip clip;
}