using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int numberOfMonsters = 4;

    [Header("Spawn Area")]
    public float minX = 40f;
    public float maxX = 107f;
    public float minZ = 52f;
    public float maxZ = 107f;

    public float yPosition = 0f; // Ground level

    void Start()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(x, yPosition, z);

            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
