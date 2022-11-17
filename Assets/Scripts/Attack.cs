using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{

    [SerializeField]private SwordBox sb;
    [SerializeField]private float howLongAttack = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSword()
    {
       

        sb.ActivateAttack(howLongAttack);

    }
}
