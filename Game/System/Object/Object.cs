using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum OutlineType{
    UnKnown,
    Pass, 
    Bug
}

public class Object : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ObjectOutline objectOutline;
    [Header("Info")]
    [SerializeField] private ObjectInfo[] potentialInfos;
    private int currentInfo;
    [SerializeField] private int initialInfoIndex = 0;
    [Header("Testing")]
    protected bool tested = false;
    [SerializeField] private UnityEvent testEvent; //called when shot by a testing bullet
    [SerializeField] private bool isBug;
    public bool IsBug { get => isBug; private set => isBug = value;}
    

    protected virtual void Start()
    {
        currentInfo = initialInfoIndex;
    }

    public void ChangeInfo(int index)
    {
        currentInfo = index;
        if(SystemManager.instance.UIManager.ObjectShowing == this)
            SystemManager.instance.UIManager.UpdateObjectInfo(this);
    }

    public ObjectInfo GetInfo(){
        return potentialInfos[currentInfo];
    }

    public void Test()
    {
        if(!tested){
            tested = true;
            testEvent.Invoke();
            UpdateOutlineType();
        }
    }

    public void ChangeIsBug(bool value)
    {
        isBug = value;
    }

    public void UpdateOutlineType()
    {
        if(!tested)
            objectOutline.ChangeOutlineType(OutlineType.UnKnown);
        else if(isBug)
            objectOutline.ChangeOutlineType(OutlineType.Bug);
        else
            objectOutline.ChangeOutlineType(OutlineType.Pass);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
            SystemManager.instance.UIManager.DisplayObjectInfo(this);
    }

    public void AddBugFixed(){
        GameObject.FindObjectOfType<LevelManager>().AddBugFixed();
    }

    //turn an bug object to fixed object
    public void BugFix(){
        ChangeIsBug(false);
        UpdateOutlineType();
        AddBugFixed();
    }
}
