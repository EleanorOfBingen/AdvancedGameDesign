using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private float distance;
    private float maxDistance = 5f;
    private bool readyToAttack;
    private float chargeUpTime = 0.5f;
    private float chargeUpTimeMax;
    private float timeAttack = 0.5f;
    private float timeAttackMax;
    private float pushForce = 20;

    private Vector3 destinationAttack;


    public Transform player;
    NavMeshAgent enemyAgent;
    private float timer;

    private bool amIHit;
    
 

    void Start()
    {

        chargeUpTimeMax = chargeUpTime;
        //Enemy have pathfinding
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (amIHit)
        {
            enemyAgent.isStopped = true;
            timer -= Time.deltaTime;
            if (timer < 0)
            {

                amIHit = false;

            }

        }

        if (readyToAttack == false)
        {
 
            if (inRange())
            {
                destinationAttack = player.transform.position;
                readyToAttack = true;



            }
            else
            {
                enemyAgent.isStopped = false;
                enemyAgent.destination = player.transform.position;


            }
        }


        if (readyToAttack)
        {
            Vector3 newDest = (destinationAttack - transform.position).normalized;
            chargeUpTime -= Time.deltaTime;
            if(chargeUpTime <= 0 && timeAttack <= 0)
            {
                transform.Translate(newDest * pushForce * Time.deltaTime);
                timeAttack -= Time.deltaTime;
            }
      



        }

        //Ai follow player
        //Debug.Log(player.transform.position);
      
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
