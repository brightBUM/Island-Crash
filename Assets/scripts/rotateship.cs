using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateship : MonoBehaviour
{
    public float rotspeed;
    public GameObject boat;
    public float incspeed = 10;
    public float temp;
    
    // Start is called before the first frame update
    void Start()
    {
        temp = rotspeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotspeed * Time.deltaTime, 0));
        
    }
   
    public void tapclick()
    {
        rotspeed = -rotspeed;
        boat.transform.Rotate(0, 180, 0);
        temp = rotspeed;
    }
    public void holdclick()
    {
        //temp = rotspeed;
        if(rotspeed>0)
        {
            rotspeed += incspeed * Time.deltaTime;
        }
        else if(rotspeed<0)
        {
            rotspeed -= incspeed * Time.deltaTime;
        }
    }

    public void releasedclick()
    {
        rotspeed = temp;
    }
    
    
}
