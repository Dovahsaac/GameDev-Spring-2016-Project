using UnityEngine;
using System.Collections;

public class Enemy_spawner : MonoBehaviour {
	public GameObject[] enemies = new GameObject[3];
	public int amountofenemies;
	public GameObject enemy;
	public int xchang;
	private GameObject newenemy;

	// Use this for initialization
	void Start () {
		amountofenemies = 0;
		xchang = 0;
	}
	
	// Update is called once per frame
	void Update () {
		


		Debug.Log (amountofenemies);
		/*if (amountofenemies == 0) {
			createenemy ();
			amountofenemies++;
		} */
		if (amountofenemies < 3) {
			StartCoroutine (spawn ());
			amountofenemies++;
			
		}



	}

	IEnumerator spawn () {
		if (amountofenemies == 0) {
			yield return new WaitForSeconds (10);
			createenemy ();
		
		
		}

		if (amountofenemies == 1) {
			yield return new WaitForSeconds (20);
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

		xchang = xchang - 5;
		newenemy.GetComponent<Enemy_Object>().index = amountofenemies;


	}




}
