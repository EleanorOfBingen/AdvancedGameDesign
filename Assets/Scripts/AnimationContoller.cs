using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationContoller : MonoBehaviour
{
    public Animator m_Animator;

    private Vector2 leftStickPosition;
    private bool bigSwordPressed;
    private bool swordPressed;
    
    
    private void Update()
    {
        
        

        if (leftStickPosition != Vector2.zero)
        {
            
            m_Animator.SetTrigger("Walk");
            m_Animator.ResetTrigger("Idal");
        }
        else
        {
            
            m_Animator.SetTrigger("Idal");
            m_Animator.ResetTrigger("Walk");
        }
      
        
    }
    private void OnMove(InputValue movementValue)
    {
        leftStickPosition = movementValue.Get<Vector2>();
    }
    private void OnSword()
    {
        if (!swordPressed)
        {
             m_Animator.SetTrigger("Attack");
             m_Animator.ResetTrigger("Idal");
             Debug.Log("Sword");
             swordPressed = true;
        }
        else
        {
            Debug.Log("SUnpressed");
            m_Animator.SetTrigger("Idal");
            m_Animator.ResetTrigger("Attack");
            swordPressed = false;
        }
       
    }

    private void OnBigSword()
    {
        if (!bigSwordPressed)
        {
            
            Debug.Log("pressed");
            bigSwordPressed = true;
            m_Animator.SetTrigger("Smash");

        }
        else
        {
            Debug.Log("Unpressed");
            m_Animator.SetTrigger("SmashAttack");
            bigSwordPressed = false;
        }
        
    }
}