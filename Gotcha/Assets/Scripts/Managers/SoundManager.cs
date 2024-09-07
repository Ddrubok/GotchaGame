using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        Managers.Game.Sound = this;
    }
    public void PlaySound(string clipName)
    {
        AudioClip clip =Managers.Resource.Load<AudioClip>("SFX\\" + clipName);
        if (clip != null)
        {
            _audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("오디오 클립을 찾을 수 없습니다: " + clipName);
        }
    }
}
