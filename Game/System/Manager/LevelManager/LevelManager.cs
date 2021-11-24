using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Portal portal;
    [SerializeField] private int totalBugsNeeded;
    [SerializeField] private BGMFileName bgmToPlay;
    private int bugsFixed = 0;

    void Start(){
        portal.UpdateRemainingBugs(totalBugsNeeded);
        SystemManager.instance.AudioManager.PlayMusic(bgmToPlay);
    }

    public void AddBugFixed(){
        bugsFixed += 1;
        int needed = Mathf.Max(0, totalBugsNeeded - bugsFixed);
        if(needed > 0)
            portal.UpdateRemainingBugs(needed);
        else
            portal.Activate();
    }

    public void GoToNextLevel(string sceneName){
        SystemManager.instance.LoadScene(sceneName);
    }

}
