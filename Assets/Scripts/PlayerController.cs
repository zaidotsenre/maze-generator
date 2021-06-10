using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] Animator animator;

    CharacterController characterController;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        EventBroker.onWin.AddListener(Disable);
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 motion = new Vector3(horizontalInput, 0, verticalInput);
        characterController.Move(motion * speed * Time.deltaTime);
        if (characterController.velocity.magnitude != 0)
            animator.Play("Running");
        else
            animator.Play("Breathing Idle");
        

        Vector3 direction = transform.position + (motion != Vector3.zero ? motion : Vector3.forward);
        transform.LookAt(direction);
    }

    void Disable()
    {
        enabled = false;
    }
}
