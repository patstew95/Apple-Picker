using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;
//speed of apple
public float speed = 10f;

//distance whre appleTree turns around
public float leftAndRightEdge = 10f;

//chance that the apple tree will change direction

public float changeDirChance = 0.02f;

//seconds between Apples instantiation
public float appleDropDelay = 1.1f;

public float branchDropDelay = 5f;

    void Start()
    {
        //start dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropBranch", 4f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>( applePrefab);
        apple.transform.position = transform.position;
        
        Invoke("DropApple", appleDropDelay);
    }
    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>( branchPrefab);
        branch.transform.position = transform.position;
        //push the next apple back so it does not drop on top of this branch
        CancelInvoke("DropApple");
        Invoke("DropApple", appleDropDelay);
        Invoke("DropBranch", branchDropDelay);
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
        }
        //else if (Random.value < changeDirChance * Time.deltaTime)
        //{
            //speed *= -1; //change direction
       // }
    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance * Time.fixedDeltaTime){
            speed *= -1;
        }
    }
}
