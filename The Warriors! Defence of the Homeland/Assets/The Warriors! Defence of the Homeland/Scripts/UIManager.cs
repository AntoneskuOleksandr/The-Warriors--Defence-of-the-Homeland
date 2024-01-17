using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Button[] buyWarriorButtons;
    [SerializeField] private TMP_Text foodCounter;
    [SerializeField] private Image foodFillingPanel;
    [SerializeField] private WarriorData[] warriors;

    public UnityEvent<int> onBuyWarrior;

    private GameManager gameManager;
    private int foodCount;

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < buyWarriorButtons.Length; i++)
        {
            int temp = i;

            buyWarriorButtons[i].onClick.AddListener(() => BuyWarrior(temp));
        }

        gameManager = GameManager.Instance;

        GameManager.Instance.onStartFoodGenerating.AddListener(() => StartCoroutine(PanelFiller(gameManager.foodRegenRate)));
        GameManager.Instance.onFoodChanged.AddListener(UpdateBuyButtons);

        foodCount = (int)gameManager.FoodCount;
        foodCounter.text = foodCount.ToString();
    }

    private void BuyWarrior(int index)
    {
        if (gameManager.FoodCount >= warriors[index].cost)
        {
            gameManager.FoodCount -= warriors[index].cost;
            onBuyWarrior.Invoke(index);
        }
    }

    private void UpdateBuyButtons()
    {
        for (int i = 0; i < buyWarriorButtons.Length; i++)
        {
            buyWarriorButtons[i].interactable = gameManager.FoodCount >= warriors[i].cost;
        }
    }

    private IEnumerator PanelFiller(float coolDown)
    {
        while (true)
        {
            float elapsed = 0f;

            while (elapsed < coolDown)
            {
                elapsed += Time.deltaTime;
                foodFillingPanel.fillAmount = elapsed / coolDown;
                yield return null;
            }

            foodCount++;
            foodCounter.text = foodCount.ToString();
            foodFillingPanel.fillAmount = 0;
        }
    }
}