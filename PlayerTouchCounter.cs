using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerTouchCounter : MonoBehaviour
{
    public string monsterTag = "Monster";     // Tag your monsters as "Monster"
    public TextMeshProUGUI counterText;       // Drag UI text here
    public string loseSceneName = "LoseScreen"; // Set your lose screen scene name
    public int maxTouches = 3;                // Touch limit before losing

    private int monsterTouchCount = 0;

    void Start()
    {
        UpdateCounterText();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if we touched a monster
        if (other.CompareTag(monsterTag))
        {
            monsterTouchCount++;  // Increase counter
            UpdateCounterText();  // Update UI

            Destroy(other.gameObject); // Make the monster disappear

            // If we reached the limit → lose the game
            if (monsterTouchCount >= maxTouches)
            {
                SceneManager.LoadScene(loseSceneName);
            }
        }
    }

    void UpdateCounterText()
    {
        counterText.text = "Monsters Touched: " + monsterTouchCount + "/" + maxTouches;
    }
}

