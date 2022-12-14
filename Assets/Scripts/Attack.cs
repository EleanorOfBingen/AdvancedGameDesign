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
    //[SerializeField] private float minumumSword = 0.25f;
    
    [Header("Main Attack")]
    [SerializeField] private float mainAttackPushForward = 20;
    [SerializeField] private float basePowerMainAttack = 4;
    [SerializeField] private float[] attackDividers;
    [SerializeField] private float[] attackDiviversPower;

    private float attackMeterMin = 0;
    private float attackMeterMax;
    private float attackTimer;
    private bool attacking;


 
    [Header("Big Sword Attack")]
    [SerializeField] private bool bigAttackActivated;
    [SerializeField] private float bigSwordHoldInTime;
    [SerializeField] private float bigAttackChargeupRate = 1;
    [SerializeField] private float bigSwordAttackPower;
    [SerializeField] private float[] bigSwordAttackAOESize;
    [SerializeField] private float[] bigSwordAttackPowerModifier;
    private Movement movement;
  
    [Header("UI")]
    [SerializeField] private Material swordMaterial;
    [SerializeField] private Slider slMainAttack;
    [SerializeField] private Slider slBigAttack;


    [Header("Dashing")]
    [SerializeField] private float dashingAttackPower = 2;
    [SerializeField] private bool imDashing;
    private float dashDuration;
    




    // Start is called before the first frame update
    void Start()
    {
        attackMeterMax = attackMeter;
        movement = GetComponent<Movement>();
        if(attackDividers.Length == 0)
        {

            attackDividers = new float[] {0.25f, 0.5f, 0.75f, 1f };

        }
        if (attackDiviversPower.Length == 0)
        {

            attackDiviversPower = attackDividers;

        }
        if (bigSwordAttackAOESize.Length == 0)
        {
            bigSwordAttackAOESize = new float[] { 1, 2, 3, 4};


        }
        if(bigSwordAttackPowerModifier.Length == 0)
        {
            bigSwordAttackPowerModifier = bigSwordAttackAOESize;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (imDashing)
        {
            dashDuration -= Time.deltaTime;
            if(dashDuration <= 0)
            {

                imDashing = false;

            }


        }

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
        if (CanIDoStuff(attackDecreesment))
        {
            sbMainAttack.ActivateAttack(howLongAttack, MainAttackPower(), MainAttackSize());
            attackMeter -= attackDecreesment;
            attackTimer = howLongAttack;
            movement.SwordAttack(howLongAttack, mainAttackPushForward);
            attacking = true;
            imDashing = false;
        }
        Debug.Log("attackpower" + MainAttackPower());
        Debug.Log("attackmeter" + attackMeter);

    }



    private void OnBigSword()
    {
        if (!bigAttackActivated)
        {

            //Debug.Log("BIGSWORD");
            bigAttackActivated = true;
        }
        else
        {
            //Debug.Log("BIIIIGSWOOOORD");
            sbBigAttack.ActivateAttack(howLongAttack, AttackBigSwordPower(), AttackBigSwordAOE());
            bigAttackActivated = false;
            // sbBigAttack.ActivateAttack
            //Debug.Log(AttackBigSwordAOE());
            bigSwordHoldInTime = 0;

        }


     


    }
    public void AttackMeterIncrease(float increasement)
    {

        attackMeter += increasement;

    }

    private float MainAttackSize()
    {

        float value = 0;

        foreach (float f in attackDividers)
        {
            

            value = f;
                      

            if (attackMeter < f)
            {

                break;

            }

          

        }

        return value;

    }

    private float MainAttackPower()
    {

        float value = 0;

        for (int i = 0; i < attackDividers.Length; i++)
        {

            value = basePowerMainAttack * attackDiviversPower[i] * dashingAttackValue();


            if (attackMeter < attackDividers[i])
            {

                break;

            }

        }

        return value;

    }

    private float AttackBigSwordAOE()
    {

        float value = 0;

        for (int i = 0; i < attackDividers.Length; i++)
        {

            value = bigSwordAttackAOESize[i];


            if (bigSwordHoldInTime < attackDividers[i])
            {

                break;

            }

        }
 
        return value;
                        

    }
    private float AttackBigSwordPower()
    {

        float value = 0;

        for (int i = 0; i < attackDividers.Length; i++)
        {

            value = bigSwordAttackPower * bigSwordAttackPowerModifier[i];


            if (bigSwordHoldInTime < attackDividers[i])
            {

                break;

            }

        }

        return value;
    }

    public void Dashing(float swordDecreasment, float dashDur)
    {
        attackMeter -= swordDecreasment;
        dashDuration = dashDur;
        imDashing = true;

    }

    private float dashingAttackValue()
    {
        if (imDashing)
        {
            return dashingAttackPower;
        }
        else
        {
            return 1;
        }

    }

    public bool CanIDoStuff(float minimumStuff)
    {

        return attackMeter >= minimumStuff;

    }



}
