using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public GameObject Monster4;
    public int count = 0; 
    float timer = 3f;
    public int m = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 0)
        {
            CreateMonter();
        }
        
    }
    private void CreateMonter()
    {
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            GameObject newObject1 = Instantiate(Monster1, new Vector3(-3f, -1.5f, 0f), Quaternion.identity);
            GameObject newObject2 = Instantiate(Monster2, new Vector3(18.5f, 6.5f, 0f), Quaternion.identity);
            GameObject newObject3 = Instantiate(Monster3, new Vector3(24f, -1.5f, 0f), Quaternion.identity);
            GameObject newObject4 = Instantiate(Monster4, new Vector3(45f, -1.5f, 0f), Quaternion.identity);
            timer = 0f;
            count = 4;
            m++;
        }
    }
}
