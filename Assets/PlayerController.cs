using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // get input
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if(verticalInput > 0)
        {
            transform.eulerAngles = Vector3.zero;
            transform.position += Vector3.forward * speed * verticalInput * Time.deltaTime;
        }
        else if(verticalInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += Vector3.forward * speed * verticalInput * Time.deltaTime;
        }
        else if(horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.position += Vector3.right * speed * horizontalInput * Time.deltaTime;
        }
        else if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
            transform.position += Vector3.right * speed * horizontalInput * Time.deltaTime;
        }
    }
}
