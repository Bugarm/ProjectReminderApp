using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private const string GraphicsPrefKey = "GraphicsQuality";
    private const string MasterVolumePrefKey = "MasterVolume";

    [Header("UI")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private TMP_Dropdown graphicsDropdown;

    private void Start()
    {
        int savedGraphicsQuality = PlayerPrefs.GetInt(GraphicsPrefKey, 2); 
        savedGraphicsQuality = Mathf.Clamp(savedGraphicsQuality, 0, QualitySettings.names.Length - 1);

        float savedMasterVolume = PlayerPrefs.GetFloat(MasterVolumePrefKey, 1f);
        savedMasterVolume = Mathf.Clamp01(savedMasterVolume);

        QualitySettings.SetQualityLevel(savedGraphicsQuality);
        AudioListener.volume = savedMasterVolume;
        GameData.CurrentMasterVolume = savedMasterVolume;

        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.SetValueWithoutNotify(savedMasterVolume);
        }

        if (graphicsDropdown != null)
        {
            graphicsDropdown.SetValueWithoutNotify(savedGraphicsQuality);
        }
    }

    public void SetGraphicsQuality(int qualityLevel)
    {
        qualityLevel = Mathf.Clamp(qualityLevel, 0, QualitySettings.names.Length - 1);

        QualitySettings.SetQualityLevel(qualityLevel);
        PlayerPrefs.SetInt(GraphicsPrefKey, qualityLevel);
        PlayerPrefs.Save();
    }

    public void SetMasterVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        AudioListener.volume = volume;
        GameData.CurrentMasterVolume = volume;

        PlayerPrefs.SetFloat(MasterVolumePrefKey, volume);
        PlayerPrefs.Save();
    }
}