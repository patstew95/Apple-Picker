using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
//speed of apple
public float speed = 20f;

//distance whre appleTree turns around
public float leftAndRightEdge = 10f;

//chance that the apple tree will change direction

public float changeDirChance = 0.02f;

//seconds between Apples instantiation
public float appleDropDelay = 1f;

    void Start()
    {
        //start dropping apples
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // change direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }else if (Random.value < changeDirChance * Time.deltaTime)
        {
            speed *= -1; //change direction
        }
    }
}
