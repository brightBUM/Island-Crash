using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{
    public Transform Zaxis;
    public Transform Xaxis;
    public Transform mid;
    public Transform cor;
    public float time_bw_spawns;
    public float top, bot, left, right;
    public int i;
    public bool spawnactive;
    public GameObject enemyboat;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(spawnrandom());
    }
    IEnumerator spawnrandom()
    {
        while(spawnactive)
        {

            yield return new WaitForSeconds(time_bw_spawns);
            //var temp = ObjectPooling.instance.getpooledobject();
            //temp.transform.position = getrandomposition();
            var temp = Instantiate(enemyboat,getrandomposition(),Quaternion.identity);
            temp.SetActive(true);
           
        }
        

    }
    public Vector3 getrandomposition()
    {
        top = Random.Range(Zaxis.position.x, cor.position.x);
        bot = Random.Range(mid.position.x, Xaxis.position.x);
        left = Random.Range(mid.position.z, Zaxis.position.z);
        right = Random.Range(cor.position.z, Xaxis.position.z);
        float[] points = { top, bot, left, right };
        i = Random.Range(0, 4);
        switch (i)
        {
            case 0:
                pos = new Vector3(points[i], Zaxis.position.y, Zaxis.position.z);
                break;
            case 1:
                pos = new Vector3(points[i], Zaxis.position.y, mid.position.z);
                break;
            case 2:
                pos = new Vector3(Zaxis.position.x, Xaxis.position.y, points[i]);
                break;
            case 3:
                pos = new Vector3(cor.position.x, Xaxis.position.y, points[i]);
                break;
        }
        return pos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
