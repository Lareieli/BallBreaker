using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
// start with the music player set as null, then if it is null the else statement kicks in
// and asserts that THIS object created is the instance.  On the other hand, if it isn't null
// because it was instantiated in the scene, then destroy (prevent) any new music players from
// being created
	static MusicPlayer instance = null;
	
	void Awake (){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}		
		GameObject.DontDestroyOnLoad(gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
