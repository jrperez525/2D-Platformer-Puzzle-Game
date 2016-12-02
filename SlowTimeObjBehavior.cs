using UnityEngine;
using System.Collections;

public class SlowTimeObjBehavior : MonoBehaviour {

	protected bool timeSlowed;
	protected Vector3 slowPos;
	protected float decayRate; // Rate at which the life goes down each frame.
	protected const float MAXLIFE = 0.9f; // Maximum life of the slow time effect
	protected float life; // Current life of the slow time effect. Once it reaches zero, the slow time effect is removed

	// Use this for initialization
	protected virtual void Start () {
		timeSlowed = false;
		decayRate = 0.0025f;
		life = 0f;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (Input.GetMouseButtonDown (0) && !timeSlowed) {
			// Left click = slow time
			timeSlowed = true;
			life = MAXLIFE;
		} else if (Input.GetMouseButtonDown (1) && timeSlowed) {
			// Right click = cancel slow time
			timeSlowed = false;
			life = 0;
		}

		// Decrease the life of the current slow time effect until it reaches 0, then turn off the effect.
		if (life >= decayRate) {
			life -= decayRate;
		} else {
			timeSlowed = false;
		}

		if (!timeSlowed) {
			followMouse ();
		} else {
			transform.position = new Vector3(slowPos.x, slowPos.y, transform.position.z);
		}
	}

	public float getDecayRate() {
		return decayRate;
	}

	public void setDecayRate(float newDecayRate) {
		decayRate = newDecayRate;
	}

	protected void followMouse() {
		slowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(slowPos.x, slowPos.y, transform.position.z);
	}
}
