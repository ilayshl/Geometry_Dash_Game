using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    AudioSource musicSource;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.PlayDelayed(1f);
    }
}
