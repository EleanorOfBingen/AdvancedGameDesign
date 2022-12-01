using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{
    private float distance;
    private float maxDistance = 5f;
    private bool readyToAttack;
    private float chargeUpTime = 0.5f;
    private float chargeUpTimeMax;
    private float timeAttack = 0.5f;
    private float timeAttackMax;
    private float pushForce = 10;
    private float timeBetweenAttack = 2f;
    private float timeBtweenAttackMax;

    private Vector3 destinationAttack;


    public Transform player;
    NavMeshAgent enemyAgent;
    private float timer;

    private bool amIHit;


    private Vector3 originalRotation;
 

    void Start()
    {
        
        chargeUpTimeMax = chargeUpTime;
        //Enemy have pathfinding
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        chargeUpTimeMax = chargeUpTime;
        timeAttackMax = timeAttack;
        timeBtweenAttackMax = timeBetweenAttack;

    }


    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (amIHit)
        {
            readyToAttack = false;
            enemyAgent.isStopped = true;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timeAttack -= Time.deltaTime;

                amIHit = false;

            }

        }

        if (readyToAttack)
        {
           
            //Vector3 newDest = (player.transform.position - transform.position  ).normalized;
            //float speed = 1f;
            Vector3 forward = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(forward);

            Vector3 rotation = Quaternion.LookRotation(forward).eulerAngles;
            //rotation.y = 0f;

           // transform.rotation = Quaternion.Euler(rotation);

            //Vector3 newnewDes = Vector3.RotateTowards(transform.forward, newDest, speed, 0);
            //Vector3 des = new Vector3(0, newDest.y, 0);
            ///transform.rotation = Quaternion.LookRotation(newnewDes);
            chargeUpTime -= Time.deltaTime;
            if (chargeUpTime <= 0)
            {
                transform.Translate(Vector3.forward * pushForce * Time.deltaTime);

                
                
                 timeBetweenAttack -= Time.deltaTime;

                 if (timeBetweenAttack < 0)
                 {
                       readyToAttack = false;
                 }

                


               /// timeAttack -= Time.deltaTime;
            }




        }
        if (inRange() && !readyToAttack)
        {
            destinationAttack = player.transform.position;
            enemyAgent.isStopped = true;
            chargeUpTime = chargeUpTimeMax;
            timeBetweenAttack = timeAttackMax;
            readyToAttack = true;
            Debug.Log("d");


        }
        if (!readyToAttack)
        {
            enemyAgent.isStopped = false;
            enemyAgent.destination = player.transform.position;


        }

      
      
    }
    public void imHit(float duration)
    {

        timer = duration;
        amIHit=true;

    }

    private bool inRange()
    {
        

        return distance <= maxDistance;

    }
    

}
