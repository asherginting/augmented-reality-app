using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HometoPlay : MonoBehaviour
{
    public void toMenuPlay()
    {
        SceneManager.LoadScene("Play");
    }    
}
