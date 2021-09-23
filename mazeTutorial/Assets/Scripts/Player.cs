using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private Text textScore;
    [SerializeField]
    private int score = 0;

    [SerializeField]
    private Text win;

    void Start()
    {
        win.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "diamond")
        {
            Destroy(collision.gameObject);
            score++;
            textScore.text = "Score: " + score;
        }

        if(collision.gameObject.tag == "princess")
        {
            Debug.Log("collided");
            if(score >= 3)
            {
                speed = 0.0f;
                win.enabled = true;
            }
        }
    }
}
