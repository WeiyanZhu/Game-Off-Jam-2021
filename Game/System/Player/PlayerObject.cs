using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : Object
{
    protected override void Start()
    {
        base.Start();
        tested = true;
        UpdateOutlineType();
    }
}
