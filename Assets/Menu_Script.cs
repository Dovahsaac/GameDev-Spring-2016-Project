using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu_Script : MonoBehaviour {

    public Button continue_button;
    public Button high_scores_button;
    Button newGame;

	// Use this for initialization
	void Start () {

        //Enables the continue button if save file is found;    
        continue_button.interactable = File.Exists("save.txt");

        newGame = GameObject.Find("NewGame_Button").GetComponent<Button>();
        newGame.onClick.AddListener(NewGame);
        high_scores_button.onClick.AddListener(loadHighScores);
        continue_button.onClick.AddListener(play);
    }

    private void NewGame()
    {
        StreamWriter writer = new StreamWriter("save.txt");
        writer.WriteLine("0\t0\t0\t0\t0");
        writer.Flush();
        writer.Close();

        SceneManager.LoadScene("Patricks Workbench");
    }

    private void loadHighScores()
    {
        SceneManager.LoadScene("High Scores");
    }

    // Update is called once per frame
    void Update () {
	
	}

    void play()
    {
        SceneManager.LoadScene("Upgrades");
    }

    public void exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
