using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float maxHealth = 8;
    private float health;
    [SerializeField] private Slider hpSlider;

    void Start()
    {
        health = maxHealth;
        hpSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = health;


    }

    public void TakingDamage(float damage)
    {

        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject, 0.5f);


        }

    }


}
