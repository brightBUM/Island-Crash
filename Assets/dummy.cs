using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnMouseDown()
    {
        Debug.Log("entered");
        
    }
    private void OnMouseDrag()
    {

        Debug.Log("hold");
    }
    private void OnMouseUp()
    {
        Debug.Log("exited");
    }
   
}

