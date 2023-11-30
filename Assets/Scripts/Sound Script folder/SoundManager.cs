
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance;
    [SerializeField] private AudioSource _musicSource, _effectSource;

    void Awake()
    {
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
    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        
        AudioListener.volume = value;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Game_Scene")
        {
            Destroy(gameObject);
        }
    }
}
