using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CandyCollector : MonoBehaviour
{
    public TextMeshProUGUI candyText;   // Assign in Inspector
    private int candyCount = 0;         // Current number of candies collected
    public int candiesToWin = 30;       // Target number of candies
    public string winSceneName = "Win Scene"; // Name of the Win scene

    void Start()
    {
        UpdateCandyText();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if we collided with a candy
        if (other.CompareTag("Collectible"))
        {
            candyCount++;
            UpdateCandyText();

            // Remove the collected candy
            Destroy(other.gameObject);

            // Check for win condition
            if (candyCount >= candiesToWin)
            {
                SceneManager.LoadScene(winSceneName);
            }
        }
    }

    void UpdateCandyText()
    {
        candyText.text = "Candies: " + candyCount.ToString();
    }
}
