using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : Object
{
    protected override void Start()
    {
        base.Start();
        tested = true;
        UpdateOutlineType();
    }

}
