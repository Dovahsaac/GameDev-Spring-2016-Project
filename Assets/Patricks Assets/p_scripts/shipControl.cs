﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class shipControl : MonoBehaviour {
	public float force;	
	public Vector3 boundneg = new Vector3(-5,0,0);
	public Vector3 boundpos = new Vector3(5,0,0);
	public Vector3 disBehind;
	public Vector3 xvar;
	public Camera camera = new Camera ();
	public GameObject respawner;
	public GameObject pointer;
	public Vector3 originalpos;
	public GameObject respawntext;
	private TextMesh newtex;
	private MeshRenderer texrend;
	public GameObject livestext;
	private TextMesh livesmesh;
	private MeshRenderer livesrend;
	// Use this for initialization
	public Rigidbody rigid;
	private Ship ship = new Ship ();
	public GameObject healthtext;
	private TextMesh healthmesh;
	private MeshRenderer healthrend;
	public GameObject pbullet;
	private GameObject newpbullet;
	private GameObject newpbullet2;
	private Vector3 lagpos;
	private bool shot;
	private int[] upgrades = new int[5];
	private float shotspeed;
	private int timesshot;
	private float ingametime;
	private bool isregening;
	public bool isover;
	public GameObject jetbody;

	void Start () {

		timesshot = 0;
		StreamReader reader = new StreamReader("save.txt");
		string[] file = reader.ReadLine ().Split('\t');
		for (int i = 0; i < file.Length; i++){
			upgrades [i] = Int32.Parse (file [i]);


		}
		originalpos = transform.position;
		rigid = GetComponent<Rigidbody> ();
		newtex = respawntext.GetComponent<TextMesh> ();
		texrend = respawntext.GetComponent<MeshRenderer> ();
		livesmesh = livestext.GetComponent<TextMesh> ();
		livesrend = livesmesh.GetComponent<MeshRenderer> ();
		livesrend.enabled = true;
		livesmesh.text = "Lives: " + ship.returnlives();
		healthmesh = healthtext.GetComponent<TextMesh> ();
		healthrend = healthtext.GetComponent<MeshRenderer> ();
		healthrend.enabled = true;
		healthmesh.text = "Health: " + ship.returnhealth ();
		shot = false;
		shotspeed = 20f;
	}

	// Update is called once per frame
	void FixedUpdate(){


	}


	void Update () {
		healthmesh.text = "Health: " + ship.returnhealth();
		if (upgrades [2] == 3 && ship.returnhealth() < 10 && isregening == false) {
			isregening = true;
			StartCoroutine (regen ());




		}


		livesmesh.text = "Lives: " + ship.returnlives ();

		Vector3 test = Input.mousePosition;
		disBehind = test;
		test.z = pointer.transform.position.z - Camera.main.transform.position.z;
		test = Camera.main.ScreenToWorldPoint (test);
		disBehind.z = transform.position.z - Camera.main.transform.position.z;

		disBehind = Camera.main.ScreenToWorldPoint (disBehind);
		disBehind.y = test.y -1f;
		pointer.transform.position = /*Vector3.MoveTowards (pointer.transform.position,*/ test /*, force * Time.deltaTime)*/;



		transform.position = Vector3.MoveTowards (transform.position, disBehind, force * Time.deltaTime);
		if (shot == false) {
			if (Input.GetMouseButtonDown (0)) {
				newpbullet = Instantiate (pbullet);
				newpbullet.transform.position = pointer.transform.position;
				lagpos = Input.mousePosition;
				lagpos.z = 15;
				lagpos = Camera.main.ScreenToWorldPoint (lagpos);
				lagpos.y += 8;
				lagpos.x -= 0.5f;
				newpbullet.transform.position = Vector3.MoveTowards (newpbullet.transform.position, lagpos, shotspeed * Time.deltaTime);

				shot = true;

				if (upgrades [1] >= 2) {
					newpbullet2 = Instantiate (pbullet);
					newpbullet2.transform.position = pointer.transform.position;
					lagpos = Input.mousePosition;
					lagpos.z = 15;
					lagpos = Camera.main.ScreenToWorldPoint (lagpos);
					lagpos.y += 8;
					lagpos.x -= 0.5f;
				}
			}
		}
		if (shot == true) {
			if (newpbullet.transform.position == lagpos) {
				Destroy (newpbullet);
				if (upgrades [1] >= 2) {
					Destroy (newpbullet2);
				}
				shot = false;
			} else {
				newpbullet.transform.position = Vector3.MoveTowards (newpbullet.transform.position, lagpos, shotspeed * Time.deltaTime);
				newpbullet2.transform.position = Vector3.MoveTowards (newpbullet.transform.position, lagpos, shotspeed * Time.deltaTime);
			}

		} 




	}
	void OnCollisionEnter(Collision col){



		if (col.gameObject.tag == "Cube") {


			jetbody.GetComponent<MeshRenderer> ().enabled = false; 
			GetComponent<BoxCollider> ().enabled = false;
			transform.position = originalpos;

			if (ship.returnlives() > 0) {
				ship.decrementlives ();
				healthmesh.text = "RESPAWN";
				StartCoroutine (respawn ());
			} else {
				texrend.enabled = true;
				isover = true;
				newtex.text = "You have failed";

			}
		} else {



		}
		if (col.gameObject.tag == "Bullet") {
			//GetComponent<BoxCollider> ().enabled = false;
			//StartCoroutine (invun ());
			//Destroy (col.gameObject); //this may be needed who knows
			/*if (upgrades [2] > 1) {
				if (UnityEngine.Random.value > 0.25) {
					if (upgrades [2] > 2) {
						ship.decrementhealthhalf ();
					} else {
						ship.decrementhealth ();
					}
				} else {
				}
			}*/
			ship.decrementhealth ();
			healthmesh.text = "Health: " + ship.returnhealth ();
			if (upgrades [1] == 3) {
				shotspeed += 1f;
			}
			if (ship.returnhealth() == 0) {
				jetbody.GetComponent<MeshRenderer> ().enabled = false; 
				GetComponent<BoxCollider> ().enabled = false;
				transform.position = originalpos;
				if (ship.returnlives() == 0) {
					isover = true;


				}
				ship.decrementlives ();

				if (!isover) {
					StartCoroutine (respawn ());
					healthmesh.text = "RESPAWN";
				}

			}

		}



	}
	void destroyBullets(){
		GameObject[] gameObjects = new GameObject[400];
		gameObjects = GameObject.FindGameObjectsWithTag ("pBullet");
		for (int i = 0; i < gameObjects.Length; i++) {
			if (gameObjects [i] != null) {
				Destroy (gameObjects [i]);

			}


		}


	}

	IEnumerator respawn(){
		texrend.enabled = true;
		ship.changeHealth (10);
		newtex.text = "Respawning in 5";
		yield return new WaitForSeconds (1);
		newtex.text = "Respawning in 4";
		yield return new WaitForSeconds (1);
		newtex.text = "Respawning in 3";
		yield return new WaitForSeconds (1);
		newtex.text = "Respawning in 2";
		yield return new WaitForSeconds (1);
		newtex.text = "Respawning in 1";
		yield return new WaitForSeconds (1);
		newtex.text = "Respawned";
		jetbody.GetComponent<MeshRenderer> ().enabled = true;
		healthmesh.text = "Invun";
		yield return new WaitForSeconds (2);
		texrend.enabled = false;
		GetComponent<BoxCollider> ().enabled = true;
		healthmesh.text = "Health: " + ship.returnhealth();


	}
	IEnumerator invun(){

		yield return new WaitForSeconds (2);
		GetComponent<BoxCollider> ().enabled = true;



	}

	IEnumerator regen(){
		yield return new WaitForSeconds (10);
		ship.incrementhealth();

		isregening = false;



	}

}
