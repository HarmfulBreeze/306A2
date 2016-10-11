using UnityEngine;
using System.Collections;

public class Bazooka : MonoBehaviour {
	/*Start off by adding a fire rate and damage for a rocket.*/
	public float rateOfFire = 0;
	public float damage = 10;

	public float fireTime = 0;
	public Transform point;

	void Awake () {
		point = transform.FindChild ("FirePoint");
		if (point == null)
			Debug.LogError ("No point found on game.");
	}
	
	// Update is called once per frame
	void Update () {
		if (rateOfFire == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				shootGun ();
			}
		} else {
			if (Input.GetButton ("Fire1") && Time.time > fireTime) {
				fireTime = Time.time + 1 / rateOfFire;
				shootGun ();
			}
		}
	}

	void shootGun(){
		Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
			                   Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPos = new Vector2 (point.position.x, point.position.y);
		RaycastHit2D hitConfirm = Physics2D.Raycast (firePointPos, mousePos - firePointPos, 100);
		Debug.DrawLine (firePointPos, (mousePos - firePointPos) * 100, Color.green);
		if (hitConfirm.collider != null)
			Debug.DrawLine (firePointPos, hitConfirm.point, Color.red);
	}
}
