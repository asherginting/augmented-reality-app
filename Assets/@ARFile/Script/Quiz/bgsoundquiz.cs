﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgsoundquiz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");

        if (SceneManager.GetActiveScene().name == "Quiz1")
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}

