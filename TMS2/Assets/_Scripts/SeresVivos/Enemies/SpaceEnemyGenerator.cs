using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyGenerator : MonoBehaviour{

    public List<GameObject> enemies;
    public float time;
    public float maxDistance;
    public float maxEnemies;
    private float generatedEnemies;


    void Start()
    {
        InvokeRepeating(nameof(createNewOne),1f,time);
    }

    private void createNewOne(){
        if(generatedEnemies> maxEnemies) return;


        generatedEnemies++;
        int randomNumber = Random.Range(0, enemies.Count);
        GameObject enemy = Instantiate(enemies[randomNumber]);

        Vector3 randomPos = new Vector3(
            Random.Range(-maxDistance, maxDistance),
            Random.Range(-maxDistance, maxDistance), 
            Random.Range(-maxDistance, maxDistance));
        
        enemy.transform.position =transform.position+ randomPos;
        
    }
}
