using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class JumpProvider : LocomotionProvider
{

    public float speed = 1.0f;
    public float gravityMultiplier = 1.0f;
    private float gm = .0f;
    public bool canJump = true;

    private Rigidbody r;

    public List<XRController> controllers = null;

    private CharacterController characterController = null;
    private GameObject head = null;

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
        r = GetComponent<Rigidbody>();
    }



    private void Start()
    {
        
    }

    private void FixedUpdate()
    {

        CheckForInput();
        ApplyGravity();

    }





    private void CheckForInput()
    {
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        bool primButton = false;
        bool secButton = false;



        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primButton) && canJump == true) //checks to see if button is readable
        {
            if (primButton == true)
            {
                //StartJump(primButton); //jump function
                StartCoroutine(jumpRoutine()); //jump coroutine (ienum with jump lock)
                primButton = false;
            }

        }

        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out secButton) && canJump == true) //checks to see if button is readable
        {
            if (secButton == true)
            {
                StartCoroutine(jumpRoutineHigh()); //jump coroutine (ienum with jump lock)
                secButton = false;
            }

        }
    }




    // JUMP ROUTINE HIGH IS FOR KINEMATIC, NON-FORCE BASED JUMPING

    IEnumerator jumpRoutineHigh() //for the high jump
    {
        canJump = false; //used when ground detection is off to stop infinte jumping

        gm = gravityMultiplier; //stores OG gravity multiplier value
        int airTime = 0; //counter for airtime
        float theWait = 0f;


        //print(SceneManagement.thisLevel);
        if (SceneManagement.thisLevel == "Indoor_Scene" || SceneManagement.thisLevel == "Onbording") //actually current scene but named backwards!
        {
            //print("We're indoors");
            theWait = .057f;
        }

        else
        {
            //print("We're outdoors");
            theWait = .1f;
        }
        

        //float theWait = .057f; //wait time between velocity changes (larger = higher jump)

        gravityMultiplier = -5 * gravityMultiplier / 2; // divided by 2 so there's less of a gap between the final acceleration downward and normal gravity

        while (airTime < 8)
        {
            yield return new WaitForSeconds(theWait); //delay only possible in IEnumerator

            gravityMultiplier = .8f * gravityMultiplier;

            airTime += 1;
        }

        float gmHold = gravityMultiplier; // holds minimum velocity before 0

        gravityMultiplier = 0f; // 0 velocity stall

        yield return new WaitForSeconds(theWait);

        gravityMultiplier = -gmHold; // reverses direction of gravity

        while (airTime > -10)
        {
            yield return new WaitForSeconds(theWait);

            gravityMultiplier = 1.12f * gravityMultiplier; //scales gravity back to normal direction in relation to airtime steps remaining

            airTime += -1;
        }

        yield return new WaitForSeconds(theWait); //only possible in IEnumerator

        gravityMultiplier = gm; //resets to original gravity

        yield return new WaitForSeconds(theWait*5); //only possible in IEnumerator

        canJump = true; //used when ground detection is off to stop infinte jumping

        airTime = 0; //resets airtime counter
    }

    IEnumerator jumpRoutine()
    {
        canJump = false; //used when ground detection is off to stop infinte jumping

        gm = gravityMultiplier; //stores OG gravity multiplier value
        int airTime = 0; //counter for airtime
        float theWait = .05f; //wait time between velocity changes (larger = higher jump)

        gravityMultiplier = -2 * gravityMultiplier;

        while (airTime < 8)
        {
            yield return new WaitForSeconds(theWait); //delay only possible in IEnumerator

            gravityMultiplier = .8f * gravityMultiplier;

            airTime += 1;
        }

        float gmHold = gravityMultiplier; // holds minimum velocity before 0

        gravityMultiplier = 0f; // 0 velocity stall

        yield return new WaitForSeconds(theWait);

        gravityMultiplier = -gmHold; // reverses direction of gravity

        while (airTime > 0)
        {
            yield return new WaitForSeconds(theWait);

            gravityMultiplier = 1.12f * gravityMultiplier; //scales gravity back to normal direction in relation to airtime steps remaining

            airTime += -1;
        }

        yield return new WaitForSeconds(theWait); //only possible in IEnumerator

        gravityMultiplier = gm; //resets to original gravity

        yield return new WaitForSeconds(theWait*5); //only possible in IEnumerator

        canJump = true; //used when ground detection is off to stop infinte jumping


    }





    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0); //gravity only in y direction, multiplied by multiplier
        gravity.y *= Time.deltaTime;

        characterController.Move(gravity * Time.deltaTime);
    }
}
