using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour
{
    public float movementSpeed = 10f;  // Initial speed
    public float leanAngle = 15f; // Angle to lean left/right
    public float leanSpeed = 5f;  // Speed to smooth the lean
    public float jumpForce = 5f;  // Controlled jump force
    public SpawnManager spawnManager;

    public float speedIncreaseRate = 0.1f;  // Rate at which the speed increases over time
    public float maxSpeed = 20f;  // Maximum speed the player can reach

    private bool isRunning = false;
    private bool isGrounded = true;
    private Rigidbody rb;

    private float timeRunning = 0f;  // Track the time the player has been running

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isRunning = true;
        }

        // Jump logic: only allow jump if grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero; // Reset any existing velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange); // Apply jump force
            isGrounded = false;
        }

        // Increase speed over time
        if (isRunning)
        {
            timeRunning += Time.deltaTime;
            movementSpeed = Mathf.Min(movementSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed); // Gradually increase speed, but clamp it to maxSpeed
        }

        Debug.Log("Movement Speed: " + movementSpeed);
    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
            float vMovement = movementSpeed;

            transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);

            float targetLeanAngle = Input.GetAxis("Horizontal") * leanAngle;
            Quaternion targetRotation = Quaternion.Euler(0, targetLeanAngle, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, leanSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = Vector3.zero; // Reset velocity
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT!");

            // Find the GameManager and call GameOver
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddCoin();
            }

            Destroy(collision.gameObject); // Remove coin
        }
    }

}
