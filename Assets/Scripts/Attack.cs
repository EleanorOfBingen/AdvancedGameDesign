using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

    [SerializeField] private SwordBox sbMainAttack;
    [SerializeField] private SwordBox sbBigAttack;
    [SerializeField] private float howLongAttack = 0.5f;

    [Header("Sword regain stat")]
    [SerializeField] private float attackMeter = 1;
    [SerializeField] private float attackDecreesment = 0.25f;
    [SerializeField] private float attackIncreasementRate = 0.1f;
    [SerializeField] private float minumumSword = 0.25f;
    
    [Header("Main Attack")]
    [SerializeField] private float mainAttackPushForward = 20;
    [SerializeField] private float powerMainAttack = 1;
    [SerializeField] private float[] attackDividers;

    private float attackMeterMin = 0;
    private float attackMeterMax;
    private float attackTimer;
    private bool attacking;


 
    [Header("Big Sword Attack")]
    [SerializeField] private bool bigAttackActivated;
    [SerializeField] private float bigSwordHoldInTime;
    [SerializeField] private float bigAttackChargeupRate = 1;
    [SerializeField] private float bigSwordAttackPower;
    [SerializeField] private float[] bigSwordHoldInPowerModifiers;

    private Movement movement;
  
    [Header("UI")]
    [SerializeField] private Material swordMaterial;
    [SerializeField] private Slider slMainAttack;
    [SerializeField] private Slider slBigAttack;





    // Start is called before the first frame update
    void Start()
    {
        attackMeterMax = attackMeter;
        movement = GetComponent<Movement>();
        if(attackDividers.Length == 0)
        {

            attackDividers = new float[] {0.25f, 0.5f, 0.75f, 1f };

        }
        if(bigSwordHoldInPowerModifiers.Length == 0)
        {
            bigSwordHoldInPowerModifiers = new float[] { 2, 3, 4, 5};


        }
    }

    // Update is called once per frame
    void Update()
    {

        if (bigAttackActivated)
        {

            attackMeter -= Time.deltaTime;
            if(attackMeter > 0)
            {
                bigSwordHoldInTime += Time.deltaTime * bigAttackChargeupRate;

            }
        }

        slMainAttack.value = attackMeter;
        //swordMaterial.SetFloat("SwordSize", 0);
        slBigAttack.value = bigSwordHoldInTime;

        if (attacking)
        {
            attackTimer -= Time.deltaTime;
           
            if (attackTimer < 0)
            {
                attacking = false;


            }

        }
        else if(!bigAttackActivated)
        {
          
            attackMeter += Time.deltaTime * attackIncreasementRate;
            attackMeter = Mathf.Clamp(attackMeter, attackMeterMin, attackMeterMax);



        }
        
    }
    private void OnSword()
    {
        if (attackMeter >= minumumSword)
        {
            sbMainAttack.ActivateAttack(howLongAttack, attackPowerMain(), attackPowerMain());
            attackMeter -= attackDecreesment;
            attackTimer = howLongAttack;
            movement.SwordAttack(howLongAttack, mainAttackPushForward);
            attacking = true;
        }
        //Debug.Log("attackpower" + attackPowerMain());
        ///Debug.Log("attackmeter" + attackMeter);

    }



    private void OnBigSword()
    {
        if (!bigAttackActivated)
        {

            Debug.Log("BIGSWORD");
            bigAttackActivated = true;
        }
        else
        {
            Debug.Log("BIIIIGSWOOOORD");
            //sbMainAttack.ActivateAttack(howLongAttack, 0, 0);
            bigAttackActivated = false;
            // sbBigAttack.ActivateAttack
            Debug.Log(attackPowerBigSword());
            bigSwordHoldInTime = 0;

        }


     


    }
    public void AttackMeterIncrease(float increasement)
    {

        attackMeter += increasement;

    }

    private float attackPowerMain()
    {

        float value = 0;

        foreach (float f in attackDividers)
        {
            

            value = powerMainAttack * f;
                      

            if (attackMeter < f)
            {

                break;

            }

          

        }

        return value;

    }

    private float attackPowerBigSword()
    {

        float value = 0;

        for (int i = 0; i < attackDividers.Length; i++)
        {

            value = bigSwordAttackPower * bigSwordHoldInPowerModifiers[i];


            if (bigSwordHoldInTime < attackDividers[i])
            {

                break;

            }

        }
 

        return value;


            

    }



}
