using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingBullet : Projectile
{
    [SerializeField] protected float lifeSpan;
    [SerializeField] private float particalEffectZ = -3; 
    [SerializeField] protected GameObject normalParticalEffect; //when the bullet hit a non-object and explode
    [SerializeField] protected GameObject passParticalEffect;
    [SerializeField] protected GameObject bugParticalEffect;
    private float sfxVolume = 1;

    public void SetVolume(float value){
        sfxVolume = value;
    }

    public override void Launch(Vector2 direction)
    {
        rigid.velocity = direction * speed;
        Destroy(gameObject, lifeSpan);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Object obj = col.gameObject.GetComponent<Object>();
        Vector3 contactPos = col.contacts[0].point;
        contactPos.z = particalEffectZ;
        if(obj){
            GameObject particalEffect = obj.IsBug? bugParticalEffect : passParticalEffect;
            Instantiate(particalEffect, contactPos, Quaternion.identity);
            SFXFileName sfxToPlay = obj.IsBug? SFXFileName.TestBug : SFXFileName.TestPass;
            SystemManager.instance.AudioManager.PlaySFX(sfxToPlay, sfxVolume);
            try{
                obj.Test();
            }catch(System.Exception e){
                Debug.LogError(obj.gameObject.name + ": " + e.Message);
            }
        }else{
            Instantiate(normalParticalEffect, contactPos, Quaternion.identity);
            SystemManager.instance.AudioManager.PlaySFX(SFXFileName.TestExplode, sfxVolume);
        }
        Destroy(gameObject);
    }
}
