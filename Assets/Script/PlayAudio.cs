using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public string audios;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play(audios);
    }

}
