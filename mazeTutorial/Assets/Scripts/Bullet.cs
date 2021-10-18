using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    //
    /*private GameObject metalObject;
    private Transform center;
    private Vector2 axis = Vector2.up;
    private Vector2 desiredPosition;
    [SerializeField] 
    private float radius = 2.0f;
    [SerializeField]
    private float radiusSpeed = 0.5f;
    [SerializeField]
    private float rotationSpeed = 80.0f;*/
    //

    bool coolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))//raycaster for gadgets
        {
            //StartCoroutine(shoot());
            LayerMask mask = LayerMask.GetMask("collider");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 100f, mask);
            if (hit)
            {
                Debug.Log("hit " + hit.collider.name);
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;

                /*metalObject = hit.transform.gameObject;
                center = metalObject.transform;
                player.transform.position = (transform.position - center.position).normalized * radius + center.position;
                radius = 2.0f;

                transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
                desiredPosition = (transform.position - center.position).normalized * radius + center.position;
                transform.position = Vector2.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);*/
            }
        }
        if (Input.GetKey(KeyCode.C) && coolDown == false)
        {
            StartCoroutine(projectile());
        }
    }

    /*IEnumerator shoot()//raycaster for gadgets
    {
        bullet.SetActive(true);
        yield return new WaitForSeconds(.01f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 10f);
        if (hit)
        {
            Debug.Log("hit" + hit.collider.name);
        }
    }*/

    IEnumerator projectile()
    {
        coolDown = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(.3f);
        coolDown = false;
    }
}
