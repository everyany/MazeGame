using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    void Start()
    {
        weapon.SetActive(false);
    }

    void Update()
    {
        while (Input.GetKey(KeyCode.A))
        {
            Debug.Log("pressed");
            weapon.SetActive(true);
        }
        weapon.SetActive(false);
    }
}
