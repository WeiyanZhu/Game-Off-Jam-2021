using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI isBugText;
    [SerializeField] private TextMeshProUGUI desciption;
    [SerializeField] private ObjectInfoUIButtons buttonGroup;

    public void OpenAndDisplayInfo(ObjectInfo info)
    {
        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.UIViewInfo);
        UpdateInfo(info);
        gameObject.SetActive(true);
    }

    public void SwitchAndDisplayInfo(ObjectInfo info)
    {
        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.UIViewInfo);
        UpdateInfo(info);
    }

    //called when the page is referencing to the same object, but its info changed
    public void UpdateAndDisplayInfo(ObjectInfo info)
    {
        UpdateInfo(info);
    }

    public void UpdateInfo(ObjectInfo info){
        nameText.text = SystemManager.instance.TextLibrary.GetText(info.textFilePath, info.nameKey);
        image.sprite = info.sprite;
        isBugText.text = SystemManager.instance.TextLibrary.GetText(info.textFilePath, info.isBugTextKey);
        isBugText.color = info.isBugTextColor;
        desciption.text = SystemManager.instance.TextLibrary.GetText(info.textFilePath, info.descriptionKey);
        buttonGroup.UpdateButtons(info.buttons);
    }

    public void Close(){
        gameObject.SetActive(false);
    }

    public void CloseButton(){
        Close();
        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.UICloseInfo);
    }
}
