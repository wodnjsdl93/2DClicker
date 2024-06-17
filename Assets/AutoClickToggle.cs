using UnityEngine;
using UnityEngine.UI;

public class AutoClickToggle : MonoBehaviour
{
    public Toggle toggle;
    public GameManager gameManager;

    void Start()
    {
        toggle.onValueChanged.AddListener(delegate { ToggleAutoClick(toggle.isOn); });
    }

    void ToggleAutoClick(bool isEnabled)
    {
        gameManager.ToggleAutoClick(isEnabled);
    }
}
