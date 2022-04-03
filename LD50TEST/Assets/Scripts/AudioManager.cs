using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    void Awake() {

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //Debug.Log("Started playing " + name);
        s.source.Play();
    }
    public void StopSound(AudioSource sound) {
        //Debug.Log("Stopped playing " + sound.clip.name);
        sound.Stop();
    }
}