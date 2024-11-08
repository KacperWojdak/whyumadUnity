using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float savedVolume = PlayerPrefs.GetFloat("GlobalVolume", 1f);
        audioSource.volume = savedVolume;
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
            PlayerPrefs.SetFloat("GlobalVolume", volume);
        }
    }
}
