using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillsplayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    private bool flipCalled = false;
    int count2 = 20;

    private float moveSpeed = 10f;

    private float direction;

    public void InitializeMovement(float dir)
    {
        direction = dir;
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!flipCalled) // Call Flip() only once
        {
            Flip();
            flipCalled = true;
        }
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
    }
   
    public void Bay()
    {
        if (count2 < 0)
        {
            count2 = 15;
            if (player.checkIsfacingRight == 1)
            {
                transform.position = transform.position + new Vector3(0.8f, 0, 0);
            }
            else if(player.checkIsfacingRight == -1)
            {
                transform.position = transform.position + new Vector3(-0.8f, 0, 0);
            }
        }
        count2--;
    }
    void Flip()
    {
        if (player.checkIsfacingRight == -1 )
        {
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;
        }
    }
}
