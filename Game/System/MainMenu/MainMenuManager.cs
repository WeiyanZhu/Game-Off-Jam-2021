using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private bool canControl = true;

    void Start(){
        SystemManager.instance.AudioManager.PlayMusic(BGMFileName.MainMenu);
    }

    public void NewGameButton()
    {
        if(!canControl)
            return;
        canControl = false;

        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.UIConfirm);
        SystemManager.instance.LoadScene("Tutorial");
    }

    /*
    [Header("Language")]
    [SerializeField] private SetTextWithJSON[] mainMenuTexts;

    public void ChangeLanguageButton()
    {
        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.Interact);
        int len = System.Enum.GetNames(typeof(Language)).Length;
        //switch to the next language
        Language newLan = (Language) (((int)(SystemManager.instance.Language) + 1)%len);
        ChangeLanguage(newLan);
    }

    public void ChangeLanguage(Language lan)
    {
        if(SystemManager.instance.Language != lan)
        {
            SystemManager.instance.Language = lan;
            foreach(SetTextWithJSON t in mainMenuTexts){
                t.UpdateValue();
            }
        }
    }*/

}
