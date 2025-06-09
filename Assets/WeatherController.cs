using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public bool playRain = false;
    public bool playSnow = false;

    public ParticleSystem rainEffect;
    public ParticleSystem snowEffect;

    private void Update()
    {
        // Only update effects during play mode
        if (Application.isPlaying)
        {
            UpdateWeatherEffects();
        }
    }

#if UNITY_EDITOR
    // Called when a value is changed in the Inspector
    private void OnValidate()
    {
        if (!Application.isPlaying) return;
        UpdateWeatherEffects();
    }
#endif

    void UpdateWeatherEffects()
    {
        if (rainEffect != null)
        {
            if (playRain && !rainEffect.isPlaying)
                rainEffect.Play();
            else if (!playRain && rainEffect.isPlaying)
                rainEffect.Stop();
        }

        if (snowEffect != null)
        {
            if (playSnow && !snowEffect.isPlaying)
                snowEffect.Play();
            else if (!playSnow && snowEffect.isPlaying)
                snowEffect.Stop();
        }
    }
}