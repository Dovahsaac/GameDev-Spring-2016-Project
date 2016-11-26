using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu_Script : MonoBehaviour {

    public Button continue_button;
    public Button high_scores_button;

	// Use this for initialization
	void Start () {

        //Enables the continue button if save file is found;    
        continue_button.interactable = File.Exists("save.txt");

        high_scores_button.onClick.AddListener(loadHighScores);
        
    }

    private void loadHighScores()
    {
        SceneManager.LoadScene("High Scores");
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
