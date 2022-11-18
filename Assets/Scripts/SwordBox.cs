using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBox : MonoBehaviour
{

    bool buttonPressed;
    private float attackTime;

    [SerializeField] private Attack attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            if (attackTime < 0)
            {

                buttonPressed = false;
            }

            attackTime -= Time.deltaTime;
            Debug.Log(buttonPressed);

            BoxCollider bc = GetComponent<BoxCollider>();

            Collider[] col = Physics.OverlapBox(transform.position + (Vector3.forward * 0.3f), bc.size, transform.rotation);
            foreach (Collider c in col)
            {

                if(c.gameObject.tag != "Player")
                {

                    Destroy(c.gameObject);
                    attack.AttackMeterIncrease(25);

                }

            }




        }
        



    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        //if (buttonPressed && other.tag != "Player")
        //{
           
        //   Destroy(other.gameObject);


        //}



    }
    public void ActivateAttack(float attackDuration)
    {
        
        attackTime = attackDuration;
        buttonPressed = true;
        //Debug.Log(buttonPressed);
    }
}
