using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using static UnityEditor.Experimental.GraphView.GraphView;*/
/*using static UnityEditor.Progress;*/

public class Crabmove : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player11;
    public GameObject skill12;
    public GameObject items;
    float moveSpeed = 1f;
    float moveRange = 2f;
    private float startPositionX;
    public int maxHealth = 40;
    public int currentHealth;
    public Healthbar healthCrab;
    private CreateCrab createCrab;
    private Animator ani;
    void Start()
    {
        startPositionX = transform.position.x;
        player11 = FindObjectOfType<Player>();
        createCrab = FindObjectOfType<CreateCrab>();
        // healthCrab = FindObjectOfType<Healthbar>();
        ani = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthCrab.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        Vector3 newPosition = new Vector3(startPositionX + movement, transform.position.y, transform.position.z);
        newPosition.x = Mathf.Clamp(newPosition.x, startPositionX - moveRange, startPositionX + moveRange);
        transform.position = newPosition;
        if (movement > 0f)
        {
            // Hướng di chuyển sang phải
            transform.localScale = new Vector3(5f, 5f, 1f);
        }
        else if (movement < 0f)
        {
            // Hướng di chuyển sang trái
            transform.localScale = new Vector3(-5f, 5f, 1f);
        }

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("playerrr"))
        {
            player11.Checkdie();
            ani.SetTrigger("Skillcrab");
            GameObject skill1 = Instantiate(skill12, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(skill1, 0.03f);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("skill1"))
        {
            TakeDamage(20);
            if (currentHealth == 0)
            {
                Destroy(gameObject);
                createCrab.count1--;
                if (createCrab.m > 1)
                {
                    GameObject Items = Instantiate(items, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthCrab.SetHealth(currentHealth);
    }
    /*public void Die()
    {
        currentHealth = 0;
        Destroy(gameObject);
    }*/
}
