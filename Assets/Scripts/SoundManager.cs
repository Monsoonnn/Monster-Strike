using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }


    [SerializeField] private AudioRefSO audioRefSO;


    private void Awake() {
        
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        } else {
            Destroy(gameObject);
        }
    }

    public void MonsterSound(Vector3 positon) { 
        PlaySound(audioRefSO.monster[0], positon, 1f);
    }

    public void GameOver( Vector3 positon ) {
        PlaySound(audioRefSO.gameover[0], positon);
    }

    public void OpenChest( Vector3 positon ) { 
        PlaySound(audioRefSO.openchest[0],positon);
    }

    public void ArrowSound( Vector3 positon ) {
        PlaySound(audioRefSO.arrow[0], positon);
    }
    public void SwordSound( Vector3 positon ) {
        PlaySound(audioRefSO.sword[1], positon);
    }
    public void Portal( Vector3 positon ) {
        PlaySound(audioRefSO.portal[0], positon);
    }

    private void PlaySound(AudioClip audioClip, Vector3 positon, float volume = 1f) {
        AudioSource.PlayClipAtPoint(audioClip, positon, volume);
    }
}
