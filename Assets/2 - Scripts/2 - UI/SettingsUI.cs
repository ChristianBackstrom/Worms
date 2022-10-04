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
        settingsManager.settings.MouseSensitivityX = valueX;
    }

    public void SetInvertX(bool value)
    {
        settingsManager.settings.InvertX = value;
    }

    public void SetMouseSensitivityY(float valueY)
    {
        settingsManager.settings.MouseSensitivityY = valueY;
    }

    public void SetInvertY(bool value)
    {
        settingsManager.settings.InvertY = !value;
    }

    public void SetVolume(float value)
    {
        settingsManager.settings.Volume = value;
    }

    private void SetValues()
    {
        volumeSlider.value = settingsManager.settings.Volume;
        invertYToggle.isOn = !settingsManager.settings.InvertY;
        invertXToggle.isOn = settingsManager.settings.InvertX;
        mouseSensitivityXSlider.value = settingsManager.settings.MouseSensitivityX;
        mouseSensitivityYSlider.value = settingsManager.settings.MouseSensitivityY;
    }

    public void SaveSettings()
    {
        settingsManager.SaveSettings();
        settingsManager.LoadSettings();
    }
}
