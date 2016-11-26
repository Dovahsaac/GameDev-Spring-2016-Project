using UnityEngine;
using System.Collections;

public class score_UI : MonoBehaviour {
	public float score;
	private float totaltime;
	public GameObject scoreUI;
	private TextMesh scoreMesh;
	private MeshRenderer scoreRend;
	public GameObject player;
	public float totaltimeend;
	public int totaltimeint;
	private int counter;


	// Use this for initialization
	void Start () {
		score = 0;
		scoreMesh = scoreUI.GetComponent<TextMesh> ();
		scoreRend = scoreMesh.GetComponent<MeshRenderer> ();
		scoreRend.enabled = true;
		scoreMesh.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		totaltime = Time.fixedTime;
		scoreMesh.text = "Score: " + score;
		if (player.GetComponent<shipControl> ().isover == true) {
			if (counter == 0) {
				totaltimeend = totaltime;
				score = score + totaltimeend / 10;
			}

			counter++;
		}
	}
}
