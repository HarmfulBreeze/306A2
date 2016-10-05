using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

    // Need this for our character movement.
	public float speed;

    void FixedUpdate()
    {
        /*Can be float but the var will just make it whatever value we need it to be!*/
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        /*Hey! Look at this, and quaternion will turn towards the mouse.*/
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        /*Rotate to look at mouse.*/
        transform.rotation = rotation;

        /*Limit to only Z rotation.*/
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        /*Calc precision error fixing.*/
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        /*Pressing arrows? Move.*/
        float arrowInput = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * arrowInput);
    }
}
