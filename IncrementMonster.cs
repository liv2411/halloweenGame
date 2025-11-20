using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    private int damageCount = 0;

    private void Start()
    {
        UpdateDamageText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            damageCount++;
            UpdateDamageText();

            if (damageCount >= 3)
            {
                SceneManager.LoadScene("Lose"); 
            }
        }
    }

    void UpdateDamageText()
    {
        damageText.text = "Damage: " + damageCount + "/3";
    }
}
