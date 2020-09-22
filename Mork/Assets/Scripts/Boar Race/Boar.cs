using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
    public float currentSpeed, boostMultiplier, slowMultiplier;
    public float speedBoostCD, slowCD;
    [HideInInspector] public float speedBoostTimeRemaining, slowTimeRemaining;
    private float speedBoostTimer, slowTimer, originalSpeed;

    //Initialize some variables
    private CharacterController controller;

    private Transform camera;

    public float smoothTurnTime = 0.2f;

    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = currentSpeed;
        controller = GetComponent<CharacterController>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the player input
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement * 10f, 0f, currentSpeed).normalized;

        //If the player pressed anymovement keys
        if (movement.magnitude >= 0.1f)
        {
            //Calculate the angle and distance of that movement
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //Make the object move
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            speedBoostTimeRemaining = Mathf.FloorToInt(speedBoostTimer % 60);
        }
        else speedBoostTimeRemaining = 0;

        if (slowTimer > Time.time)
        {
            slowTimer -= Time.deltaTime;
            slowTimeRemaining = Mathf.FloorToInt(slowTimer % 60);
        }
        else slowTimeRemaining = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Corn")){
            currentSpeed *= boostMultiplier;
            speedBoostTimer = speedBoostCD;
            Invoke("endSpeedBoost", speedBoostCD);
        }

        if (other.CompareTag("Mud"))
        {
            currentSpeed *= slowMultiplier;
            slowTimer = slowCD;
            Invoke("endSlow", slowCD);
        }
    }

    private void endSpeedBoost()
    {
        currentSpeed /= boostMultiplier;
    }

    private void endSlow()
    {
        currentSpeed /= slowMultiplier;
    }
}
