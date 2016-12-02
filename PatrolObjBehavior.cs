using UnityEngine;
using System.Collections;

public class PatrolObjBehavior : MovingObjBehavior {

	public Transform[] patrolPoints;
	private int destPoint = 0;


	// Use this for initialization
	protected override void Start () {
		base.Start ();

	}



	void GoToNextPoint() {
		if (patrolPoints.Length == 0) {
			return;
		}

		destPoint = (destPoint + 1) % patrolPoints.Length;
	}
	
	// Update is called once per frame
	protected override void Update () {
		

		if (patrolPoints.Length == 0) {
			return;
		}

		float xDist = transform.position.x - patrolPoints [destPoint].position.x;
		float yDist = transform.position.y - patrolPoints [destPoint].position.y;
		float distLeft = Mathf.Sqrt ( xDist * xDist + yDist * yDist); // a^2 + b^2 = c^2, where c is distance left
		//Debug.Log(string.Format("distLeft: {0}", distLeft));
		if (distLeft < (speedScale * MAXSPEED)) {
			GoToNextPoint ();
		}
			
		MoveTo (patrolPoints[destPoint].position);
	}
}
