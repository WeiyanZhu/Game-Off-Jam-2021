using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{
    [SerializeField] private ObjectInfoUI objectInfoUI;
    private Object objectShowing = null;
    public Object ObjectShowing{get => objectShowing; private set => objectShowing = value;}

    public void DisplayObjectInfo(Object objectShowing)
    {
        //if we are already viewing this object
        if(this.objectShowing == objectShowing && objectInfoUI.gameObject.activeSelf)
            return;
        this.objectShowing = objectShowing;
        //open the page or switch to display a different object
        if(objectInfoUI.gameObject.activeSelf){
            objectInfoUI.SwitchAndDisplayInfo(objectShowing.GetInfo());
        }else{
            objectInfoUI.OpenAndDisplayInfo(objectShowing.GetInfo());
        }
    }

    //When the objectShowing is not changed, but its info is changed, update the UI to reflect the change
    public void UpdateObjectInfo(Object objectShowing){
        if(this.objectShowing == objectShowing)
            objectInfoUI.UpdateAndDisplayInfo(objectShowing.GetInfo());
    }

    public void CloseObjectInfo(){
        objectInfoUI.Close();
    }
}
