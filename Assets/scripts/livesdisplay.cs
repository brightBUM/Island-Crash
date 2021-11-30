using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesdisplay : MonoBehaviour
{
    public Texture[] livestextures;
    RawImage ri;
    public Gameover go;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ri = GetComponent<RawImage>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go.lives>0)
        {
            ri.texture = livestextures[go.lives-1];
        }
    }
}
