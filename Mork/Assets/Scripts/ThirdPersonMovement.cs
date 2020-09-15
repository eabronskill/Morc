using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //Initialize some variables
    public CharacterController controller;

    public Transform camera;

    public float speed = 6f;

    public float smoothTurnTime = 0.2f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        //Get the player input
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

        //If the player pressed anymovement keys
        if (movement.magnitude >= 0.1f)
        {
            //Calculate the angle and distance of that movement
            float targetAngle = Mathf.Atan2(movement.x,movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //Make the object move
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }
}
