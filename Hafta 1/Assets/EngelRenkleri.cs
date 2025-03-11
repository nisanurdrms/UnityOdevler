using UnityEngine;

public class EngelRenkleri : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    private Color purpleColor = new Color(0.5f, 0f, 0.5f); 
    public bool hasBeenHit = false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeObstacleColor(); 
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            renderer.material.color = originalColor; 
        }
    }

   
    public void ChangeObstacleColor()
    {
        renderer.material.color = purpleColor; 
    }
}
