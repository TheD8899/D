using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasures : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator m_Animator;
    public GameObject item1;
    public GameObject item2;
    private bool m_check =true;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("playerrr"))
        {
            m_Animator.SetTrigger("check1");
            if (m_check) 
            {
                RandomItems();
            }
        }
    }
    private void RandomItems()
    {
        m_check = false;
        int randomIndex = Random.Range(0, 2);
        GameObject selectedObject = randomIndex == 0 ? item1 : item2;
        Vector3 playerPosition = transform.position;
        Vector3 randomPosition = playerPosition + new Vector3(Random.Range(-1f, 1f), 1f, 0);
        Instantiate(selectedObject, randomPosition, Quaternion.identity);
    }
}



