using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource effectSource;
    public static SoundManager instance = null;

    public void PlaySingle(AudioClip clip) {
        effectSource.clip = clip;
        effectSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
