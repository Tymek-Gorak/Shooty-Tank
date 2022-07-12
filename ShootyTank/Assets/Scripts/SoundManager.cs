using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource soundManager;
    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(transform);
        soundManager = transform.gameObject.GetComponent<AudioSource>();

        sounds.Add("EShot", Resources.Load<AudioClip>("EShot"));
        sounds.Add("Hit", Resources.Load<AudioClip>("hit"));
        sounds.Add("Explosion", Resources.Load<AudioClip>("explosion"));
        sounds.Add("LaserShot", Resources.Load<AudioClip>("laserShot"));
        sounds.Add("Upgrade", Resources.Load<AudioClip>("upgrade"));
        sounds.Add("UpgradeFail", Resources.Load<AudioClip>("upgradeFail"));
        sounds.Add("StartGame", Resources.Load<AudioClip>("StartGame"));
        sounds.Add("Shot", Resources.Load<AudioClip>("playerShot"));
    }

    void Update()
    {
        
    }

    public void PlaySound(string soundName, float volume){
        soundManager.PlayOneShot(sounds[soundName], volume);
        Debug.Log("!");
    }
}
