using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waktuquiz : MonoBehaviour
{
    public float menit, detik;

    public GameObject board, hasil_kuis; 

    // Update is called once per frame
    void Update()
    {
        if (board.activeSelf) {
            if(detik >= 0) {
                detik -= Time.deltaTime;
            } else {
                if (menit > 0) {
                    detik = 60;
                    menit--;
                } else {
                    board.SetActive(false);
                    hasil_kuis.SetActive(true);
                }
            }
        }

        string menit_, detik_;

        if (menit < 10) {
            menit_ = "0" + ((int)menit).ToString();
        } else {
            menit_ = ((int)menit).ToString();
        }

        if (detik < 10) {
            detik_ = "0" + ((int)detik).ToString();
        } else {
            detik_ = ((int)detik).ToString();
        }

        GetComponent<TMP_Text>().text = menit_ + " : " + detik_;
    }
}