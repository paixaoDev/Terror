using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocity = 2f;
    void Update()
    {
        transform.Translate (Input.GetAxis("Horizontal") * velocity * Time.deltaTime, 0, Input.GetAxis("Vertical") * velocity * Time.deltaTime);
    }
}
