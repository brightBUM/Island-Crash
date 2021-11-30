using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousetest : MonoBehaviour
{
    Vector3 mousepos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mousepos = Input.mousePosition;
            Debug.Log(mousepos);
            //Debug.Log("x = " + mousepos.x + "\ny = " + mousepos.y );
            //Debug.Log("\nz = " + mousepos.z);
        }
        

    }
}
