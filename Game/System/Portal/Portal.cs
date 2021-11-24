using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] protected PortalObject objComponent;
    [SerializeField] protected LevelManager levelManager;
    [SerializeField] private string nextScene;
    [SerializeField] private JsonTextPath remainingBugString;
    [SerializeField] private int activatedInfoIndex = 1;
    [SerializeField] private JsonTextPath activatedString;
    [SerializeField] private Color activatedColor;
    private bool used = false;

    public void UpdateRemainingBugs(int num){
        uiText.text = remainingBugString.GetText() + " " + num;
    }

    public void Activate(){
        objComponent.ChangeInfo(activatedInfoIndex);
        uiText.text = activatedString.GetText();
        uiText.color = activatedColor;
    }

    public void Use(){
        if(used)
            return;
        used = true;
        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.Teleport);
        levelManager.GoToNextLevel(nextScene);
    }
}
