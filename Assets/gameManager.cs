using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public int scoring;
    public List<Image> img;

    private int universalScore = 100;
    public TextMeshProUGUI scoreText; // Reference to the UI text to display the score
    public TextMeshProUGUI scoreMessage;

    void Start()
    {
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one GameManager instance exists
        }
    }

    public void IncrementUniversalScore()
    {
        universalScore = 20 + universalScore;
        UpdateScoreText(); // Update the UI text
    }

    public void MinusUniversalScore()
    {
        universalScore = universalScore - scoring;
        Debug.Log(universalScore);
        UpdateScoreText(); // Update the UI text
    }

    public int GetUniversalScore()
    {
        return universalScore;
    }

    // Update UI text with the current score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = universalScore.ToString();

            if (universalScore <= 45)
            {
                img[0].gameObject.SetActive(true);
                scoreMessage.text = "Failed!";
            }
            else if (universalScore <= 65)
            {
                img[1].gameObject.SetActive(true);
                scoreMessage.text = "Good!";
            }
            else if (universalScore <= 85)
            {
                img[2].gameObject.SetActive(true);
                scoreMessage.text = "Great!";
            }
            else if (universalScore >= 95)
            {
                img[3].gameObject.SetActive(true);
                scoreMessage.text = "Excellent!";
            }
        }
    }

    // Method to be called when the button is clicked (UI Button's OnClick event)
    public void OnButtonClick()
    {
        IncrementUniversalScore(); // Increment the score when the button is clicked
        Debug.Log(universalScore);
    }
}
