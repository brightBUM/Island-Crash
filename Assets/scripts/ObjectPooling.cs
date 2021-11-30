using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    public List<GameObject> pooledobjects;
    public GameObject objectTopool;
    public int amountTopool;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        pooledobjects = new List<GameObject>();
       
        for(int i=0;i<amountTopool;i++)
        {
            GameObject temp = Instantiate(objectTopool);
            temp.SetActive(false);
            pooledobjects.Add(temp);
                
        }
    }
    public GameObject getpooledobject()
    {
        for(int i=0;i<amountTopool;i++)
        {
            if(!pooledobjects[i].activeInHierarchy)
            {
                return pooledobjects[i];
            }
        }
        return null;
    }
    
}
