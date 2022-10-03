using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.Play();
        }
    }
}
