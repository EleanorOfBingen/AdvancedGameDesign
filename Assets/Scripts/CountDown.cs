using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private int waveNr;
    public bool countDown = true;
    public float starOverTime;
    public float timeStart;
    // show the text box in game
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        // text box is a float and need to conwert to string
        textBox.text = timeStart.ToString();
        waveNr = 1;
    }

    // Update is called once per frame
    void Update()
    {

        // keep track how much frame are in the game
        
        if (timeStart !>= 0)
        {
            timeStart -= Time.deltaTime;
        }
        textBox.text = Mathf.Round(timeStart).ToString();

        //if count down if 0 stop spawning 
        if (timeStart <= 0)
        {
          
            countDown = false;
            
            //if count down is 0 stop counting
            starOverTime -= Time.deltaTime; 
        }
        if (starOverTime <= 0)
        {
            countDown = true;
            //tid some gubbar spawnar
            waveNr = waveNr+ 1;
            timeStart = timeStart + 10*waveNr;
            //tid emellan spawn
            starOverTime = starOverTime +10*waveNr;
        }
    }
}
