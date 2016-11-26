using UnityEngine;
using System.Collections;

public class Ship {
	private int lives;
	private double health;
	public Ship(){
		lives = 3;
		health = 10;

	}
	public void decrementhealthhalf(){
		health = health - 0.5;
	
	}

	public int returnlives(){
		return lives;

	}
	public void decrementlives(){
		lives--;
		
	}
	public void incrementlives(){
		lives++;
	}
	public void changeLives(int newvalue){
		lives = newvalue;
	}

	public void changeHealth(int newvalue){
		health = newvalue;
	
	}

	public double returnhealth(){
	
		return health;
	
	}

	public void decrementhealth(){

		health--;
	
	}
	public void incrementhealth(){
		health++;
	}





}
