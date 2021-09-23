using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    [SerializeField]
    private Text textScore;
    [SerializeField]
    private int score = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            Destroy(this.gameObject);
            score++;
            textScore.text = score + ""; 
        }
    }
}
