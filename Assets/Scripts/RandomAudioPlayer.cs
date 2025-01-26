using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] clips;


    AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip() {
        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
