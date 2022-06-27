using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
     public GameObject efektEnemy;

    public Image fillBar;

    // bar 0 ile 1 arasında işliyo 
    // eğerki 100 candan ilerliceksek 100 e bölücez
    public float health;

    public void LoseHealth(int HealthValue)
    {
        // zaten 0 sa
        if(health <=0) return;

        // can azaltma olayı
        health -= HealthValue;

        // barı sıfırla
        fillBar.fillAmount = health / 100;
        // 0 a indimi kontrol 
        if(health <=0)
        {
            Debug.Log("u died");
            Destroy(gameObject);
            FindObjectOfType<PlayerController>().Die();
        }
    }
    // düşmana çarparsa gebersin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemykurt"))
        {
            LoseHealth(25);
            
            if(health <=0)
            {
                GameObject efectpum = Instantiate(efektEnemy, transform.position, Quaternion.identity);
                Destroy(efectpum, .5f);
                Destroy(gameObject);
            }
        }
        else if(collision.CompareTag("enemyvampir"))
        {
            LoseHealth(25);

            if(health <=0)
            {
                GameObject efectpum = Instantiate(efektEnemy, transform.position, Quaternion.identity);
                Destroy(efectpum, .5f);
                Destroy(gameObject);
            }
        }
    }
}
