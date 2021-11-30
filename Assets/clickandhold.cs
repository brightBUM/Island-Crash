using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class clickandhold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI holdtext;
    [SerializeField] private Slider slider;
    [SerializeField] private rotateship rotateship;
    [SerializeField] private float sliderdecvalue = 20;
    public float ClickDuration = 2;
    

    bool clicking = false;
    float totalDownTime = 0;

    private void Start()
    {
        holdtext.gameObject.SetActive(false);
        Enemy.playerboatcollided.AddListener(increaseslidervalue);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            rotateship.tapclick();
            clicking = true;
            
        }

        
        if (clicking && Input.GetMouseButton(0))
        {
            totalDownTime += Time.deltaTime;

            if (totalDownTime >= ClickDuration)
            {
                if(slider.value>=25)
                {
                    
                    slider.value -= sliderdecvalue * Time.deltaTime;
                    rotateship.holdclick();
                }
                else
                {
                    
                }
            }
        }
        if(slider.value >= 25)
        {
            holdtext.gameObject.SetActive(true);
        }
        else
        {
            holdtext.gameObject.SetActive(false);
        }
        
        if (clicking && Input.GetMouseButtonUp(0))
        {
            totalDownTime = 0;
            rotateship.releasedclick();
            clicking = false;
        }
    }

    void increaseslidervalue()
    {
        slider.value += 10;
    }
}
