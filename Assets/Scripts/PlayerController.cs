using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] Rigidbody rb;

    public int health = 5;
    private int score = 0;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            Debug.Log($"Score: {score}");
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }

    }
}
