using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    //automatically called by unity
    //when spikes touch any other object
 private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if thing colliding is player (has playerscript)
        Player playerScript = collision.collider.GetComponent<Player>();

        //Only do something if the thing we ran into was player
        if (playerScript !=null)
        {
            //WE HIT THEM
            //KILL
            playerScript.Kill();
        }

    }
}
