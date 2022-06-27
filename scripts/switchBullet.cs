using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBullet : MonoBehaviour
{
   
   public GameObject bullet1, bullet2;

   int whitchBulletIsOn = 1;  // hangisi  aktif

   void start ()
   {

       bullet1.gameObject.SetActive (true);
       bullet2.gameObject.SetActive (false);
   }

   public void switchbullets()
   {

       switch (whitchBulletIsOn) {
           case 1:

                whitchBulletIsOn = 2;

                bullet1.gameObject.SetActive (false);
                bullet2.gameObject.SetActive (true);
                break;

            case 2:

                whitchBulletIsOn = 1;

                bullet1.gameObject.SetActive (true);
                bullet2.gameObject.SetActive (false);
                break;

       }
   }
}
