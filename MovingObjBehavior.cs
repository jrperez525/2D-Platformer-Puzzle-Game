using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingObjBehavior : MonoBehaviour {

	protected float speedScale; // multiplied by the max speed to get the object's actual speed
	public float MAXSPEED = 5;
	public GameObject player;

	// Use this for initialization
	protected virtual void Start () {
		speedScale = 1;
	}

	protected void OnTriggerEnter2D(Collider2D obj) {
		// If colliding with the player, set the player as a child to move it with the platform
		if (obj.gameObject.tag.Equals("Player")) {
			Vector3 playerPos = obj.gameObject.transform.position;
			if (playerPos.y > transform.position.y || 
				(playerPos.y < transform.position.y && 
					obj.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ().downGravity == false)) {
				
				player.transform.parent = transform;
			} 
		}
	}

	protected void OnTriggerExit2D(Collider2D obj) {
		// When not exiting collision with player, unparent the player so it moves independently
		if (obj.gameObject.tag.Equals ("Player")) {
			player.transform.parent = null;
		}
	}

	protected virtual void Move(int x, int y) {
		float moveSpeed = speedScale * MAXSPEED;
		transform.Translate (new Vector3 (x, y, 0) * moveSpeed * Time.deltaTime);
		//Debug.Log (string.Format("Move called: {0}, {1}", x, y));
	}

	protected virtual void MoveTo(Vector2 dest) {
		float moveSpeed = speedScale * MAXSPEED;
		transform.position = Vector2.MoveTowards (transform.position, dest, moveSpeed);
	}

	public virtual void setSpeedScale(float newSpeedScale) {
		speedScale = newSpeedScale;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		

	}
}
