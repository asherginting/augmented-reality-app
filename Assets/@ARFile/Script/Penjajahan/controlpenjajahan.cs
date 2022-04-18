using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlpenjajahan : MonoBehaviour
{
    float x, y;
    public GameObject slider;
    public int kontrol;
    //use this initialization
    void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
    }

    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        transform.localScale = new Vector2(x * 1.2f, y / 1.2f);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector2(x, y);
        slider.GetComponent<slidepenjajahan>().controlpenjajahan(kontrol);
    }

    //Update is called one per frame
    void update()
    {

    }
}