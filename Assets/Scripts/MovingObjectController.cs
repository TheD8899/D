using UnityEngine;
using static UnityEditor.Progress;

public class MovingObjectController : MonoBehaviour
{
   /* public GameObject SkillMonter;*/
    private float speed = 4f;
    private float startX;
    private float targetX;
    private int direction = 1;
    public int maxHealth = 40;
    public int currentHealth;
    public Healthbar healthCrab;
    private Rigidbody2D rb;
    private Animator ani;
    private Player player;
    float timer = 0f;
    private CreateMonster2 createMonster2;
    public GameObject items;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x;
        targetX = startX + 2f;
        healthCrab = FindObjectOfType<Healthbar>();
        createMonster2 = FindObjectOfType<CreateMonster2>();
        ani = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthCrab.SetMaxHealth(currentHealth);
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        /*float step = speed * Time.deltaTime;

        // Di chuyển đến vị trí mục tiêu
        Vector2 newPosition = new Vector2(targetX, transform.position.y);
        rb.MovePosition(Vector2.MoveTowards(rb.position, newPosition, step));
        
*/
        Vector2 targetPosition = new Vector2(targetX, transform.position.y);
        Vector2 currentPosition = rb.position;
        // Xác định hướng di chuyển
        Vector2 moveDirection = (targetPosition - currentPosition).normalized;

        // Di chuyển với tốc độ cố định
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
        // Đổi hướng mặt
        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Hướng phải
        }
        else if (direction < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Hướng trái

        if(Mathf.Abs(rb.position.x - targetX) <= 0.1f)
        {
            direction *= -1;
            targetX = startX + direction * 2f;
        }
        
    }
    /*private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("playerrr"))
        {
            player.Checkdie();
            ani.SetTrigger("Skillcrab");
            GameObject skill1 = Instantiate(SkillMonter, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(skill1, 0.03f);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("skill1"))
        {
            TakeDamage(20);
            if (currentHealth == 0)
            {
                Destroy(gameObject);
                createMonster2.count --;
                if (createMonster2.m > 1)
                {
                     Instantiate(items, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthCrab.SetHealth(currentHealth);
    }

}

