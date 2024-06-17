using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager ��ü ã��
    }

    public void PurchaseClickUpgrade()
    {
        int upgradeCost = gameManager.GetClickUpgradeCost();
        if (gameManager.Currency >= upgradeCost)
        {
            gameManager.Currency -= upgradeCost;
            gameManager.IncreaseClickReward(); // Ŭ�� ���� ����
            gameManager.UpdateScoreText(); // ���� �ؽ�Ʈ ������Ʈ
        }
        else
        {
            Debug.Log("Not enough currency to purchase upgrade.");
        }
    }
}
