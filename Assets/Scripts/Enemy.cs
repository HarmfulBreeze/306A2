/*etc114 
* Evan Closson
* 11141737
* Assignment 2*/
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float Speed;
	/*Used to track player. A very simple AI.*/
	Transform player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("skeleton").transform;
	}

	void FixedUpdate () {
		/*Rotate on z axis toward the player.*/
		float zAxis = Mathf.Atan2((player.transform.position.y - transform.position.y),
			(player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0, 0, zAxis);

		GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * Speed);
	}
}