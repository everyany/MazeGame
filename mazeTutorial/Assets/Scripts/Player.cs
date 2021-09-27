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

    [SerializeField]
    private GameObject weapon;

    /*[SerializeField]
    float smooth = 5.0f;
    [SerializeField]
    private float tiltAngle = 60.0f;*/

    void Start()
    {
        win.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       //I CAN USE THIS FOR THE MAGNET ROD!
        /*float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/

        if (Input.GetKey(KeyCode.LeftArrow) && weapon.activeSelf == false)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && weapon.activeSelf == false)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && weapon.activeSelf == false)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && weapon.activeSelf == false)
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
