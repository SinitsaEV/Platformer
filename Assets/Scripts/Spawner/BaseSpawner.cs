using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{    
    [SerializeField] protected float spawnWidth = 5f;
    [SerializeField] protected float spawnHeight = 2f;

    protected virtual Vector2 GetRandomPosition(Transform transform)
    {
        float spawnPositionX = Random.Range(transform.position.x - spawnWidth, transform.position.x + spawnWidth);
        float spawnPositionY = Random.Range(transform.position.y - spawnHeight, transform.position.y + spawnHeight);

        return new Vector2(spawnPositionX, spawnPositionY);
    }

    protected abstract void Spawn();
}
