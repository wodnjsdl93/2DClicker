using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager 객체 찾기
    }

    public void PurchaseClickUpgrade()
    {
        int upgradeCost = gameManager.GetClickUpgradeCost();
        if (gameManager.Currency >= upgradeCost)
        {
            gameManager.Currency -= upgradeCost;
            gameManager.IncreaseClickReward(); // 클릭 보상 증가
            gameManager.UpdateScoreText(); // 점수 텍스트 업데이트
        }
        else
        {
            Debug.Log("Not enough currency to purchase upgrade.");
        }
    }
}
