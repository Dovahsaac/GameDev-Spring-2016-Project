using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene("Main Menu");

    }

    public void show()
    {
        gameObject.SetActive(true);
    }
}
