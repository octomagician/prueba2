using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public List<AudioClip>audioClips;
    public AudioSource audio_disparos;
    public AudioSource audio_explosiones;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySonidoDisparo()
    {
        //toma el audio de disparos con el método play one shot para que reproduzca un sonido en particular (en el array el lugar 0)
        audio_disparos.PlayOneShot(audioClips[0]);
    }

    public void PlaySonidoExplosion()
    {
        audio_explosiones.PlayOneShot(audioClips[1]);
    }
}
