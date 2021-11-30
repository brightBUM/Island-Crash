using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    [SerializeField]GameObject brokenboatref;

    GameObject mainboat;
    GameObject brokenboat;
    public Vector3[] fracturedboat;
    
    private void OnEnable()
    {
        StoreOriginalPositions();
    }
    void Start()
    {
        
        mainboat = transform.GetChild(0).gameObject;
        brokenboat = transform.GetChild(1).gameObject;
        brokenboat.SetActive(false);
        mainboat.SetActive(true);
    }
    void StoreOriginalPositions()
    {
        fracturedboat = new Vector3[brokenboatref.transform.childCount];
        for (int i =0;i< brokenboatref.transform.childCount; i++)
        {
            fracturedboat[i] = brokenboatref.transform.GetChild(i).transform.position;
        }
    }

    void resetbodypositions()
    {
        for (int i = 0; i < brokenboatref.transform.childCount; i++)
        {
            var currentchild = brokenboatref.transform.GetChild(i);
            currentchild.transform.position = fracturedboat[i];
            currentchild.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            resetboat();
        }
    }
    void breakboat()
    {
        mainboat.SetActive(false);
        for (int i = 0; i < brokenboatref.transform.childCount; i++)
        {
            var currentchild = brokenboatref.transform.GetChild(i);
            currentchild.GetComponent<Rigidbody>().isKinematic = false;
        }
        brokenboat.SetActive(true);
    }
   
    public Rigidbody rb;
    void resetboat()
    {
        
        //rb.angularVelocity = new Vector3(0, 0, 0);
        //rb.velocity = new Vector3(0, 0, 0);
        resetbodypositions();

        brokenboat.SetActive(false);

        mainboat.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        breakboat();
        
    }
}
