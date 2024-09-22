using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    [SerializeField] private AudioClip vitoria;

    [SerializeField] private AudioClip derrota;

    [SerializeField] private AudioClip moeda;

    [SerializeField] private AudioClip background;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioSource musicadefundo;


    private void Start(){
        musicadefundo.clip = background;
        musicadefundo.Play();
    }    

    private void TocarSom(AudioClip audioClip, float volume = 1){
        this.audioSource.PlayOneShot(audioClip, volume);
    }

    public void TocarSomVitoria(){
        TocarSom(this.vitoria);
    }

    public void TocarSomDerrota(){
        TocarSom(this.derrota, 0.75f);
    }

    public void TocarSomMoeda(){
        TocarSom(this.moeda, 0.5f);
    }

}
