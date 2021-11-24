using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityEvents : MonoBehaviour
{
    public void CloseObjectInfoUI(){
        SystemManager.instance.UIManager.CloseObjectInfo();
    }
}
