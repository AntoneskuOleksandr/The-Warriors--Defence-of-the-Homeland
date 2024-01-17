using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Button[] buyWarriorButtons;
    [SerializeField] private WarriorData[] warriors;

    public UnityEvent<int> onBuyWarrior;

    private void Awake()
    {
        Instance = this;


        for (int i = 0; i < buyWarriorButtons.Length; i++)
        {
            int temp = i;

            buyWarriorButtons[i].onClick.AddListener(() => BuyWarrior(temp));
        }
    }

    private void Start()
    {
        GameManager.instance.onFoodChanged.AddListener(UpdateFoodCounter);
    }

    private void BuyWarrior(int index)
    {
        if (GameManager.instance.FoodCount >= warriors[index].cost)
        {
            GameManager.instance.FoodCount -= warriors[index].cost;
            onBuyWarrior.Invoke(index);
        }
    }

    private void UpdateFoodCounter()
    {
        for (int i = 0; i < buyWarriorButtons.Length; i++)
        {
            buyWarriorButtons[i].interactable = GameManager.instance.FoodCount >= warriors[i].cost;
        }
    }
}