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
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("pressed");
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        Debug.Log("couroutine");
        weapon.SetActive(true);
        yield return new WaitForSeconds(.2f);
        weapon.SetActive(false);
    }
}
