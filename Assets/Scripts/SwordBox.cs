using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBox : MonoBehaviour
{

    bool buttonPressed;
    private float attackTime;
    public List<Collider> col;
    [SerializeField] private Attack attack;

    private float enemyPushForce = 10;
    private float powerAttack;
    private float sizeAttackBox;


    private BoxCollider bc;
    private SphereCollider sc;

    private Vector3 bcOriginalSize;
    private Vector3 bcSize;
    private float scOriginalRadius;
    private float scRadius; 

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        sc = GetComponent<SphereCollider>();
        if (bc != null)
        {

            bcOriginalSize = bc.size;


        }
        if(sc != null)
        {
            scOriginalRadius = sc.radius;


        }
        
    }

    // Update is called once per frame
    void Update()
    {



        if(buttonPressed)
        {
            if (attackTime < 0)
            {

                buttonPressed = false;
            }

            attackTime -= Time.deltaTime;
            //Debug.Log(buttonPressed);

            // BoxCollider bc = GetComponent<BoxCollider>();

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

                    c.GetComponent<EnemyHP>().TakingDamage(powerAttack);
                    Vector3 pushdirections = (c.gameObject.transform.position - transform.position).normalized;
                    c.GetComponent<EnemyFollow>().imHit(1.5f);
                    c.gameObject.transform.Translate(pushdirections * enemyPushForce * Time.deltaTime);
                    attack.AttackMeterIncrease(10);
                   

                }

            }
     

            col = new List<Collider>();


        }
        



    }
    private void OnTriggerStay(Collider other)
    {

        if (col.IndexOf(other) < 0 && other.tag != "Player")
        {

            col.Add(other);
            Debug.Log(other.name);

        }
       
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
        powerAttack = attackPower;
        sizeAttackBox = attackSize;
        Debug.Log(powerAttack);
        if(bc != null)
        {
            bc.size = new Vector3 (bcOriginalSize.x * attackSize, bcOriginalSize.y, bcOriginalSize.z * attackSize);
            Debug.Log("IHaveABoxCollider");

        }
        if(sc != null)
        {
            Debug.Log(attackSize);
            sc.radius = scOriginalRadius * attackSize;
            Debug.Log("IHaveASphereCollider");
        }

        buttonPressed = true;
        //Debug.Log(buttonPressed);
    }
    
}
