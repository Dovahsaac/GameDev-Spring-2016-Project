using UnityEngine;
using System.Collections;

public class Enemyclass {
	private int health;

	public Enemyclass(){
		health = 1;
	}

	public int returnhealth(){
		return health;


	}

	public void decrementhealth(){
		health--;
	
	}

}
