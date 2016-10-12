/*etc114 
* Evan Closson
* 11141737
* Assignment 2*/
using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour {
	/*Dampen the follow so it's not as strict.*/
	public float dTime = 0.1f;
	private Vector3 veloc = Vector3.zero;
	public Transform player;
	
	// Update is called once per frame
	void Update () {
		/*If we find the player, simply follow him to a certain extent.*/
		if (player) {
			Camera cam = GetComponent<Camera> ();
			Vector3 point = cam.WorldToViewportPoint (player.position);
			Vector3 delta = player.position - cam.ViewportToWorldPoint (new Vector3 (0.4f, 0.4f, point.z));
			Vector3 dest = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, dest, ref veloc, dTime);
		}
	}
}
