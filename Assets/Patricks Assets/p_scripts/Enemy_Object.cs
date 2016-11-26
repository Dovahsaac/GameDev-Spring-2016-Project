﻿using UnityEngine;
using System.Collections;

public class Enemy_Object : MonoBehaviour {
	public GameObject player;
	private Vector3 position;
	public float xvar;
	private GameObject bullet;
	private GameObject newbullet;
	private bool hasfired;
	private Vector3 lagpos;
	private bool timed;
	private Vector3 bulletpos;
	// Use this for initialization
	void Start () {
		hasfired = false;
		timed = true;
		bullet = transform.FindChild("Bullet").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		position = player.transform.position;
		position.x = position.x - xvar;
		position.y = position.y + 5;
		position.z = position.z + 5;
		transform.position = Vector3.MoveTowards (transform.position, position, 2f * Time.deltaTime);

			if (hasfired == false) {
				hasfired = true;
				lagpos = player.transform.position;
				shoot ();
				
			}


			if (hasfired = true) {
				if (bulletpos == lagpos) {
					Destroy (newbullet);
					hasfired = false;


				} else {
					bulletpos = newbullet.transform.position; 
					newbullet.transform.position = Vector3.MoveTowards (newbullet.transform.position, lagpos, 5f * Time.deltaTime);
					
				}
			}


	}


	void shoot(){
		newbullet = Instantiate (bullet);
		newbullet.transform.position = transform.position;
		newbullet.GetComponent<MeshRenderer>().enabled = true;

	
	
	
	}

	IEnumerator shoottime(){
		yield return new WaitForSeconds (5);
		hasfired = false;


	}

}
