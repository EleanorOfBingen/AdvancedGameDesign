using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    public int repeatTime = 20;
    public GameObject normalAiSpawn;
    public GameObject explAiSpawn;
    public int chance = 10;
    private int changed;
    [SerializeField] CountDown countdown;

    //public float aiSpawn = 10;


    // 
    void Start()
    {
        InvokeRepeating("Spawn", 0.1f, repeatTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        // Start spawning when chount down
        if (countdown.countDown == false)
        {
            changed = Random.Range(1, 101);

            if (changed >= chance)
            {
                Instantiate(normalAiSpawn, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(explAiSpawn, transform.position, Quaternion.identity);
            }
        }
    }
    
}
