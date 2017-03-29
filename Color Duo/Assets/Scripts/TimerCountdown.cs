using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerCountdown : MonoBehaviour {

    public Text timerLabel;
    public float maxTime = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        maxTime = maxTime - Time.deltaTime;

        if(maxTime<0)
        {
            maxTime = 0;
        }

        timerLabel.text = maxTime.ToString();
	}
}