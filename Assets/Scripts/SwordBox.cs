using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBox : MonoBehaviour
{

    bool buttonPressed;
    private float attackTime;
    public List<Collider> col;
    [SerializeField] private Attack attack;

    private float force = 10;
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

            //Collider[] col = Physics.OverlapBox(transform.position + (Vector3.forward * 0.3f), bc.size/2, transform.rotation);
            for (var i = col.Count - 1; i > -1; i--)
            {
                if (col[i] == null)
                    col.RemoveAt(i);
            }

            foreach (Collider c in col)
            {

                if(c.gameObject.tag != "Player" && c != null)
                {

                    Destroy(c.gameObject, 0.5f);
                    Vector3 pushdirections = (c.gameObject.transform.position - transform.position).normalized;

                    c.gameObject.transform.Translate(pushdirections * force * Time.deltaTime);
                    attack.AttackMeterIncrease(10);

                }

            }
     

            col = new List<Collider>();


        }
        



    }
    private void OnTriggerStay(Collider other)
    {

        if (col.IndexOf(other) < 0)
        {

            col.Add(other);


        }
        //Debug.Log(other.name);
        if (buttonPressed && other.tag != "Player")
        {
           
         


        }



    }
    private void OnTriggerExit(Collider other)
    {

        col.Remove(other);
        //Debug.Log(other.name);
        if (buttonPressed && other.tag != "Player")
        {

          


        }



    }



    public void ActivateAttack(float attackDuration, float attackPower, float attackSize)
    {
        
        attackTime = attackDuration;
        buttonPressed = true;
        //Debug.Log(buttonPressed);
    }
    
}
