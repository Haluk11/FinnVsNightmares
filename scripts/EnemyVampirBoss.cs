using UnityEngine;

public class EnemyVampirBoss : MonoBehaviour
{
    public Animator animator;
    public GameObject End;
    private PlayerController playerController;

    [SerializeField]
     public GameObject efektEnemy;

    public int health = 7;

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

        
      //  print("distanceToPlayer:" + distanceToPlayer);

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
        if(collision.CompareTag("Garlic"))
        {
            Destroy(collision.gameObject);
            health--;

            if(health <=0)
            {
                GameObject efectpum = Instantiate(efektEnemy, transform.position, Quaternion.identity);
                Destroy(efectpum, .5f);
                Destroy(gameObject);
                End.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if(collision.CompareTag("Spoon"))
        {
            Destroy(collision.gameObject);  
        }

        if(collision.tag== "Player")
        {
            Debug.Log($"{name} triggered");
            //FindObjectOfType<HealthBar>().LoseHealth(25); // zaten HealthBar classında yaptım ama bu da olur.
        }
        
    }
    void ChasePlayer()
    {
        if(transform.position.x < Character.position.x)
        {
            // sağındaysak sağına gitsin
            rigidbody2D_.velocity = new Vector2(speed,0);
            transform.localScale = new Vector2(1, 1); // sağa dön
            animator.Play("boss_attack");
        }
        else
        {
            //solundaysak sola gitsin
            rigidbody2D_.velocity = new Vector2(-speed,0);
            transform.localScale = new Vector2(-1, 1); // sola dön
            animator.Play("boss_attack");
        }
    }

    public void StopChasingPlayer()
    {
        rigidbody2D_.velocity = new Vector2(0,0);
        animator.Play("boss_idle");
    }

}

