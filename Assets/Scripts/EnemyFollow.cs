using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    NavMeshAgent enemyAgent;


    void Start()
    {
        //Enemy have pathfinding
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        //Ai follow player
        Debug.Log(player.transform.position);
        enemyAgent.destination = player.transform.position;
    }

}
