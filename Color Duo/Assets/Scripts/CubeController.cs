using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;
    public float rotationZ = 0.0f;
    public bool correct = false;

    public GameObject controller;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("changeColor", 0.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateCube(rotationX, rotationY, rotationZ);
    }

    void OnMouseDown()
    {
        this.GetComponent<Animator>().Play("shrink1");

        Debug.Log(name+" clicked");
        if (correct)
        {

            this.GetComponent<Animator>().Play("shrink1");

            controller.GetComponent<GameController>().correct_counter++;
            correct = false;

            if (controller.GetComponent<GameController>().correct_counter >= 2)
            {
                Debug.Log("BOTH CORRECT");
                controller.GetComponent<GameController>().nextScreen();
                //update score
                controller.GetComponent<GameController>().score++;
                controller.GetComponent<GameController>().scoreLabel.text = controller.GetComponent<GameController>().score.ToString();
            }
            else if (controller.GetComponent<GameController>().correct_counter == 1)
            {
                Renderer rend = this.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_Color", new Color32(64, 64, 64, 255) );
            }
            
        }
        else
        {
            Debug.Log("NOT CORRECT");
        }
    }

    void rotateCube(float x, float y, float z)
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

}
