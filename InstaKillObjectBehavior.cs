using UnityEngine;
using System.Collections;

public class InstaKillObjectBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D obj) {
		// If colliding with the player, set the player as a child to move it with the platform
		if (obj.gameObject.tag.Equals("Player")) {
			obj.gameObject.transform.position = GameObject.Find ("StartPos").transform.position;
		}
	}
}
