using UnityEngine;
using System.Collections;

public class Game_Loop : MonoBehaviour {

    GameObject[] cubes;
    Random rng = new Random();
    public int speed = 20;
    public int respawn_distance = 5;
    public int despawn_distance = 10;
    public int respawn_rangeX = 32;
    public int respawn_rangeY = 32;
    float x,y;

	// Use this for initialization
	void Start () {

        cubes = GameObject.FindGameObjectsWithTag("Cube");

	}
	
	// Update is called once per frame
	void Update () {

        foreach(GameObject cube in cubes)
        {
            //Moves the cubes in the Z axis;
            cube.transform.Translate(-Vector3.forward*Time.deltaTime*speed,Camera.main.transform);
            cube.transform.Rotate(Vector3.up * Time.deltaTime);

            //Respawns cubes if they pass the camera;
            if (cube.transform.position.z < Camera.main.transform.position.z - despawn_distance)
            { 
                x = Random.value*respawn_rangeX-respawn_rangeX/2;
                y = Random.value*respawn_rangeY-respawn_rangeY/2;

                cube.transform.position = new Vector3(x, y, respawn_distance);
                cube.transform.localEulerAngles = new Vector3(Random.value*360, Random.value*360, Random.value*360);
            }
        }
	
	}
}
