using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{

    [SerializeField]private SwordBox sb;
    [SerializeField]private float howLongAttack = 0.5f;

    [Header ("Attack Stats")] 
    [SerializeField]private float attackMeter = 100;
    [SerializeField]private float attackDecreesment = 10;
    [SerializeField]private float attackIncreasementRate;

    private float attackMeterMin = 0;
    private float attackMeterMax;
    private float attackTimer;
    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        attackMeterMax = attackMeter;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (attacking)
        {
            attackTimer -= Time.deltaTime;
            
            if(attackTimer < 0)
            {
                attacking = false;


            }

        }
        else
        {
          
            attackMeter += Time.deltaTime * attackIncreasementRate;
            attackMeter = Mathf.Clamp(attackMeter, attackMeterMin, attackMeterMax);



        }
        
    }
    private void OnSword()
    {
       

        sb.ActivateAttack(howLongAttack);
        attackMeter -= attackDecreesment;
        attackTimer = howLongAttack;
        attacking = true;

    }
    public void AttackMeterIncrease(float increasement)
    {

        attackMeter += increasement;

    }

}
