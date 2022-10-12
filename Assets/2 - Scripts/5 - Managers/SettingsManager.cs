using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    [SerializeField] public Settings setting;

    private void Awake()
    {
        setting = new Settings();

        setting.LoadSettings();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSettings()
    {
        AudioListener.volume = setting.Volume;

        Cinemachine.CinemachineFreeLook[] cmCams = Resources.FindObjectsOfTypeAll<Cinemachine.CinemachineFreeLook>();

        Debug.Log(cmCams.Length);

        foreach (var cmCam in cmCams)
        {
            cmCam.m_XAxis.m_InvertInput = setting.InvertX;
            cmCam.m_YAxis.m_InvertInput = setting.InvertY;
            cmCam.m_XAxis.m_MaxSpeed *= setting.MouseSensitivityX;
            cmCam.m_YAxis.m_MaxSpeed *= setting.MouseSensitivityY;
        }
    }

    public void SaveSettings()
    {
        setting.SaveSettings();
    }
}
