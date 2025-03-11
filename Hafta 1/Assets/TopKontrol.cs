using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGameOver = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGameOver) return; 

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        rb.AddForce(movement, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Engele çarptýn!");
            EngelRenkleri obstacleScript = collision.gameObject.GetComponent<EngelRenkleri>();
            if (obstacleScript != null && !obstacleScript.hasBeenHit)
            {
                obstacleScript.ChangeObstacleColor();
                obstacleScript.hasBeenHit = true; 
            }
        }

        if (collision.gameObject.CompareTag("FallZone"))
        {
            Debug.Log("Düþtün! Oyun hemen baþlýyor.");
            EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Tebrikler! Kazandýn! Parkuru tamamladýn.");
            
        }
    }

    void EndGame()
    {
        isGameOver = true;
        RestartGame();
    }

    void RestartGame()
    {
       
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
