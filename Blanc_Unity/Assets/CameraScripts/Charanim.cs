using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class Charanim : MonoBehaviour
{


    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float DirectionDampTime = .25f;

    private float speed = 0.0f;
    private float h = 0.0f;
    private float v = 0.0f;
    public float ColliderHeight = 0.0f;
    public float smoothTime = 0.3F;
    private bool run = false;
    private bool jump = false;
    private bool IsGrounded = true;
    private bool ButtonPress = false;
    public ButtonTurn ButtonTurn;
    public CameraTurn CameraTurn;
    public float jumpHeight = 3000.0f;
    CapsuleCollider capsule;

    // Use this for initialization
    void Start()
    {
        ButtonTurn = GetComponent<ButtonTurn>();
        CameraTurn = GetComponent<CameraTurn>();
        animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        //box = GetComponent<BoxCollider>();

        run = false;
        if (animator.layerCount >= 2)
        {
            animator.SetLayerWeight(1, 1);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        IsGrounded = true;
        print("grounded");
    }


    // Update is called once per frame
    void Update()
    {

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

        if (animator)
        {
            h = Input.GetAxis("Horizontal");
            speed = Input.GetAxis("Vertical");

            CheckButton();
            //CheckRun();           

            if ((h >= .1) || (h <= -.1))
            {

                transform.Rotate(0, (h * 2), 0);
            }



            animator.SetFloat("speed", speed);
            animator.SetFloat("direction", h, DirectionDampTime, Time.deltaTime);

        }
    }

    public void CheckButton()

    {

        if ((speed >= .1) || (h >= .1) || (h <= -.1))
        {
            animator.SetBool("directionPress", true);
            ButtonPress = true;
            CameraTurn.enabled = true;
            ButtonTurn.enabled = false;

        }
        else
        {
            animator.SetBool("directionPress", false);
            ButtonPress = false;
            CameraTurn.enabled = false;
            ButtonTurn.enabled = true;
        }
    }

    //public void CheckRun()
    //{
    //    if (Input.GetKey(KeyCode.LeftShift))
    //        run = true;
    //    else
    //        run = false;


    //    if (run == true)
    //    {

    //        animator.SetBool("RunCheck", true);
    //    }
    //    if (run == false)
    //    {

    //        animator.SetBool("RunCheck", false);
    //    }
    //}
}

