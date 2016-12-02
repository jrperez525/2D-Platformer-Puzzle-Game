using UnityEngine;
using System.Collections;

public class SlowTimeOverlayBehavior : SlowTimeObjBehavior {

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		setAlpha (life);
	}

	public void setAlpha(float alpha) {
		Color tmp = GetComponent<SpriteRenderer> ().color;
		tmp.a = alpha;
		GetComponent<SpriteRenderer> ().color = tmp;
	}
}
