using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour {

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;
    public float rotationZ = 0.0f;
    public bool correct = false;

    public GameObject controller;
    GameController gc;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("changeColor", 0.0f, 1.0f);
        gc = controller.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.play)
        {
            rotateCube(rotationX, rotationY, rotationZ);
        }
    }

    void OnMouseDown()
    {

        if (gc.play)
        {
            //this.GetComponent<Animator>().Play("shrink1");

            Debug.Log(name + " clicked");

            if (correct)
            {

                this.GetComponent<Animator>().Play("shrink1");

                gc.correct_counter++;
                correct = false;

                if (gc.correct_counter >= 2)
                {
                    Debug.Log("BOTH CORRECT");
                    gc.nextScreen();
                    //update score
                    gc.score++;
                    gc.scoreLabel.text = gc.score.ToString();



                }
                else if (gc.correct_counter == 1)
                {
                    Renderer rend = this.GetComponent<Renderer>();
                    rend.material.shader = Shader.Find("Specular");
                    rend.material.SetColor("_Color", new Color32(64, 64, 64, 255));
                }

            }
            else
            {
                Debug.Log("NOT CORRECT");

                PlayerPrefs.SetInt("currentScore", gc.score);

                if (gc.score > PlayerPrefs.GetInt("highScore"))
                {
                    PlayerPrefs.SetInt("highScore", gc.score);
                }

                this.GetComponent<Animator>().Play("expand");

                // SceneManager.LoadScene("gameOver");
                gc.play = false;

                
            }
        }

    }

    void rotateCube(float x, float y, float z)
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

}
