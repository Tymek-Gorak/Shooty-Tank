using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private SoundManager sound;
    private void Start() {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void Play(){
        sound.PlaySound("StartGame", 1f);
        SceneManager.LoadScene("TheGame");
    }
}
