using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFollowPlayer : MonoBehaviour
{
   public float valueX = 0;
    public float valueY = 0;
    public float valueZ = 0;

    public Transform targetPlayer;

    void Update()
    {
        transform.position = new Vector3(targetPlayer.transform.position.x + valueX, targetPlayer.transform.position.y + valueY, valueZ);
    }
}