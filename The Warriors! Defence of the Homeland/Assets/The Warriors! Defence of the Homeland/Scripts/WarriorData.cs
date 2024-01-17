using UnityEngine;

[CreateAssetMenu(fileName = "WarriorData", menuName = "ScriptableObjects/WarriorData", order = 1)]
public class WarriorData : ScriptableObject
{
    public GameObject warriorPrefab;
    public float cost;
}
