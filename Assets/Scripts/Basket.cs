using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreCounter scoreCounter;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the current screen position from the mouse fromInput
        Vector3 mousePos2D = Input.mousePosition;


        mousePos2D.z = -Camera.main.transform.position.z;

        //convert oint from 2d into 3d game world
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // move x position if thhis basket to th x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter( Collision coll)
    {
        //find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if( collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            // increase core
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score);
        }
        else if( collidedWith.CompareTag("Branch"))
        {
            //catching a branch ends the game immediately
            Destroy(collidedWith);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.GameOver();
        }
    }
}
