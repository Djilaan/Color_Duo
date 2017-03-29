using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeBarController : MonoBehaviour {

    //float time;
    public Text timerLabel;
    public float maxTime = 10.0f;
    private float timeLeft;
    private float initialYpos;

    // Use this for initialization
    void Start ()
    {
        timeLeft = maxTime;
        initialYpos = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (timeLeft >= 0)
        {
            transform.Translate( Vector3.down * (10.0f + initialYpos * 2.0f) * (Time.deltaTime / maxTime) );
        }
        else
        {
            timeLeft = 0;
        }

        timerLabel.text = timeLeft.ToString();

        //Debug.Log(gameObject.transform.position.y+" "+timeLeft);

        timeLeft = timeLeft - Time.deltaTime;

    }

}
