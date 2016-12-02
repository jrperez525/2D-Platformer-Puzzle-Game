using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowTimeCircleBehavior : SlowTimeObjBehavior {

	private List<MovingObjBehavior> slowedObjects; // List of moving objects that are currently being slowed down

	public LayerMask whatIsCollidable; // Layers that can be checked to slow down.

	protected override void Start () {
		base.Start ();
		slowedObjects = new List<MovingObjBehavior> ();
	}


	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if (timeSlowed) {
			slowTime ();
		} else if (slowedObjects.Count > 0) {
			Debug.Log ("contacted objects count > 0");
			foreach (MovingObjBehavior m in slowedObjects) {
				m.setSpeedScale (1f);
			}
			slowedObjects.Clear ();
		}
	}

	 
	void slowTime() {
		// Check to see what objects are colliding with the slow time circle. If any object of type "movingObject" is colliding, slow it down and add it to the list of
		// slowed objects.
		float colliderAbsRadius = transform.GetComponent<CircleCollider2D>().radius * transform.parent.localScale.x;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, colliderAbsRadius, whatIsCollidable);
		List<Collider2D> collidersList = new List<Collider2D> (); // colliders needs to be converted to a list to use the Contains() method.
		for (int i = 0; i < colliders.Length; i++)
		{
			//Debug.Log ("Collision detected");
			MovingObjBehavior movingObjBehavior = colliders [i].gameObject.GetComponent<MovingObjBehavior> ();
			if (movingObjBehavior != null) {
				movingObjBehavior.setSpeedScale (0.1f);

				if (!slowedObjects.Contains (movingObjBehavior)) {
					// Add to the slowed objects list if it isn't already there.
					slowedObjects.Add (movingObjBehavior);
				}

				collidersList.Add (colliders [i]);
			}
		}


		// If any object in the slowed objects list is no longer colliding, speed it back up and remove it from the list
		foreach (MovingObjBehavior obj in slowedObjects) {
			if (!collidersList.Contains (obj.gameObject.GetComponent<Collider2D>())) {
				obj.setSpeedScale (1f);
			}
		}			
		slowedObjects.RemoveAll (item => !collidersList.Contains(item.gameObject.GetComponent<Collider2D>()));

	}
}
