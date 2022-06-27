using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField]
    private Transform BulletSpawnPos;

    [SerializeField]
    private GameObject bulletPreFab;

    private float shootDelay =.42f;
    bool isShooting;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(isShooting) return;

            isShooting = true;

            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject bullet1 = Instantiate(bulletPreFab);

         bullet1.GetComponent<bullet>().StartShooting(playerController.facingRight);
         bullet1.transform.position = BulletSpawnPos.transform.position;

         Invoke("ResetShoot", shootDelay);
    }
    void ResetShoot() //delay ekleme
    {
        isShooting = false;

    }

    public void ChangeBullet(GameObject newBullet)
    {
        bulletPreFab = newBullet;
    }
}