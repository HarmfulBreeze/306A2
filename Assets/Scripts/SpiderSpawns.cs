/*etc114 
* Evan Closson
* 11141737
* Assignment 2*/
using UnityEngine;
using System.Collections;

public class SpiderSpawns : MonoBehaviour {

	public Transform[] sPoints;
	public float timer = 4f;
	public float waitTimer = 4f;
	public float sRateInc = 0.1f;
	public GameObject spider;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", timer, timer);
		/*Call a co-routine to start spawning in more spidersas time increases.*/
		StartCoroutine (incSpawnRate ());
	}

	/*Spawn in the enemy spiders.*/
	void Spawn () {
		int spawnIndex = Random.Range (0, sPoints.Length);
		Instantiate (spider, sPoints [spawnIndex].position, sPoints [spawnIndex].rotation);
	}

	/*Start to increase spawn rate. If our spawn timer is greater than
	* one and a half seconds, subtract the spawn rate and continue to 
	* spawn in until we reach below the threshold.*/
	IEnumerator incSpawnRate() {
		yield return new WaitForSeconds (waitTimer);
		if (timer > 1.5f) {
			timer -= sRateInc;
			StartCoroutine (incSpawnRate ());
		}
	}
}
