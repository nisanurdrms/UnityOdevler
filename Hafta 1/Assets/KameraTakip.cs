using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 5, -7); 
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        
        transform.LookAt(target.position + Vector3.up * 2f);
    }
}
