using UnityEngine;
using TMPro; // If using TextMeshPro for the score

public class BallJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 400f;
    public TextMeshProUGUI scoreText; // If using TextMeshPro
    private int score = 0;
    private Animator animator; // For the squash-and-stretch animation
    private AudioSource jumpSound; // For the jump sound

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        UpdateScoreText();

        // Check if animator is missing
        if (animator == null)
        {
            Debug.LogWarning("Animator component is missing on " + gameObject.name);
        }

        // Check if jumpSound is missing
        if (jumpSound == null)
        {
            Debug.LogWarning("AudioSource component is missing on " + gameObject.name);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Tap or click
        {
            rb.AddForce(Vector2.up * jumpForce);
            score++;
            UpdateScoreText();
            if (animator != null) // Only play animation if animator exists
            {
                animator.Play("BallBounce"); // Play the animation
            }
            if (jumpSound != null) // Only play sound if jumpSound exists
            {
                jumpSound.Play(); // Play the jump sounds
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}