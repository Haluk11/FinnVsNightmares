using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceMouse : MonoBehaviour
{

    
    void Update()
    {
        FaceMouse();
    }
    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if(mousePos.x < 0)
        GetComponent<SpriteRenderer>().flipX = true;

        if(mousePos.x >= 0)
        GetComponent<SpriteRenderer>().flipX = false;
    }
}
