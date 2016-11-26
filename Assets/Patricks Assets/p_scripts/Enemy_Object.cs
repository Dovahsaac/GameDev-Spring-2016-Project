using UnityEngine;
using System.Collections;

public class Enemy_Object : MonoBehaviour {
	public GameObject player;
	private Vector3 position;
	public float xvar;
	public GameObject bullet;
	private GameObject newbullet;
	private bool hasfired;
	private Vector3 lagpos;
	// Use this for initialization
	void Start () {
		hasfired = false;
	}
	
	// Update is called once per frame
	void Update () {
		position = player.transform.position;
		position.x = position.x - xvar;
		position.y = position.y + 5;
		position.z = position.z + 5;
		transform.position = Vector3.MoveTowards (transform.position, position, 2f * Time.deltaTime);
		if (hasfired == false) {
			StartCoroutine (shoottime ());
			hasfired = true;
			lagpos = player.transform.position;
			shoot ();
		}

		newbullet.transform.position = Vector3.MoveTowards(newbullet.transform.position,lagpos,10f*Time.deltaTime);
		if (newbullet.transform.position == lagpos && hasfired == true) {
			Destroy (newbullet);
			hasfired = false;
		}
	}

	void shoot(){
		newbullet = Instantiate (bullet);
		newbullet.GetComponent<MeshRenderer>().enabled = true;

	
	
	
	}

	IEnumerator shoottime(){
		yield return new WaitForSeconds (20);



	}

}
