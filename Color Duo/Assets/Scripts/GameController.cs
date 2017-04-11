using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int[] leftColor = new int[4];
    private int[] rightColor = new int[4];

    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;

    private int objCorrectLeft;
    private int objCorrectRight;

    public int correct_counter;

    public Text colorLabel;

    //timebar codes
    public GameObject timebar;
    public Text timerLabel;
    public float maxTime;
    private float timeLeft;
    private float initialYpos;
    private Vector3 initialPos;

    //score codes
    public Text scoreLabel;
    public int score;

    public bool play;

    // Use this for initialization
    void Start ()
    {
        play = true;
        
        correct_counter = 0;

        generateColorsLeft();
        for(int i=0; i<leftColor.Length; i++)
        {
            Debug.Log(leftColor[i]);
        }

        applyColorsLeft();


        generateColorsRight();
        for (int i = 0; i < rightColor.Length; i++)
        {
            Debug.Log(rightColor[i]);
        }

        applyColorsRight();

        getRandomColorFromLeft();
        getRandomColorFromRight();

        //timebar
        timeLeft = maxTime;
        initialYpos = timebar.transform.position.y;
        initialPos = timebar.transform.position;

        //score
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            //timebar start
            if (timeLeft >= 0)
            {
                timebar.transform.Translate(Vector3.down * (10.0f + initialYpos * 2.0f) * (Time.deltaTime / maxTime));
            }
            else
            {
                timeLeft = 0;
            }

            timerLabel.text = timeLeft.ToString();

            //Debug.Log( gameObject.transform.position.y+" "+timeLeft );

            timeLeft = timeLeft - Time.deltaTime;
            if(timeLeft<=0)
            {
                play = false;
            }
            //time bar end
        }
        
    }

    //LEFT
    void generateColorsLeft()
    {
        for(int i=0; i<leftColor.Length; i++)
        {
            generateUniqueRandomLeft(i, 1, 7);
        }
    }

    void generateUniqueRandomLeft(int index, int minRange, int maxRange)
    {
        int num = Random.Range(minRange, maxRange);

        while (leftColorContains(num))
        {
            num = Random.Range(minRange, maxRange);
        }

        leftColor[index] = num;
    }

    bool leftColorContains(int num)
    {
        for(int i=0; i<leftColor.Length; i++)
        {
            if(leftColor[i]==num)
            {
                return true;
            }
        }

        return false;
    }

    void applyColorsLeft()
    {
        Color newColor = new Color32 (0, 0, 0, 255);

        for(int i=0; i<leftColor.Length; i++)
        {
            newColor = getColor(leftColor[i]);

            if(i==0)
            {
                Renderer rend = obj0.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            if(i==1)
            {
                Renderer rend = obj1.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            if(i==2)
            {
                Renderer rend = obj2.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            if(i==3)
            {
                Renderer rend = obj3.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            
        }

    }

    void applyColorsLeft(int i)
    {
        Color newColor = new Color32(0, 0, 0, 255);

        newColor = getColor(leftColor[i]);

        if (i == 0)
        {
            Renderer rend = obj0.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
        if (i == 1)
        {
            Renderer rend = obj1.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
        if (i == 2)
        {
            Renderer rend = obj2.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
        if (i == 3)
        {
            Renderer rend = obj3.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
    }

    void getRandomColorFromLeft()
    {
        int i = Random.Range(0, 4);

        Debug.Log("Generated number from LEFT: " + i);

        updateText(leftColor[i]);

        //update bool on cubes
        if (i == 0)
        {
            obj0.GetComponent<CubeController>().correct = true;
            objCorrectLeft = 0;
        }
        if (i == 1)
        {
            obj1.GetComponent<CubeController>().correct = true;
            objCorrectLeft = 1;
        }
        if (i == 2)
        {
            obj2.GetComponent<CubeController>().correct = true;
            objCorrectLeft = 2;
        }
        if (i == 3)
        {
            obj3.GetComponent<CubeController>().correct = true;
            objCorrectLeft = 3;
        }

    }
    //END LEFT

    //RIGHT
    void generateColorsRight()
    {
        for (int i = 0; i < rightColor.Length; i++)
        {
            generateUniqueRandomRight(i, 1, 7);
        }
    }

    void generateUniqueRandomRight(int index, int minRange, int maxRange)
    {
        int num = Random.Range(minRange, maxRange);

        while (rightColorContains(num))
        {
            num = Random.Range(minRange, maxRange);
        }

        rightColor[index] = num;
    }

    bool rightColorContains(int num)
    {
        for (int i = 0; i < rightColor.Length; i++)
        {
            if (rightColor[i] == num)
            {
                return true;
            }
        }

        return false;
    }

    void applyColorsRight()
    {
        Color newColor = new Color32(0, 0, 0, 255);

        for (int i = 0; i < rightColor.Length; i++)
        {
            newColor = getColor(rightColor[i]);

            if (i == 0)
            {
                Renderer rend = obj4.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            if (i == 1)
            {
                Renderer rend = obj5.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            if (i == 2)
            {
                Renderer rend = obj6.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
            if (i == 3)
            {
                Renderer rend = obj7.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", newColor);
            }
        }
    }

    void applyColorsRight(int i)
    {
        Color newColor = new Color32(0, 0, 0, 255);

        newColor = getColor(rightColor[i]);

        if (i == 0)
        {
            Renderer rend = obj4.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
        if (i == 1)
        {
            Renderer rend = obj5.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
        if (i == 2)
        {
            Renderer rend = obj6.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
        }
        if (i == 3)
        {
            Renderer rend = obj7.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", newColor);
         }
    }

    void getRandomColorFromRight()
    {
        int i = Random.Range(0, 4);

        Debug.Log("Generated number from RIGHT: " + i);

        updateTextColor(rightColor[i]);

        //update bool on cubes
        if (i == 0)
        {
            obj4.GetComponent<CubeController>().correct = true;
            objCorrectRight = 0;
        }
        if (i == 1)
        {
            obj5.GetComponent<CubeController>().correct = true;
            objCorrectRight = 1;
        }
        if (i == 2)
        {
            obj6.GetComponent<CubeController>().correct = true;
            objCorrectRight = 2;
        }
        if (i == 3)
        {
            obj7.GetComponent<CubeController>().correct = true;
            objCorrectRight = 3;
        }

    }
    //END RIGHT

    Color getColor(int index)
    {
        Color newColor = new Color32(0, 0, 0, 255);

        //black
        if(index == 0)
        {
            newColor = Color.black;
        }
        //red
        else if (index == 1)
        {
            newColor = Color.red;
        }
        //blue
        else if (index == 2)
        {
            newColor = new Color32(0, 128, 255, 255);
        }
        //yellow
        else if (index == 3)
        {
            newColor = Color.yellow;
        }
        //purple
        else if (index == 4)
        {
            newColor = new Color32(255, 0, 255, 255);
        }
        //green
        else if (index == 5)
        {
            newColor = Color.green;
        }
        //orange
        else if (index == 6)
        {
            newColor = new Color32(255, 102, 0, 255);
        }

        return newColor;
    }

    void updateText(int i)
    {

        if (i == 1)
        {
            colorLabel.text = "RED";
        }
        else if (i == 2)
        {
            colorLabel.text = "BLUE";
        }
        else if (i == 3)
        {
            colorLabel.text = "YELLOW";
        }
        else if (i == 4)
        {
            colorLabel.text = "PURPLE";
        }
        else if (i == 5)
        {
            colorLabel.text = "GREEN";
        }
        else if (i == 6)
        {
            colorLabel.text = "ORANGE";
        }

    }

    void updateTextColor(int i)
    {
        Color newColor = getColor(i);

        colorLabel.color = newColor;
    }

    //reset time left
    //generate new color and apply to correct obj
    //generate new label
    public void nextScreen()
    {
        //reset time left
        correct_counter = 0;
        Debug.Log("time: " + (maxTime - timeLeft) );
        maxTime = 0.99f * maxTime;
        timeLeft = maxTime;
        timebar.transform.position = initialPos;

        //generate new color and apply to correct obj
        generateUniqueRandomLeft(objCorrectLeft, 1, 7);
        applyColorsLeft(objCorrectLeft);
        generateUniqueRandomRight(objCorrectRight, 1, 7);
        applyColorsRight(objCorrectRight);

        //generate new label
        getRandomColorFromLeft();
        getRandomColorFromRight();
    }

}
