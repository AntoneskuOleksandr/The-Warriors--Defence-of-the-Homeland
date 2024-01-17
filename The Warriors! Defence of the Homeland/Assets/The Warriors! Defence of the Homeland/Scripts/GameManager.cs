using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float foodRegenRate = 1f;

    public UnityEvent onFoodChanged;

    private float foodCount;

    public float FoodCount
    {
        get
        { return foodCount; }
        set
        {
            foodCount = value;
            onFoodChanged.Invoke();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        FoodCount += foodRegenRate * Time.deltaTime;
    }
}
