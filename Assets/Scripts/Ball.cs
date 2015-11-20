using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public AudioSource audio;
	private Paddle paddle;	
	private bool gameHasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		
		if (!gameHasStarted){
			// this = ball (the object the ball script is attached to)
			// Lock the ball in place relative to the paddle position
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for a mouse press to launch
		if (Input.GetMouseButtonDown(0)) {
			gameHasStarted = true;
			// set the starting speed and direction of the ball in two axes
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.02f), Random.Range(0f, 0.02f));
		if (gameHasStarted) {
			audio.Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
