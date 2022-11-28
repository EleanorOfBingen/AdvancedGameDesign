using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave", order = 1)]
public class Wave : ScriptableObject
{

    [field: SerializeField]
    public GameObject[] EnemiesInWave { get; private set; }

    [field: SerializeField]
    public float TimeBeforeThisWave { get; private set; }
    // Start is called before the first frame update
    [field: SerializeField]
    public float NumberToSpawn { get; private set; }
}
