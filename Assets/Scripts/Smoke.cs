/*etc114 
* Evan Closson
* 11141737
* Assignment 2*/
using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
		wait();
	}
	
	IEnumerator wait()
	{
		yield return new WaitForSeconds (0.4f);
		Destroy (this);
	}
}
