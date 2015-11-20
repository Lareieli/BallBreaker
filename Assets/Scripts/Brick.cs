using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smokeParticle;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
		
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keeping track of how many breakable bricks are in scene
		if (isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable){
			HandleHits ();
		}		
	}
	
	void HandleHits (){
		timesHit = timesHit + 1;
		int maxHits = hitSprites.Length +1;
		// above line can also be written as timesHit++; to increment by one
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke (){
		GameObject smokeColor = Instantiate (smokeParticle, transform.position, Quaternion.identity) as GameObject;
		smokeColor.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing!");
		}
	}
	//TODO Remove this method once win state is active
	void SimulateWin (){
		levelManager.LoadNextLevel();
	} 
}
