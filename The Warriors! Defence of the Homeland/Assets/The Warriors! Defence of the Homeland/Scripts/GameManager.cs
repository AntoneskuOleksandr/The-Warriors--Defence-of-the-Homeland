using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float foodRegenRate = 1f;

    public UnityEvent onFoodChanged;
    public UnityEvent onStartFoodGenerating;

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
        Instance = this;
    }

    private void Start()
    {
        onStartFoodGenerating.Invoke();
    }

    private void Update()
    {
        FoodCount += foodRegenRate * Time.deltaTime;
    }
}
