using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButton : MonoBehaviour {

    //called when title button is clicked
    public void BackToTitle()
    {
        // Return to title scene
        SceneManager.LoadScene("Title");
    }

	
}
