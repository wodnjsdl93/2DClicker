using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText; // 점수를 표시할 TextMeshProUGUI 변수
    [SerializeField] private GameObject upgradeUIPanel; // 업그레이드 UI 패널
    [SerializeField] public TMP_Text currencyText;
    [SerializeField] private TMP_Text autoClickTimeText;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TMP_Text feedbackText;

    private int score = 0; // 현재 점수

    private float autoClickInterval = 20f; 
    public int Currency { get; set; }
    private bool isAutoClickEnabled = true;
    private int clickCount = 0; // 클릭 횟수 카운터
    private int autoClickTimeDecreaseCost = 5;

    void Start()
    {
        Currency = 0; // 초기 통화 설정
        UpdateScoreText(); // 게임 시작 시 초기 점수를 표시합니다.
        UpdateCurrencyText();
        upgradeUIPanel.SetActive(false);
        StartCoroutine(AutoClickCoroutine(autoClickInterval)); // 오토 클릭 코루틴 시작
        UpdateAutoClickTimeText();
    }

    // 클릭 이벤트 처리
    public void OnClick()
    {
        clickCount++; // 클릭 횟수 증가

        if (clickCount >= 5)
        {
            clickCount = 0; // 클릭 횟수 초기화
            EarnCurrency(1); // 재화 1 증가
        }

        score++; // 점수 증가
        UpdateScoreText(); // 점수 및 재화를 화면에 업데이트 
    }
    // 오토 클릭 코루틴
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

    // 클릭 업그레이드 비용 계산
    public int GetClickUpgradeCost()
    {
        return 10;
    }

    // 클릭 보상 증가
    public void IncreaseClickReward()
    {
        score += 2;
        UpdateScoreText();
    }

    public void UpdateAutoClickTimeText()
    {
        autoClickTimeText.text = "오토 클릭 감소 시간 " +  autoClickTimeDecreaseCost.ToString();
    }

    // 오토 클릭 활성화/비활성화
    public void ToggleAutoClick(bool isEnabled)
    {
        isAutoClickEnabled = isEnabled;
    }

    // 업그레이드 UI 표시
    public void ShowUpgradeUI()
    {
        upgradeUIPanel.SetActive(true);
    }

    // 업그레이드 UI 숨김
    public void HideUpgradeUI()
    {
        upgradeUIPanel.SetActive(false);
    }

    // 오토 클릭 시간 감소 기능
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
            feedbackText.text = "재화가 부족합니다.";
        }
    }

    // 통화 얻기
    public void EarnCurrency(int amount)
    {
        Currency += amount;
        UpdateCurrencyText();
    }
}
