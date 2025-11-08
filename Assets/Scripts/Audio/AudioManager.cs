using UnityEngine;
using System.Collections.Generic;

// Serializable class for easy clip lookup
[System.Serializable]
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.3f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public List<Sound> sounds;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Create an AudioSource for each sound
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.playOnAwake = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Play by name
    public void Play(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s != null && s.clip != null)
        {
            s.source.PlayOneShot(s.clip);
        }
        else
        {
            Debug.LogWarning("AudioManager: Sound not found or clip is null -> " + name);
        }
    }

    // Play with small random pitch variation
    public void PlayWithPitchRandom(string name, float minPitch = 0.95f, float maxPitch = 1.05f)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s != null && s.clip != null)
        {
            s.source.pitch = Random.Range(minPitch, maxPitch);
            s.source.PlayOneShot(s.clip);
            s.source.pitch = 1f; // reset to default
        }
        else
        {
            Debug.LogWarning("AudioManager: Sound not found or clip is null -> " + name);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s != null && s.clip != null)
        {
            s.source.loop = true;
            s.source.Play();
        }
    }

    public void StopMusic(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s != null)
            s.source.Stop();
    }
}