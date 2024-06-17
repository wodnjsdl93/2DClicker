using UnityEngine;

public class CurrencyEarnButton : MonoBehaviour
{
    public int currencyAmount = 10; // 얻을 통화 양
    public GameManager gameManager;

    public void OnClickEarnCurrency()
    {
        gameManager.EarnCurrency(currencyAmount);
    }
}
