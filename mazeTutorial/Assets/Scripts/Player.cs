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
    private GameObject frontOfPlayer;
    [SerializeField]
    private GameObject sword;

    //private int layerMask 1 << 0;

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
        /* //I CAN USE THIS FOR THE MAGNET ROD!
         float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
         Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
         transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/

        /*if (Input.GetKey(KeyCode.LeftArrow) && frontOfPlayer.activeSelf == false)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && frontOfPlayer.activeSelf == false)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && frontOfPlayer.activeSelf == false)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && frontOfPlayer.activeSelf == false)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }*/

        //Vector3 characterScale = transform.localScale;

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);

        if (Input.GetAxis("Horizontal") < 0)
        {
            frontOfPlayer.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -270.0f);
            frontOfPlayer.transform.localPosition = new Vector3(-0.8000007f, -0.01999986f, 0.0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            frontOfPlayer.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
            frontOfPlayer.transform.localPosition = new Vector3(0.8000007f, -0.01999986f, 0.0f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            frontOfPlayer.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            frontOfPlayer.transform.localPosition = new Vector3(-0.01f, -0.79f, 0.0f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            frontOfPlayer.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 360.0f);
            frontOfPlayer.transform.localPosition = new Vector3(-0.01f, 0.79f, 0.0f);
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
