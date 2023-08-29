using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finispoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player3;
    void Start()
    {
        player3 = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*    private void OnCollisionEnter2D(Collision2D coll)
    {
        
    }*/
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("playerrr"))
        {
            if (player3.checkpoint1 == 1)
            {
                SceneController.instance.NextLevel();
                player3.checkpoint1 = 0;
            }

        }
    }

}
