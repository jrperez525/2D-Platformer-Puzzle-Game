using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Change_Scenes : MonoBehaviour {

	private int i;

	// Use this for initialization
	void Start () {
		i = SceneManager.GetActiveScene ().buildIndex;
	}
	
	void OnCollisionEnter2D(Collision2D Collider) {
		if (Collider.gameObject.tag == "Player") {
			SceneManager.LoadScene (i + 1);
		} else if (i == 8) {
			SceneManager.LoadScene (0);
		}
	}
}
