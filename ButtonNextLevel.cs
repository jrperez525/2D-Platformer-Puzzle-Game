using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//This script will be attached to a game object called LevelChanger
//LevelChanger will placed under the OnClick() function inside each of the UI buttons
//From there, you will be able to select the NextLevelButton function and insert the correct integer for
//the desired level 
public class ButtonNextLevel : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextLevelButton(int index)
    {
        SceneManager.LoadScene(index);
    }

}
