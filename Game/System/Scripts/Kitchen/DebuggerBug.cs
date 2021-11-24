using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerBug : MonoBehaviour
{
    public enum ShootPattern{
        RandomDirection,
        ShootPlayer
    }

    [SerializeField] private GameObject bulletPreb;
    [SerializeField] private float bulletZ;
    [SerializeField] private float shootInterval;
    [SerializeField] private ShootPattern shootPattern;
    [SerializeField] private float sfxVolume = 0.05f;
    private float timer;
    [SerializeField] private Collider2D col;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > shootInterval){
            timer -= shootInterval;
            CheckShoot();
        }
    }

    private void CheckShoot(){
        Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction;
        if(shootPattern == ShootPattern.RandomDirection)
        {
            float radian = Random.Range(0, 6.28f);
            direction = (new Vector2(Mathf.Cos(radian), Mathf.Sin(radian))).normalized;
        }else{
            Vector2 playerPos = GameObject.FindObjectOfType<PlayerController>().transform.position;
            direction = (playerPos - startPos).normalized;
        }
        GameObject bullet = Instantiate(bulletPreb, new Vector3(startPos.x, startPos.y, bulletZ), Quaternion.identity);
        Physics2D.IgnoreCollision(col, bullet.GetComponent<Collider2D>());
        bullet.GetComponent<TestingBullet>().SetVolume(sfxVolume);
        bullet.GetComponent<TestingBullet>().Launch(direction);
    }
}
