using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour
{

    // Need this for our character movement.
    public float speed;
    public AudioClip death;

    Animator animation;

    void Start()
    {
        animation = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        /*Can be float but the var will just make it whatever value we need it to be!*/
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        /*Hey! Look at this, and quaternion will turn towards the mouse.*/
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

        /*Rotate to look at mouse.*/
        transform.rotation = rotation;

        /*Limit to only Z rotation.*/
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        /*Calc precision error fixing.*/
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        /*Pressing arrows? Move.*/
        float arrowInput = Input.GetAxis("Vertical");
        animation.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * arrowInput);
    }

    /*If the player dies we need to take care of him. Once hit, remove from view and respawn.*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*If we come into contact with spider.*/
        if(collision.gameObject.tag == "spider")
        {
            Renderer[] rendsArray = GetComponentsInChildren<Renderer>();
            /*Cycle through all the lists of renderers.*/
            foreach (Renderer r in rendsArray)
                r.enabled = false;

			/*Attribution for sound http://soundbible.com/1791-Torture.html*/


            /*Make the player death noise once obtained.*/
            AudioSource playerDeath = GetComponent<AudioSource>();
            playerDeath.PlayOneShot(death);

            /*Pause game in order for player to respawn.*/
            StartCoroutine(pauseGame());
            GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
    IEnumerator pauseGame()
    {
        yield return new WaitForSeconds(2);
        /*While obsolete, this is an easy way to reload the game itself.*/
        Application.LoadLevel(Application.loadedLevel);
    }
}
