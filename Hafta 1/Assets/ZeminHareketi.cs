using UnityEngine;

public class ZeminHareketi : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float moveRange = 2f; 
    public float verticalRange = 1f; 
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float moveX = Mathf.Sin(Time.time * moveSpeed) * moveRange; 
        float moveY = Mathf.Sin(Time.time * moveSpeed * 0.5f) * verticalRange; 

        transform.position = new Vector3(moveX, startY + moveY, transform.position.z);
    }
}

