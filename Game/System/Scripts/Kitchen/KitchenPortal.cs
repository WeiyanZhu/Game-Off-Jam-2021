using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPortal : Portal
{
    [SerializeField] private int afterHackIndex;
    public void Hack()
    {
        objComponent.ChangeInfo(afterHackIndex);
        levelManager.AddBugFixed();
        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.Debug);
    }
}
