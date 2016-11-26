using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
    
    public Camera Camera;
    public GameObject building;
    GameObject[] buildings;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 50; i++)
        {
            GameObject gFloor = Instantiate(building);
            if(i%2==0)
            gFloor.transform.localPosition = new Vector3(10+2*Random.value, -5, 3 * i);
            else gFloor.transform.localPosition = new Vector3(-10-2*Random.value, -5, 3 * i);
            gFloor.transform.parent = transform;
        }

        buildings = GameObject.FindGameObjectsWithTag("Building");

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject building in buildings)
        {
            //Moves the cubes in the Z axis;
            building.transform.Translate(-Vector3.forward * Time.deltaTime * 50, Camera.main.transform);

            if (building.transform.position.z < Camera.transform.position.z)
                building.transform.Translate(new Vector3(0,0,+150), Camera.main.transform);

        }
    }
}
