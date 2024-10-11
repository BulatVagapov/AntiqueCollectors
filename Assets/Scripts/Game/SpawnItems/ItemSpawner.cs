using System.Threading.Tasks;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private ItemsKeeper itemsKeeper;
    [SerializeField] Transform leftExtremePositionTransform;
    [SerializeField] Transform rightExtremePositionTransform;
    [SerializeField] private GameObject spewnedFruitsReturner;

    [Range(0.3f, 3.3f)]
    [SerializeField] private float timeBetweenSpawn;
    private Vector2 spawnPosition;
    private Item spawningItem;
    private bool needToSpawn;
    private bool spawnIsPaused;

    private void Start()
    {
        itemsKeeper.InintFruitKeeper();

        GameManager.Instance.GameCycleStartEvent += StartSpawnFruits;
        GameManager.Instance.GameCycleEndEvent += StopSpawnFruits;
    }

    public void StartSpawnFruits()
    {
        spewnedFruitsReturner.gameObject.SetActive(false);
        needToSpawn = true;
        spawnIsPaused = false;
        SpawnFruit();
    }

    private void StopSpawnFruits()
    {
        needToSpawn = false;
        spewnedFruitsReturner.gameObject.SetActive(true);
    }

    private async Task SpawnFruit()
    {
        spawnPosition.y = leftExtremePositionTransform.position.y;
        Spawn();
        while (needToSpawn)
        {
            await Task.Delay((int)(timeBetweenSpawn * 1000));
            if (spawnIsPaused)
            {
                continue;
            }
            Spawn();
        }

        return;
    }

    private async Task Spawn()
    {
        spawnPosition.x = Random.Range(leftExtremePositionTransform.position.x, rightExtremePositionTransform.position.x);

        spawningItem = await itemsKeeper.GetRandomItem();
        spawningItem.transform.position = spawnPosition;
        spawningItem.gameObject.SetActive(true);
        spawningItem.DropItem();
    }

    private void OnApplicationQuit()
    {
        StopSpawnFruits();
    }
}
