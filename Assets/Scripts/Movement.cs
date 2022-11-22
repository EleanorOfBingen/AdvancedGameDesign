using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private float minimumSpeed = 2;
    private Vector2 rightStickPosition;

    [SerializeField]private GameObject forwardPlayer;


    [SerializeField] private float gravityValue = 9.5f;



    private bool attacking;
    private float attackTime;
    private float attackPower;

    private bool bigAttack;

    void Start()
    {
        characterController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {


        characterController.Move(new Vector3(0, -gravityValue * Time.deltaTime, 0));

        forwardPlayer.transform.position = transform.position;
        if (leftStickPosition != Vector2.zero)
        {

            movmentVector = new Vector3(leftStickPosition.x, 0, leftStickPosition.y) * speedMovement();

        }
        else
        {

            movmentVector = new Vector3(0, 0, 0);


        }
        if (attacking)
        {
           characterController.Move(forwardPlayer.transform.forward * attackPower * Time.deltaTime);
           attackTime -= Time.deltaTime;
           if(attackTime < 0)
            {
                attacking = false;

            }
        }
        else
        {

            characterController.Move(movmentVector * Time.deltaTime);
        }

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


    }
    public void SwordAttack(float duration, float force)
    {
        attacking = true;
        attackTime = duration;
        attackPower = force;
        

    }
    private void OnBigSword()
    {
        if (!bigAttack)
        {


            bigAttack = true;
        }
        else
        {

            bigAttack = false;
        }


    }
    private float speedMovement()
    {
        if (bigAttack)
        {

            return minimumSpeed;

        }
        else
        {
            return maximumSpeed;

        }

        
    }


}
