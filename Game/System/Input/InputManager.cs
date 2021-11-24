using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private BugInputAction action;
    public BugInputAction Action{get{return action;} private set{action = value;}}

    void Awake()
    {
        action = new BugInputAction();
        action.Enable();
    }
}
