using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScantoPlay : MonoBehaviour
{
    public void toMenuPlay()
    {
        SceneManager.LoadScene("Play");
    }
}
