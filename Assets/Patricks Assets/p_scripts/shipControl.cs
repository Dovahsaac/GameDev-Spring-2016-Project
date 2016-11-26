using UnityEngine;
using System.Collections;

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
	void Start () {
		originalpos = transform.position;
		rigid = GetComponent<Rigidbody> ();
		newtex = respawntext.GetComponent<TextMesh> ();
		texrend = respawntext.GetComponent<MeshRenderer> ();
		livesmesh = livestext.GetComponent<TextMesh> ();
		livesrend = livesmesh.GetComponent<MeshRenderer> ();
		livesrend.enabled = true;
		livesmesh.text = "Lives: " + ship.returnlives();
	}
	
	// Update is called once per frame
	void Update () {

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

		



	}
	void OnCollisionEnter(Collision col){



		if (col.gameObject.tag == "Cube") {


			GetComponent<MeshRenderer> ().enabled = false; 
			GetComponent<BoxCollider> ().enabled = false;
			transform.position = originalpos;

			if (ship.returnlives() > 0) {
				ship.decrementlives ();
				StartCoroutine (respawn ());
			} else {
				texrend.enabled = true;
				newtex.text = "You have failed";
			
			}
		} else {
		


		}

	
	
	}

	IEnumerator respawn(){
		texrend.enabled = true;
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
		GetComponent<MeshRenderer> ().enabled = true;

		yield return new WaitForSeconds (2);
		texrend.enabled = false;
		GetComponent<BoxCollider> ().enabled = true;
	
	
	}


}
