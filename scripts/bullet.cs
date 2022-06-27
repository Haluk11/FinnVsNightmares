using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    Rigidbody2D rb2d;

    [SerializeField]
    float speed ;

    [SerializeField]
     int damage;

     public GameObject efekt;

    public void StartShooting(bool isFacingLeft)
    {
        rb2d = GetComponent<Rigidbody2D>();

        if(isFacingLeft)
        {
            rb2d.velocity = (new Vector2(speed,0));
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            rb2d.velocity = (new Vector2(-speed,0));
        }

        Invoke("destroySelf", .99f); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("herhangi"))
        {
        GameObject efectpum = Instantiate(efekt, transform.position, Quaternion.identity);
        Destroy(efectpum,.5f);
        SoundManager.playkek();
        destroySelf();
        }
        else if(collision.CompareTag("enemykurt"))
        {
        GameObject efectpum = Instantiate(efekt, transform.position, Quaternion.identity);
        Destroy(efectpum,.5f);
        SoundManager.playkek();
        destroySelf();
        }
        else if(collision.CompareTag("enemyvampir"))
        {
        GameObject efectpum = Instantiate(efekt, transform.position, Quaternion.identity);
        Destroy(efectpum,.5f);
        SoundManager.playkek();
        destroySelf();
        }

    }
    
    private void destroySelf()
    {
        Destroy(gameObject);
    }
}
