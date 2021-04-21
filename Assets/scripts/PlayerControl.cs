using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed = 400;
    private int score;
    public Text scoreText;
    private GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        
        score = 0;
        scoreText.text = "Score = " + score;
    }

    void FixedUpdate()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movH, 0.0f, movV);
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(movement*speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pickup")
       {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score = " + score;
        }
        if(other.gameObject.tag == "NotPickUp")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            controller.EndGame();
        }
    }
}
