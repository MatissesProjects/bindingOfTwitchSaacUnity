using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int level;
    public int maxEnemies;

    // for now just use the 1 enemy
    public Enemy enemy;

    [ContextMenu("Generate Enemies")]
    public void SpawnEnemies()
    {
        var enemiesToSpawn = Random.Range(0, maxEnemies);
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            var spawn = Instantiate(enemy, transform.position + Vector3.one * Random.value, Quaternion.identity,
                transform);
            // pull from the enemy
            var rand = Random.Range(3f, 10f);
            Debug.Log(i + " will use this health " + rand);
            spawn.GetComponent<Health>().SetMaxHealth(rand);
        }
    }
}