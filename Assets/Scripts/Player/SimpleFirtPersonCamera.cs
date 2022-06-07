using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFirtPersonCamera : MonoBehaviour
{

    [SerializeField] float mouseSensibility = 100f;
    [SerializeField] Transform playerBody;
    [SerializeField] float minView = -45;
    [SerializeField] float maxView = 80;
    float yRotation;
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, minView, maxView);


        transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
        playerBody.Rotate(Vector3.up, mouseX);
    }
}
