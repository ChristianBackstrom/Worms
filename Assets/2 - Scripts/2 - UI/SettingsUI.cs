using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    private SettingsManager settingsManager;

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle invertYToggle;
    [SerializeField] private Toggle invertXToggle;
    [SerializeField] private Slider mouseSensitivityXSlider;
    [SerializeField] private Slider mouseSensitivityYSlider;


    private void Awake()
    {
        settingsManager = SettingsManager.Instance;
    }

    private void Start()
    {
        SetValues();
    }

    public void SetMouseSensitivityX(float valueX)
    {
        settingsManager.setting.MouseSensitivityX = valueX;
    }

    public void SetInvertX(bool value)
    {
        settingsManager.setting.InvertX = value;
    }

    public void SetMouseSensitivityY(float valueY)
    {
        settingsManager.setting.MouseSensitivityY = valueY;
    }

    public void SetInvertY(bool value)
    {
        settingsManager.setting.InvertY = !value;
    }

    public void SetVolume(float value)
    {
        settingsManager.setting.Volume = value;
    }

    private void SetValues()
    {
        volumeSlider.value = settingsManager.setting.Volume;
        invertYToggle.isOn = !settingsManager.setting.InvertY;
        invertXToggle.isOn = settingsManager.setting.InvertX;
        mouseSensitivityXSlider.value = settingsManager.setting.MouseSensitivityX;
        mouseSensitivityYSlider.value = settingsManager.setting.MouseSensitivityY;
    }

    public void SaveSettings()
    {
        settingsManager.SaveSettings();
        settingsManager.LoadSettings();
    }
}
