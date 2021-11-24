using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class KitchenPot : MonoBehaviour
{
    [SerializeField] private GameObject[] possibleFoods;
    [SerializeField] private Transform generatePoint;
    [SerializeField] private float throwForce = 100;
    [SerializeField] private float angleRange = 60;
    
    [Header("For Buggy Pot")]
    [SerializeField] private bool buggyPot = false;
    [SerializeField] [ShowIf("buggyPot")] private GameObject[] possibleFoodsAfterFixed;

    // Throw a random food out of the pot
    public void Cook()
    {
        float angle = 90;
        angle += Random.Range(-angleRange/2, angleRange/2);
        float radian = Mathf.Deg2Rad * angle;
        Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
        int objIndex = Random.Range(0, possibleFoods.Length);
        GameObject objPref = possibleFoods[objIndex];
        GameObject obj = Instantiate(objPref, generatePoint.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(direction * throwForce, ForceMode2D.Impulse);

        SystemManager.instance.AudioManager.PlaySFX(SFXFileName.Cook);
    }

    public void PotBugFix(){
        possibleFoods = possibleFoodsAfterFixed;
    }
}
