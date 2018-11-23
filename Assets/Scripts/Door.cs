using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add extra using statement to use scene management functins
using UnityEngine.SceneManagement;



public class Door : MonoBehaviour {

    //variable to let us save the score
    // public so we can drag and drop
    public Score scoreObject;

    //designer variables
    public string sceneToLoad;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if thing colliding is player (has playerscript)
        Player playerScript = collision.collider.GetComponent<Player>();

        //Only do something if the thing we ran into was player
        if (playerScript != null)
        {
            //WE HIT THEM
            //Save the score using scor eobject reference
            scoreObject.SaveScore();

            //LOAD NEXT LEVEL
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}
