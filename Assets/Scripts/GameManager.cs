using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float timeLeft = 60f;
    public GameObject player;
    public static int points = 0;

    private UIManager manager;
    private TouchJump playerJump;

    // Use this for initialization
    void Start () {
        manager = FindObjectOfType<UIManager>();
        
        playerJump = FindObjectOfType<TouchJump>();
        points = 0;
    }
	
	// Update is called once per frame
	void Update () {
        manager.timerText.text = ((int)timeLeft).ToString();
        manager.scoreText.text = points.ToString();

        if (timeLeft <= 0) {
            endGame();
        }
        else {
        timeLeft -= Time.deltaTime;
        }
	}
    

    private void endGame()
    {
        if (points > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", points);
        }
        Debug.Log("end");
        playerJump.enabled = false;
        manager.endScreen.gameObject.SetActive(true);
    }
}
