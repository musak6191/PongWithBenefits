using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] PowerUps;

    float XminRange = -5;
    float XmaxRange = 5;

    float YminRange = -3;
    float YmaxRange = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", 5, 5);
    }
    void SpawnPowerup()
    {
        // Zufällige Position zwischen den Clamps
        float RandomX = Random.Range(XminRange, XmaxRange);
        float RandomY = Random.Range(YminRange, YmaxRange);
        Vector3 RandomPosition = new Vector3(RandomX, RandomY, 0);

        //Zufällige Zahl fürn Index
        int RandomIndex = Random.Range(0, PowerUps.Length);

        // Instantiieren von den Powerups
        Instantiate(PowerUps[RandomIndex], RandomPosition, transform.rotation);
    }
}
