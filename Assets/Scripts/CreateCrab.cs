using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCrab : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Crab1;
    public GameObject Crab2;
    public GameObject Crab3;
    public GameObject Crab4;
    float timer = 0f;
    public int count1 = 0;
    public int m = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count1 == 0)
        {
            CreateMonster();
        }
    }
    private void CreateMonster()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            GameObject newObject1 = Instantiate(Crab1, new Vector3(1f, -3f, 0f), Quaternion.identity);
            GameObject newObject2 = Instantiate(Crab2, new Vector3(24f, 0f, 0f), Quaternion.identity);
            GameObject newObject3 = Instantiate(Crab3, new Vector3(42f, -8f, 0f), Quaternion.identity);
            GameObject newObject4 = Instantiate(Crab4, new Vector3(51f, -3f, 0f), Quaternion.identity);
            timer = 0f;
            count1 = 4;
            m++;
        }

    }

}
