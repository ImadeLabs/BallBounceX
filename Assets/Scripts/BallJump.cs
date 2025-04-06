using UnityEngine;
using TMPro; // Add this line if using TextMeshPro (skip if using Legacy Text)

public class BallJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 400f;
    public TextMeshProUGUI scoreText; // Link to the UI text (use Text if Legacy)
    private int score = 0; // To keep track of the score

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText(); // Show initial score
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Tap or click
        {
            rb.AddForce(Vector2.up * jumpForce);
            score++; // Increase score by 1 each tap
            UpdateScoreText(); // Update the text on screen
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the text
    }
}