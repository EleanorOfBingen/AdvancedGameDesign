using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private float distance;
    private float maxDistance = 5f;
    public Transform player;
    NavMeshAgent enemyAgent;
    private float timer;

    private bool amIHit;
    void Start()
    {
        //Enemy have pathfinding
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (amIHit)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {

                amIHit = false;

            }

        }
        else
        {
            enemyAgent.destination = player.transform.position;


        }
        //Ai follow player
        //Debug.Log(player.transform.position);
      
    }
    public void imHit(float duration)
    {

        timer = duration;
        amIHit=true;

    }

}
