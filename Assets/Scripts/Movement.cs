using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController characterController;

    private Vector2 leftStickPosition;

    private Vector3 movmentVector;
    [SerializeField] private float maximumSpeed = 10;
    private Vector2 rightStickPosition;

    [SerializeField]private GameObject forwardPlayer;
    void Start()
    {
        characterController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {

        if(leftStickPosition != Vector2.zero)
        {

            movmentVector = new Vector3(leftStickPosition.x, 0, leftStickPosition.y) * maximumSpeed;

        }
        else
        {

            movmentVector = new Vector3(0, 0, 0);


        }
        
        characterController.Move(movmentVector * Time.deltaTime);

    }

    private void OnMove(InputValue movementValue)
    {
        leftStickPosition = movementValue.Get<Vector2>();
        rightStickPosition = movementValue.Get<Vector2>();

        if (rightStickPosition != Vector2.zero)
        {
            float angle = Mathf.Atan2(rightStickPosition.x, rightStickPosition.y) * Mathf.Rad2Deg;
            forwardPlayer.transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        //if (rightStickPosition != Vector2.zero)
        //{
        //    float angle = Mathf.Atan2(leftStickPosition.x, leftStickPosition.y) * Mathf.Rad2Deg;
        //    forwardPlayer.transform.rotation = Quaternion.Euler(0, angle, 0);
        //}
    }


    //public void OnLook(InputValue lookValue)
    //{
    //    rightStickPosition = lookValue.Get<Vector2>();

    //    if (rightStickPosition != Vector2.zero)
    //    {
    //        float angle = Mathf.Atan2(rightStickPosition.x, rightStickPosition.y) * Mathf.Rad2Deg;
    //        forwardPlayer.transform.rotation = Quaternion.Euler(0, angle, 0);
    //    }
    //}
}
