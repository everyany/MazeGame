using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject wall;

    void Start()
    {
        weapon.SetActive(false);
        bullet.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("pressed");
            StartCoroutine(attack());
        }
        if (Input.GetKey(KeyCode.X))
        {
            shoot();
        }
    }

    IEnumerator attack()
    {
        Debug.Log("couroutine");
        weapon.SetActive(true);
        yield return new WaitForSeconds(.2f);
        weapon.SetActive(false);
    }
    void shoot()
    {
        Debug.Log("couroutine");
        bullet.SetActive(true);
        bullet.transform.position += Vector3.forward * Time.deltaTime;
    }
}
