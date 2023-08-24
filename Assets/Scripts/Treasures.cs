using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasures : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator m_Animator;
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
        }
    }
}



