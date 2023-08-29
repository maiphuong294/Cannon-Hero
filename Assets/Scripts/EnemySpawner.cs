using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Hit_Miss == 1)
        {
            //spawn
            Instantiate(enemyPrefab, new Vector3(3f, Random.Range(-2.5f, 1.5f), 0f), Quaternion.identity);
            Player.Hit_Miss = 0;
        }
    }
}
