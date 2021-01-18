using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
   
    public float speed = 1.0f;


    //private Rigidbody r;

    public List<XRController> controllers = null;

    [SerializeField]
    public GameObject menuCanvas;
    private bool menuIsOpening = false;

    //[SerializeField]
    //public GameObject checklist;

    [SerializeField]
    public GameObject map;

    private CharacterController characterController = null;
    private GameObject head = null;

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
        //r = GetComponent<Rigidbody>();
    }

    

    private void Start()
    {
        PositionController();
        
    }

    private void FixedUpdate()
    {
        PositionController();
        CheckForInput();
       


    }

    

    private void PositionController()
    {
        // Get the head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;

        // Cut in half, add skin
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        // Let's move the capsule in local space as well
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        // Apply new position to player
        characterController.center = newCenter;

    }

    private void CheckForInput()
    {
        foreach(XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
                

                if (menuIsOpening == false)
                {
                    StartCoroutine(CheckForMenu(controller.inputDevice));
                    //CheckForMenu(controller.inputDevice);
                }

            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {

        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position)) //checks to see if joystick is readable
        {
            StartMove(position);
        }
        
    }

    IEnumerator CheckForMenu(InputDevice device)
    {

        bool primButton = false;
        //bool secButton = false;



        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primButton)) //checks to see if button is readable
        {
            if (primButton == true)
            {
                menuIsOpening = true;
                //menuCanvas.GetComponent("Checklist_Panel").gameObject.SetActive(false);
                //menuCanvas.GetComponent("map").gameObject.SetActive(false); 
                //checklist.gameObject.SetActive(false);
                map.gameObject.SetActive(false);
                menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf); ; //jump coroutine (ienum with jump lock)
                yield return new WaitForSeconds(.5f);
                yield return null;
                primButton = false;
                menuIsOpening = false;
            }

        }
    }


   


    

    private void StartMove(Vector2 position)
    {
        // Apply the touch position to the head's forward Vector
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        // Rotate the input direction by the horizontal head rotation
        direction = Quaternion.Euler(headRotation) * direction; //looking to see what direction the joystick is in and rotate in adjustment to head rotation

        // Apply speed and move
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);

    }

}
