using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sfx_btn : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameObject.Find("sfx_button") !=null)
        {
            GameObject.Find("sfx_button").GetComponent<AudioSource>().Play();
        }
    }
}
