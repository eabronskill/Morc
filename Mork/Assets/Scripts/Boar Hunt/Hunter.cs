using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public float currentSpeed, boostMultiplier, slowMultiplier;
    public float speedBoostCD, slowCD;
    public float jumpHeight;
    [HideInInspector] public float speedBoostTimeRemaining, slowTimeRemaining;
    //Initialize some variables
    private CharacterController controller;

    private Transform camera;

    public float smoothTurnTime = 0.2f;

    float turnSmoothVelocity;

    private GameObject spearPrefab;
    private Transform attackPoint;
    public float spearSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        spearPrefab = Resources.Load("SpearPrefab") as GameObject;
        attackPoint = GameObject.Find("AttackPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject spear = Instantiate(spearPrefab);
            spear.transform.position = attackPoint.position;
            spear.transform.rotation = attackPoint.rotation;
            spear.transform.forward = attackPoint.forward; //make camera based later
            spear.GetComponent<Rigidbody>().velocity = spear.transform.forward * spearSpeed;
        }

        //Get the player input
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

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
}
