using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load_High_Scores : MonoBehaviour {

    public Text high_scores; 
    public Button returnButton;
    public string previousScene;

	// Use this for initialization
	void Start () {

        //Load highscores
        StreamReader reader = new StreamReader("highScores.txt");
        string text = reader.ReadToEnd();
        high_scores.text = text;

        //Add Button listener
        returnButton.onClick.AddListener(exit);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
