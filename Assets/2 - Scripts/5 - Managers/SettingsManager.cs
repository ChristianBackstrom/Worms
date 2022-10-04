using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    [SerializeField] public Settings settings;

    private void Awake()
    {
        settings = new Settings();

        settings.LoadSettings();

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
        AudioListener.volume = settings.Volume;

        Cinemachine.CinemachineFreeLook[] cmCams = Resources.FindObjectsOfTypeAll<Cinemachine.CinemachineFreeLook>();

        Debug.Log(cmCams.Length);

        foreach (var cmCam in cmCams)
        {
            cmCam.m_XAxis.m_InvertInput = settings.InvertX;
            cmCam.m_YAxis.m_InvertInput = settings.InvertY;
            cmCam.m_XAxis.m_MaxSpeed *= settings.MouseSensitivityX;
            cmCam.m_YAxis.m_MaxSpeed *= settings.MouseSensitivityY;
        }
    }

    public void SaveSettings()
    {
        settings.SaveSettings();
    }
}
