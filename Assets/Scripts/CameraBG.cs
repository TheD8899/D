using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraBG : MonoBehaviour
{

    public GameObject player;        


    private Vector3 offset;            
    void Start()
    {
       
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
       
        transform.position = player.transform.position + offset;
    }
}