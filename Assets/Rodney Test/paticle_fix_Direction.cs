using UnityEngine;
using System.Collections;

public class paticle_fix_Direction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
