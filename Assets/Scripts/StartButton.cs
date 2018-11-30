using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this allows us to use the scene loading function
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    //this will be called by the button component when clicked
    public void StartGame()
    {
        //Reset score
        PlayerPrefs.DeleteKey("score");

        //Load level
        SceneManager.LoadScene("Level1");
    }
	
}
