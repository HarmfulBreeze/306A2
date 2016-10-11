using UnityEngine;
/*Include following for drawing text on screen.*/
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static int currentScore;
	Text words;


	// Use this for initialization
	void Start () {
		words = GetComponent<Text> ();
		currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		words.text = "Current Score: " + currentScore;
	}
}
