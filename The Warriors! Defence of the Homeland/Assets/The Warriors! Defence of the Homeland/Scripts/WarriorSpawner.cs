using UnityEngine;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private WarriorData[] warriors;

    private void Start()
    {
        UIManager.Instance.onBuyWarrior.AddListener(Spawn);
    }

    public void Spawn(int index)
    {
        Instantiate(warriors[index].warriorPrefab, spawnPosition.position, Quaternion.LookRotation(Vector3.right));
    }
}