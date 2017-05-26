using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Text timerText;
    public Text scoreText;
    public Image endScreen;

    public void Start()
    {

        if (scoreText) {
            scoreText.text = "Highscore: " + PlayerPrefs.GetInt("score", 0);
        }
    }

    public void changeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
