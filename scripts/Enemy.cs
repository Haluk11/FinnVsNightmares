using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    private PlayerController playerController;

    private HealthBar healthBar;

    [SerializeField]
     public GameObject efektEnemy;

    private int health = 4;

   // [SerializeField]
   // GameObject kurt;

    [SerializeField]
    Transform Character;

    [SerializeField]
    float Range;

    [SerializeField]
    float speed;

    Rigidbody2D rigidbody2D_;

    private void Reset()
    {
        Init();
    }
    void Init()
    {
        
    }
   
    void Start()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Character)
        {
        // karaktere uzaklığı
        float distanceToPlayer = Vector2.Distance(transform.position, Character.position);

        // chase seysi
        if(distanceToPlayer < Range)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Spoon"))
        {
            Destroy(collision.gameObject);
            health--;

            if(health <=0)
            {
                GameObject efectpum = Instantiate(efektEnemy, transform.position, Quaternion.identity);
                Destroy(efectpum, .5f);
                Destroy(gameObject);
            }
        }
        else if(collision.CompareTag("Garlic"))
        {
            Destroy(collision.gameObject);  
        }

        if(collision.tag == "Player")
        {
            Debug.Log($"{name} triggered");
            //FindObjectOfType<HealthBar>().LoseHealth(25); // zaten HealthBar classında yaptım ama bu da olur.
        }
        
    }
    void ChasePlayer()
    {
        if(transform.position.x < Character.position.x) 
        {
            //if(FindObjectOfType<HealthBar>().health <=0) return;
            // sağındaysak sağına gitsin
            rigidbody2D_.velocity = new Vector2(speed,0);
            transform.localScale = new Vector2(1, 1); // sağa dön
            animator.Play("kurt_attack");
            
        }
        else
        {
            //if(FindObjectOfType<HealthBar>().health <=0) return;
            //solundaysak sola gitsin
            rigidbody2D_.velocity = new Vector2(-speed,0);
            transform.localScale = new Vector2(-1, 1); // sola dön
            animator.Play("kurt_attack");
            
        }
    }

    public void StopChasingPlayer()
    {
        rigidbody2D_.velocity = new Vector2(0,0);
        animator.Play("kurt_idle");
    }

}
