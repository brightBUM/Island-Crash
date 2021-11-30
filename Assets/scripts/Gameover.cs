using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public TextMeshProUGUI scoreref;
    public int lives = 3;
    public GameObject gameovercanvas;
    public GameObject scorecanvas;
    public int score;
    public float timscale;
    private bool gmover = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Enemy.playerboatcollided.AddListener(increasescore);
        //scoreref = scorecanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gmover)
        {
            scoreref.text = score.ToString();
            Time.timeScale = 1;
        }
        if (lives == 0)
        {
            gmover = true;
            gameovercanvas.SetActive(true);
            scoreref = gameovercanvas.GetComponentInChildren<TextMeshProUGUI>();
            scorecanvas.SetActive(false);
            if(gmover)
            {
                Time.timeScale = 0.5f;
            }

            scoreref.text = "Score \n" + score.ToString();
        }
        timscale = Time.timeScale;
    }

    public void quitgame()
    {
        Application.Quit();
    }
    public void loadmaingame()
    {
        SceneManager.LoadScene(1);
        gmover = false; 
    }
    
    void increasescore()
    {
        score += 5;
    }
    private void OnTriggerEnter(Collider boat)
    {
        if (boat.GetComponent<Enemy>())
        {
            lives--;
            Destroy(boat.gameObject, 0.4f);
        }
    }
    
}
