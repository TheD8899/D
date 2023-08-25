using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Vector3 direction;

    
    private void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    public void InitializeMovement(Vector3 dir)
    {
        direction = dir;
    }
}
