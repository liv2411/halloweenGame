using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnInstructionsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
