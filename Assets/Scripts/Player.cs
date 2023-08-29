using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
/*using static UnityEditor.Experimental.GraphView.GraphView;*/
public class Player : MonoBehaviour
{
    public GameObject Skill1s;
    public GameObject Skill2s;
    public Animator Yasuo;
    public float tocdo;
    private float trai_phai;
    private Rigidbody2D rb;
    public bool isfacingRight = true;
    public float highjump;
    private bool isGrounded;
    private Transform groundCheck;
    public int maxMana = 50;
    private int currentMana;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthPlayer healthBar;
    public Manabar1 ManaBar;
    public int checkpoint1;
    public int checkpoint2;
    public int checkIsfacingRight;
    private float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Yasuo = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        /*healthBar = FindObjectOfType<HealthPlayer>();
        ManaBar = FindObjectOfType<Manabar1>();*/
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentMana = 0;
        ManaBar.SetMaxMana(currentMana);
        groundCheck = transform.Find("Checkjump");
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        trai_phai = Input.GetAxis("Horizontal");
        if (trai_phai == 0)
        {
            Yasuo.SetInteger("playercheck1", -1);
        }
        else
        {
            Yasuo.SetInteger("playercheck1", 1);
        }
        /*rb.velocity = new Vector2(tocdo * trai_phai, rb.velocity.y);*/
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * highjump, ForceMode2D.Impulse);
        }
        Skill1();
        Skill2();
        if (isfacingRight)
        {
            checkIsfacingRight = 1;
        }
        if (!isfacingRight)
        {
            checkIsfacingRight = -1;
        }
        if(currentHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthBar.SetHealth(currentHealth);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(tocdo * trai_phai, rb.velocity.y);
        flip();
    }
    void flip()
    {
        if (isfacingRight && trai_phai < 0 || !isfacingRight && trai_phai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;
        }
    }
   
    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Yasuo.SetTrigger("checkskill1");
            GameObject skill1 = Instantiate(Skill1s, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(skill1, 0.05f);
        }
    }
    void Skill2()
    {
        if (currentMana >= maxMana)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Yasuo.SetTrigger("checkskill2");
                GameObject newObjectA = Instantiate(Skill2s, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                float direction = Mathf.Sign(trai_phai);
                newObjectA.GetComponent<Skillsplayer>().InitializeMovement(direction);
                currentMana = 0;
                ManaBar.SetMana(currentMana);
            }
           
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void TakeMana(int n)
    {
        currentMana += n;
        ManaBar.SetMana(currentMana);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("skillcrab"))
        {
            TakeDamage(10);
            if (currentHealth <= 0)
            {
                Yasuo.SetTrigger("checkdie");
            }
            if (currentMana < maxMana)
            {
                TakeMana(10);
            }
        }
        if (coll.gameObject.CompareTag("DeathZone"))
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
            Yasuo.SetTrigger("checkdie");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            GameObject Key1 = GameObject.FindGameObjectWithTag("key");
            if(Key1 != null) 
            {
                Destroy(Key1 );
                checkpoint1 = 1;
            }
        }
        if (collision.gameObject.CompareTag("health"))
        {
            GameObject health1 = GameObject.FindGameObjectWithTag("health");
            if (currentHealth < maxHealth && health1 != null)
            {
                currentHealth += 20;
                healthBar.SetHealth(currentHealth);
            }
            Destroy(health1);
    }
        if (collision.gameObject.CompareTag("mana"))
        {
            GameObject mana1 = GameObject.FindGameObjectWithTag("mana");
            if (currentMana < maxMana && mana1 != null)
            {
                currentMana += 10;
                ManaBar.SetMana(currentMana);
                Destroy(mana1);
            }
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            GameObject bullet1 = GameObject.FindGameObjectWithTag("bullet");
            Destroy(bullet1);
            TakeDamage(10);
            if (currentHealth <= 0)
            {
                Yasuo.SetTrigger("checkdie");
            }
            if (currentMana < maxMana)
            {
                TakeMana(10);
            }
        }
        if (collision.gameObject.CompareTag("point"))
        {
            checkpoint2 = 1;
        }
        if (collision.gameObject.CompareTag("skillboss"))
        {
            if (timer >= 3)
            {
                TakeDamage(20);
                if (currentHealth <= 0)
                {
                    Yasuo.SetTrigger("checkdie");
                }
                if (currentMana < maxMana)
                {
                    TakeMana(15);
                }
                timer = 0;
            }
        }
    }
    public void Checkdie()
    {
        if (currentHealth <= 0)
        {
            Yasuo.SetTrigger("checkdie");
        }
    }
    public void Healing()
    {
        if(currentHealth <= maxHealth) 
        {
            if(currentHealth <= maxHealth - 15)
            {
                currentHealth += 15;
            }
            else
            {
                currentHealth = maxHealth;
            }
        }
    }
    public Vector3 Getposition()
    {
        return transform.position;
    }
}