/*etc114 
* Evan Closson
* 11141737
* Assignment 2*/
using UnityEngine;
using System.Collections;

public class BazookaShot : MonoBehaviour {

	/*Create an offset to where the rocket launcher is in reference
	* to the player*/
	public Vector3 rocketOffset = new Vector3(0.45f, 1f, 0);
	public GameObject bulletPre;
	public GameObject fireAnim;
	int bulletLayer;

	public AudioClip shot;

	/*Delay in which the rocket is fired from the launcher. Adjust for sound.*/
	public float delay = 0.25f;
    /*Doesn't need to be adjusted externally.*/
	float coolDown = 0;

	// Use this for initialization
	void Start () {
		bulletLayer = gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
		coolDown -= Time.deltaTime;
		if (Input.GetButton ("Fire1") && coolDown <= 0) {
			/*Begin to shoot the rocket in the trajectory! Yeah!*/
			coolDown = delay;

			Vector3 offset = transform.rotation * rocketOffset;
			GameObject bulletShot = (GameObject)Instantiate (bulletPre, transform.position + offset, 
				transform.rotation * Quaternion.Euler (0, 0, 90));
			bulletShot.layer = bulletLayer;
			GameObject smoke = (GameObject)Instantiate (fireAnim, transform.position +
				offset, transform.rotation * Quaternion.Euler (0, 0, 90));

			/*Play the audio now.*/
			AudioSource shotsFired = GetComponent<AudioSource> ();
			shotsFired.PlayOneShot (shot);

			/*Now remove the smoke from the bazooka.*/
			Destroy (smoke, 0.75f);
			Destroy (bulletShot, 10);
			/*Reset cool down.*/
			coolDown = 1;
		}
	}
}
