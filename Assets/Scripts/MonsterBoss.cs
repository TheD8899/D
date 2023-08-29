using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SkillMonter;
    private float speed = 4f;
    public int maxHealth = 40;
    public int currentHealth;
    public Healthbar healthCrab;
    private Rigidbody2D rb;
    private Animator ani;
    float timer = 0f;
    public GameObject item1;
    public GameObject item2;
    private Vector3 playerDirection;
    private Vector3 direction;
    private Player player;
    private void Start()
    { 
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthCrab.SetMaxHealth(currentHealth);
        playerDirection = new Vector3(transform.position.x - 10f, transform.position.y,0f);
        direction = new Vector3(-1, 0, 0);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            CreateBullet();
            timer = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, playerDirection, speed * Time.deltaTime);
        // Đổi hướng mặt
        transform.localScale = new Vector3(-1, 1, 1);
    }
    private void CreateBullet()
    {
        GameObject newObjectA = Instantiate(SkillMonter, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        newObjectA.GetComponent<Bullets>().InitializeMovement(direction);
        Destroy(newObjectA, 2f);
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
                player.Healing();
            }
        }
        if (coll.gameObject.CompareTag("skill2"))
        {
            currentHealth = 0;
            CreateItems();
            Destroy(gameObject);
            player.Healing();
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
