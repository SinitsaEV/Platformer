using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{    
    [SerializeField] protected float SpawnWidth = 5f;
    [SerializeField] protected float SpawnHeight = 2f;

    protected virtual Vector2 GetRandomPosition(Transform transform)
    {
        float spawnPositionX = Random.Range(transform.position.x - SpawnWidth, transform.position.x + SpawnWidth);
        float spawnPositionY = Random.Range(transform.position.y - SpawnHeight, transform.position.y + SpawnHeight);

        return new Vector2(spawnPositionX, spawnPositionY);
    }

    protected abstract void Spawn();
}
