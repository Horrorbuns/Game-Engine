﻿/*
 * Michael Anthony Gonzalez
 * Houston Community College
 * Fall 2015
 * MonoDevelop - Unity 5.1.2f1(64-bit))
This class will be an Added Component to PlayerBullet GameObject for programming Player's 
Bullete blast attack.
 */

using UnityEngine;
using System.Collections;

public class ss_PlayerBullet : MonoBehaviour {



  float ss_speed;

	// Use this for initialization
	void Start () 
	{
		ss_speed = 8f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		//Get the bullet's current position.
		Vector2 position = transform.position;

		//Compute the bullet's new position. This is used for shooting Horizontally
		position = new Vector2 (position.x + ss_speed * Time.deltaTime, position.y );

		//position = new Vector2 (position.x , position.y + ss_speed * Time.deltaTime ); Shooting Vertically. 

		//Update the bullet's  position.
		transform.position = position;

		//This is the top-right point of the screen.
		Vector2 max= Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//If the bullet went outside the screen on the top, then destory the bullet.
		if (transform.position.x > max.x)
		{
			//This is used when player bullets exits to the right side of screen and they destroyed.
			//it was (transform.position.y > max.y)
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Detect coliision of the player bullet with an enemies' ships
		if((col.tag== "EnemyShipTag"))
		{
			Destroy(gameObject); //Destroy This player bullet.
		}
	}

}
