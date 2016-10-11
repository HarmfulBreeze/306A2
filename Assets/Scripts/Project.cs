using UnityEngine;
using System.Collections;

public class Project : MonoBehaviour {
    public float max = 8f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        Vector3 velocity = new Vector3(0, max * Time.deltaTime, 0);
        position += transform.rotation * Quaternion.Euler(0, 0, -90) * velocity;
        transform.position = position;
    }
}
