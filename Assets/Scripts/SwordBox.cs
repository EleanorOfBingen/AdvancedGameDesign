using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBox : MonoBehaviour
{

    bool buttonPressed;
    private float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            attackTime -= Time.deltaTime;
            Debug.Log(buttonPressed);

            if (attackTime < 0)
            {
                
                buttonPressed = false;
            }
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (buttonPressed && other.tag != "Player")
        {
           
            Destroy(other.gameObject);


        }



    }
    public void ActivateAttack(float attackDuration)
    {
        
        attackTime = attackDuration;
        buttonPressed = true;
        //Debug.Log(buttonPressed);
    }
}
