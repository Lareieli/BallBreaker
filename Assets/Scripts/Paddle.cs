using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	public float minpaddlewidthX, maxpaddlewidthX;
	
	private Ball ball;
	
	void Start (){
		ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	void AutoPlay(){
		Vector3 paddlePosition = new Vector3 (8f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		// restricts position to no less than min and no more than max
		paddlePosition.x = Mathf.Clamp (ballPosition.x, minpaddlewidthX, maxpaddlewidthX);
		this.transform.position = paddlePosition;
	}
	void MoveWithMouse (){
		//When we construct the paddle this script is attached to
		Vector3 paddlePosition = new Vector3 (8f, this.transform.position.y, 0f);
		// declare variable mousepositioninblocks of type float and set it equal to
		//the mouse input divided by the screen width, multiplied by the number of 
		//paddle widths that will fit in the screen
		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePosition.x = Mathf.Clamp (mousePositionInBlocks, minpaddlewidthX, maxpaddlewidthX);
		// "this" is not necessary here because the transform.position applies to whatever
		//object the script is attached to already
		this.transform.position = paddlePosition;
	}
	
}
