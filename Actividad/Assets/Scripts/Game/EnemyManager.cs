using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Configuración de Enemigos")]
    public GameObject enemyPrefab;  // Prefab del enemigo
    public int enemyCount = 30;     // Cantidad de enemigos a instanciar

    [Header("Terreno")]
    public Terrain terrain;         // El terreno donde se colocan
    public float yOffset = 0.1f;    

    void Start()
    {
        // Verificar que haya prefab y terreno asignados
        if (enemyPrefab == null || terrain == null)
        {
            Debug.LogError("EnemyManager: Falta asignar el prefab o el terreno.");
            return;
        }

        // Instanciar enemigos
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Obtener tamaño del terreno
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;

        // Posición aleatoria dentro del terreno
        float posX = Random.Range(0, terrainWidth);
        float posZ = Random.Range(0, terrainLength);

        // Calcular altura exacta del terreno en ese punto
        float posY = terrain.SampleHeight(new Vector3(posX, 0, posZ));

        // Sumar offset para que no se hunda en el suelo
        Vector3 spawnPosition = new Vector3(posX, posY + yOffset, posZ);

        // Instanciar enemigo
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
