using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
     // Start is called before the first frame update
    public static float bottomY = -20f;


    // Update is called once per frame
    void Update()
    {
        if( transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // get reference to the ApplePPicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            ;
        }
    }
}
