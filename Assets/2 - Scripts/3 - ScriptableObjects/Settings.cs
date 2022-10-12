using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings
{
    public static Settings Instance { get; private set; }

    [SerializeField] private float _volume = 1f;
    [SerializeField] private bool _invertY = false;
    [SerializeField] private bool _invertX = false;
    [SerializeField] private float _mouseSensitivityx = 1f;
    [SerializeField] private float _mouseSensitivityy = 1f;

    public float Volume { get => _volume; set => _volume = value; }
    public bool InvertY { get => _invertY; set => _invertY = value; }
    public bool InvertX { get => _invertX; set => _invertX = value; }
    public float MouseSensitivityX { get => _mouseSensitivityx; set => _mouseSensitivityx = value; }
    public float MouseSensitivityY { get => _mouseSensitivityy; set => _mouseSensitivityy = value; }

    private void OnEnable()
    {
        Instance = this;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", Volume);
        PlayerPrefs.SetInt("InvertY", InvertY ? 1 : 0);
        PlayerPrefs.SetInt("InvertX", InvertX ? 1 : 0);
        PlayerPrefs.SetFloat("MouseSensitivityx", MouseSensitivityX);
        PlayerPrefs.SetFloat("MouseSensitivityy", MouseSensitivityY);
    }

    public void LoadSettings()
    {
        Volume = PlayerPrefs.GetFloat("Volume", Volume);
        InvertY = PlayerPrefs.GetInt("InvertY", InvertY ? 1 : 0) == 1;
        InvertX = PlayerPrefs.GetInt("InvertX", InvertX ? 1 : 0) == 1;
        MouseSensitivityX = PlayerPrefs.GetFloat("MouseSensitivityx", MouseSensitivityX);
        MouseSensitivityY = PlayerPrefs.GetFloat("MouseSensitivityy", MouseSensitivityY);
    }

    public void ResetSettings()
    {
        MouseSensitivityY = 1f;
        MouseSensitivityX = 1f;
        Volume = 1f;
        InvertY = false;
        InvertX = false;
    }
}
