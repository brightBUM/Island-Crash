using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Gameover island;
    public float movespeed;
    public float destroytime = 2f;
    GameObject mainboat;
    GameObject brokenboatref;
    [SerializeField]GameObject brokenboatprefab;
    bool canmove = true;
    public GameObject Vfx;
    public static UnityEvent playerboatcollided =new UnityEvent();

    public AudioClip[] collisionsounds = new AudioClip[3];
    public AudioSource AS;
    // Start is called before the first frame update
    private void Awake()
    {
        AS.clip = collisionsounds[Random.Range(0, 3)];
    }
    private void Start()
    {
        island = FindObjectOfType<Gameover>();
        setupboat();

    }
    
    public void setupboat()
    {
        mainboat = transform.GetChild(0).gameObject;
        brokenboatref = transform.GetChild(1).gameObject;
        brokenboatref.SetActive(false);
        mainboat.SetActive(true);
        canmove = true;
    }
    
    public void brokenboatactive()
    {
        mainboat.SetActive(false);
        brokenboatref.SetActive(true);
        canmove = false;
        Destroy(this.gameObject, 2f);
        
    }
    //private IEnumerator destroyaftersometime()
    //{
    //    yield return new WaitForSeconds(destroytime);
    //    this.gameObject.SetActive(false);
    //}
    // Update is called once per frame
    void Update()
    {
        if(canmove)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, island.transform.position, movespeed * Time.deltaTime);
            transform.LookAt(island.transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            if (Enemy.playerboatcollided != null)
            {
                var temp = Instantiate(Vfx, transform.position, Quaternion.identity);
                AS.Play();
                Destroy(temp, 2f);
                playerboatcollided.Invoke();
            }
            //island.score += 5;
            brokenboatactive();
        }
    }
    
    
}
