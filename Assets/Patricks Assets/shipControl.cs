﻿using UnityEngine;
using System.Collections;

public class shipControl : MonoBehaviour {
	public float force;	
	public Vector3 boundneg = new Vector3(-5,0,0);
	public Vector3 boundpos = new Vector3(5,0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Horizontal")){
			if (Input.GetAxis ("Horizontal") < 0) {
				if (transform.position.x > boundneg.x) {

					transform.Translate ((Input.GetAxis ("Horizontal") * Time.deltaTime * force), 0, 0);
				}
			}
			if (Input.GetAxis ("Horizontal") > 0) {
				if (transform.position.x < boundpos.x) {

					transform.Translate ((Input.GetAxis ("Horizontal") * Time.deltaTime * force), 0, 0);
				}
				
			} 
		}
		

	}




}
