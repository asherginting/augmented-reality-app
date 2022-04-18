using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_soal : MonoBehaviour
{
    public Quiz Quiz;

    public void nextsoal()
    {
        Quiz.set_soal();
    }
}
