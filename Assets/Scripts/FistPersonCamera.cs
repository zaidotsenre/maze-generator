using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistPersonCamera : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float rotationSpeed = 5;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        // get input
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float mouseInput = Input.GetAxis("Mouse X");

        // move
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * mouseInput * Time.deltaTime * rotationSpeed);
        
    }
}
