using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Skill;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBoss healthBoss;
    private Animator animator;
    private float timer = 3f;
    private Player player;
    private int checktime = 0;
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
            CreateSkills();
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
        if (currentHealth <= 0)
        {
            GameObject boss1 = GameObject.FindGameObjectWithTag("boss");
            animator.SetTrigger("checkdie");
            Destroy(boss1, 1f);
        }
    }
    private void CreateMonster()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            animator.SetTrigger("checkskill2");
            GameObject newObject1 = Instantiate(Monster1, transform.position, Quaternion.identity);
            GameObject newObject2 = Instantiate(Monster2, transform.position, Quaternion.identity);
            timer = 0f;
            checktime++;
        }
    }
    private void CreateSkills()
    {
        
        if(checktime == 2)
        {
            animator.SetTrigger("checkskill1");
            GameObject skill1 = Instantiate(Skill,new Vector2(Random.Range(61, 64), -3.8f), Quaternion.identity);
            GameObject skill2 = Instantiate(Skill, new Vector2(Random.Range(64, 67), -3.8f), Quaternion.identity);
            GameObject skill3 = Instantiate(Skill, new Vector2(Random.Range(67, 70), -3.8f), Quaternion.identity);
            GameObject skill4 = Instantiate(Skill, new Vector2(Random.Range(70, 73), -3.8f), Quaternion.identity);
            Destroy(skill1, 1f);
            Destroy(skill2, 1f);
            Destroy(skill3, 1f);
            Destroy(skill4, 1f);
            checktime = 0;
        }
    }
}
