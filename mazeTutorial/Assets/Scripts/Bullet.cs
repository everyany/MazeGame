using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        //bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            //StartCoroutine(shoot());
            LayerMask mask = LayerMask.GetMask("collider");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 100f, mask);
            if (hit)
            {
                Debug.Log("hit " + hit.collider.name);
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    IEnumerator shoot()
    {
        bullet.SetActive(true);
        yield return new WaitForSeconds(.01f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 10f);
        if (hit)
        {
            Debug.Log("hit" + hit.collider.name);
        }
    }
}
