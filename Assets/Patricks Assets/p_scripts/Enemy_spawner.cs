using UnityEngine;
using System.Collections;

public class Enemy_spawner : MonoBehaviour {
	
	private int amountofenemies;
	public GameObject enemy;
	private int xchang;
	private GameObject newenemy;
	// Use this for initialization
	void Start () {
		amountofenemies = 0;
		xchang = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (amountofenemies == 0) {
			createenemy ();
			amountofenemies++;
		} 
		else if (amountofenemies < 3) {
			StartCoroutine (spawn ());
			amountofenemies++;
			
		}
	}

	IEnumerator spawn () {
		if (amountofenemies == 1) {
			yield return new WaitForSeconds (10);
			createenemy ();
		}
		if (amountofenemies == 2) {
			yield return new WaitForSeconds (40);
			createenemy ();
		}
	}


	void createenemy(){
		newenemy = Instantiate (enemy);
		newenemy.GetComponent<Enemy_Object>().xvar = xchang;
		newenemy.GetComponent<MeshRenderer> ().enabled = true;
		newenemy.GetComponent<Enemy_Object> ().enabled = true;
		xchang = xchang + 5;

	}




}
