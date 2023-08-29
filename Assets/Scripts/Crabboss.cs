using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using static UnityEditor.Progress;*/

public class Crabboss : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public int maxHealth = 40;
    public int currentHealth;
    public Healthbar healthCrab;
    private Animator ani;
    private Player player11;
    public GameObject skill12;
    public GameObject item1;
    public GameObject item2;
    private float timer = 1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player11 = FindObjectOfType<Player>();
        // healthCrab = FindObjectOfType<Healthbar>();
        ani = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthCrab.SetMaxHealth(currentHealth);
    }

    private void Update()
    {
        if (player11.Getposition() != null)
        {
            Vector3 direction = player11.Getposition() - transform.position;
            direction.Normalize();

            // Thay đổi hướng sprite dựa trên hướng di chuyển
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(5f, 5f, 1f);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(-5f, 5f, 1f);
            }

            // Tính toán vận tốc dựa trên hướng di chuyển và tốc độ di chuyển
            Vector2 velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

            // Gán vận tốc cho Rigidbody2D của quái vật
            rb.velocity = velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("playerrr"))
        {
            timer += Time.deltaTime;
            if (timer > 0.2f)
            {
                player11.Checkdie();
                ani.SetTrigger("Skillcrab");
                GameObject skill1 = Instantiate(skill12, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(skill1, 0.03f);
                timer = 0;
            }
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
                CreateItems();
                player11.Healing();
            }
        }
        if (coll.gameObject.CompareTag("skill2"))
        {
            currentHealth = 0;
            CreateItems();
            Destroy(gameObject);
            player11.Healing();
        }
    }
    private void CreateItems()
    {
        int randomIndex = Random.Range(0, 2);
        GameObject selectedObject = randomIndex == 0 ? item1 : item2;
        Vector3 playerPosition = transform.position;
        Vector3 randomPosition = playerPosition + new Vector3(Random.Range(-1f, 1f), 0.5f, 0);
        Instantiate(selectedObject, randomPosition, Quaternion.identity);
    }
    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthCrab.SetHealth(currentHealth);
    }
}
