using UnityEngine;

public class CurrencyEarnButton : MonoBehaviour
{
    public int currencyAmount = 10; // ���� ��ȭ ��
    public GameManager gameManager;

    public void OnClickEarnCurrency()
    {
        gameManager.EarnCurrency(currencyAmount);
    }
}
