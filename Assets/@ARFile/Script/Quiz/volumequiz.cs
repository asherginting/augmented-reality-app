using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumequiz : MonoBehaviour
{
    public void sound_volume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
}
