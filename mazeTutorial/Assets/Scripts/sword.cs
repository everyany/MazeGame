using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject wall;

    bool coolDown = false;

    void Start()
    {
        weapon.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && coolDown == false)
        {
            Debug.Log("pressed");
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        coolDown = true;
        Debug.Log("couroutine");
        weapon.SetActive(true);
        yield return new WaitForSeconds(.3f);
        weapon.SetActive(false);
        coolDown = false;
    }
}
