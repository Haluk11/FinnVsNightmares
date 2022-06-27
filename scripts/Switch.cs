using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField] public Image Spoonn;
    [SerializeField] public Image Garlicc;


    [SerializeField] private GameObject Spoon;
    [SerializeField] private GameObject Garlic;

    Shoot playerShootScript;
    void Start()
    {
        playerShootScript = GetComponent<Shoot>();
    }
    
    void Update()
    {
        if      (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(2);
        }
    }

    void SetWeapon(int weaponID)
    {
        switch(weaponID)
        {
            case 1:
                playerShootScript.ChangeBullet(Spoon);
                Spoonn.enabled  = true;
                Garlicc.enabled = false;
                break;
            case 2:
                playerShootScript.ChangeBullet(Garlic);
                Spoonn.enabled  = false;
                Garlicc.enabled = true;
                break;
        }
    }
}
