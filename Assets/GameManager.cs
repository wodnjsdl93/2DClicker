using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText; // ������ ǥ���� TextMeshProUGUI ����
    [SerializeField] private GameObject upgradeUIPanel; // ���׷��̵� UI �г�
    [SerializeField] public TMP_Text currencyText;
    [SerializeField] private TMP_Text autoClickTimeText;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TMP_Text feedbackText;

    private int score = 0; // ���� ����

    private float autoClickInterval = 20f; 
    public int Currency { get; set; }
    private bool isAutoClickEnabled = true;
    private int clickCount = 0; // Ŭ�� Ƚ�� ī����
    private int autoClickTimeDecreaseCost = 5;

    void Start()
    {
        Currency = 0; // �ʱ� ��ȭ ����
        UpdateScoreText(); // ���� ���� �� �ʱ� ������ ǥ���մϴ�.
        UpdateCurrencyText();
        upgradeUIPanel.SetActive(false);
        StartCoroutine(AutoClickCoroutine(autoClickInterval)); // ���� Ŭ�� �ڷ�ƾ ����
        UpdateAutoClickTimeText();
    }

    // Ŭ�� �̺�Ʈ ó��
    public void OnClick()
    {
        clickCount++; // Ŭ�� Ƚ�� ����

        if (clickCount >= 5)
        {
            clickCount = 0; // Ŭ�� Ƚ�� �ʱ�ȭ
            EarnCurrency(1); // ��ȭ 1 ����
        }

        score++; // ���� ����
        UpdateScoreText(); // ���� �� ��ȭ�� ȭ�鿡 ������Ʈ 
    }
    // ���� Ŭ�� �ڷ�ƾ
    private IEnumerator AutoClickCoroutine(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            if (isAutoClickEnabled)
            {
                score += 1; 
                UpdateScoreText(); 
            }
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateCurrencyText()
    {
        currencyText.text = Currency.ToString();
    }

    // Ŭ�� ���׷��̵� ��� ���
    public int GetClickUpgradeCost()
    {
        return 10;
    }

    // Ŭ�� ���� ����
    public void IncreaseClickReward()
    {
        score += 2;
        UpdateScoreText();
    }

    public void UpdateAutoClickTimeText()
    {
        autoClickTimeText.text = "���� Ŭ�� ���� �ð� " +  autoClickTimeDecreaseCost.ToString();
    }

    // ���� Ŭ�� Ȱ��ȭ/��Ȱ��ȭ
    public void ToggleAutoClick(bool isEnabled)
    {
        isAutoClickEnabled = isEnabled;
    }

    // ���׷��̵� UI ǥ��
    public void ShowUpgradeUI()
    {
        upgradeUIPanel.SetActive(true);
    }

    // ���׷��̵� UI ����
    public void HideUpgradeUI()
    {
        upgradeUIPanel.SetActive(false);
    }

    // ���� Ŭ�� �ð� ���� ���
    public void UpgradeAutoClick()
    {
        if (Currency >= autoClickTimeDecreaseCost)
        {
            Currency -= autoClickTimeDecreaseCost;
            autoClickInterval -= 1f;
            if (autoClickInterval < 1f)
            {
                autoClickInterval = 1f;
            }
            UpdateCurrencyText();
            
        }
        else
        {
            feedbackText.text = "��ȭ�� �����մϴ�.";
        }
    }

    // ��ȭ ���
    public void EarnCurrency(int amount)
    {
        Currency += amount;
        UpdateCurrencyText();
    }
}
