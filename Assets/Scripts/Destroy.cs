using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public GameObject toBeDestroyed;
	public AudioClip explosion;
	public AudioClip deadArachnid;

	/*Game controller to reinitialize spiders.*/
	private SpiderSpawns gControl;

	// Use this for initialization
	void Start () {
		GameObject gControlObj = GameObject.FindWithTag ("SpiderSpawns");
		if (gControlObj != null)
			gControl = gControlObj.GetComponent<SpiderSpawns> ();
		if (gControl == null)
			Debug.Log ("Cannot find \"SpiderSpawn\" script");
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collider) {
		AudioSource aud = GetComponent<AudioSource> ();
		/*If we hit a wall or spider, we can enter this.*/
		if (collider.gameObject.tag == "spider" || collider.gameObject.tag == "wall") {
			/*Now check if it is either a wall or a spider.*/
			if (collider.gameObject.tag == "spider"){
				Destroy(collider.gameObject);
				aud.PlayOneShot (deadArachnid);
				ScoreManager.currentScore += 5;
			}
			aud.PlayOneShot (explosion);
			/*Remove the rocket from existence.*/
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (GetComponent<BoxCollider2D> ());
			Destroy (gameObject, 5f);
			GameObject explode = (GameObject)Instantiate(toBeDestroyed, transform.position,
				transform.rotation * Quaternion.Euler(0,0,90));
			/*Remove the smoke.*/
			Destroy (explode, 0.9f);
		}
	}
}
