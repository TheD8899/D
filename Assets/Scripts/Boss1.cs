using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Boss1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monster1;
    public GameObject Monster2;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBoss healthBoss;
    private Animator animator;
    private float timer = 0f;
    private Player player;
    void Start()
    {
        currentHealth = maxHealth;
        healthBoss.SetMaxHealth(currentHealth);
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        checkdie();
        if(player.checkpoint2 == 1)
        {
            CreateMonster();
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBoss.SetHealth(currentHealth);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("skill1"))
        {
            TakeDamage(5);
        }
        if (coll.gameObject.CompareTag("skill2"))
        {
            TakeDamage(15);
        }
    }
    private void checkdie()
    {
        if (currentHealth == 0)
        {
            GameObject boss1 = GameObject.FindGameObjectWithTag("boss");
            animator.SetTrigger("checkdie");
            Destroy(boss1, 2f);
        }
    }
    private void CreateMonster()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            GameObject newObject1 = Instantiate(Monster1, transform.position, Quaternion.identity);
            GameObject newObject2 = Instantiate(Monster2, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
