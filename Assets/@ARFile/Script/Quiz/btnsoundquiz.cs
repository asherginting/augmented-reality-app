using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnsoundquiz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Switch()
    {
        if (PlayerPrefs.GetFloat("volume") == 0)
        {
            PlayerPrefs.SetFloat("volume", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("volume", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
