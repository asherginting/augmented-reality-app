using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [System.Serializable]
    public class Soal {
        [TextArea]
        [Header("Soal")]
        public string soal;
        [Header("Pilihan")]
        public string[] pilihan;
        [Header("Jawaban")]
        public bool[] jawaban;
        [Header("Nilai")]
        public int nilai;
    }

    public bool random_soal, random_tombol;

    public TMP_Text text_soal, text_nomor, text_nilai, text_jwbbenar, text_jwbsalah, text_nilaiakhir;
    public Button[] jawaban;
    public Animator board;
    public GameObject feedback_benar, feedback_salah, hasil_quiz;
    int nilai = 0, jwbenar = 0, jwbsalah = 0, nomor = -1, terjawab = 0;

    public AudioSource suara_benar, suara_salah;

    Vector3[] posisi_tombol;

    public Soal[] soal;

    public void savePos_tombol() {
        posisi_tombol = new Vector3[jawaban.Length];
        for(int i=0; i<posisi_tombol.Length; i++) {
            posisi_tombol[i] = jawaban[i].transform.position;
        }
    }

    public void random_button()
    {
        bool[] pos = new bool[posisi_tombol.Length];
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = false;
        }

        int pos_random;

        for (int i = 0; i < pos.Length; i++) {
            do
            {
                pos_random = (int)Random.Range(0, pos.Length - 0.6f);
            } while (pos[pos_random]);
            pos[pos_random] = true;
            jawaban[i].transform.position = posisi_tombol[pos_random];
        }
    }

    public void set_soal()
    {
        if (random_soal)
        {
            //Soal Random
            nomor = (int)Random.Range(0, soal.Length -0.6f);
            if (terjawab < soal.Length)
            {
                if (soal[nomor].soal == "terjawab")
                {
                    set_soal();
                }
                else
                {
                    text_soal.text = soal[nomor].soal;
                    for (int i = 0; i < jawaban.Length; i++)
                    {
                        jawaban[i].GetComponent<Animator>().Play(0);
                        jawaban[i].transform.GetChild(0).GetComponent<TMP_Text>().text = soal[nomor].pilihan[i];
                    }
                    soal[nomor].soal = "terjawab";
                    terjawab++;
                    text_nomor.text = terjawab.ToString();
                    if(random_tombol) {
                        random_button();
                    }
                }
            }
            else
            {
                board.gameObject.SetActive(false);
                hasil_quiz.SetActive(true);
            }
        }
        else
        {
            //Soal tidak Random
            nomor++;
            if (nomor < soal.Length)
            {
                board.Play(0);
                text_soal.text = soal[nomor].soal;
                for (int i = 0; i < jawaban.Length; i++)
                {
                    jawaban[i].GetComponent<Animator>().Play(0);
                    jawaban[i].transform.GetChild(0).GetComponent<TMP_Text>().text = soal[nomor].pilihan[i];
                }
                text_nomor.text = (nomor + 1).ToString();
                if (random_tombol) {
                    random_button();
                }
            }
            else
            {
                board.gameObject.SetActive(false);
                hasil_quiz.SetActive(true);
            }
        }
    }
    public void jawab(int index) {
        bool jawaban_benar = false;
        for(int i = 0; i < jawaban.Length; i++) {
            if(index == i && soal[nomor].jawaban[i]) {
                jawaban_benar = true;
                i = jawaban.Length;
            }
        }
        if (jawaban_benar) {
            suara_benar.Play();
            feedback_benar.SetActive(true);
            feedback_benar.GetComponent<Animator>().Play(0);
            nilai += soal[nomor].nilai;
            jwbenar++;
            jwbsalah--;
        } else {
            suara_salah.Play();
            feedback_salah.SetActive(true);
            feedback_salah.GetComponent<Animator>().Play(0);
        }
    }

    public void output() {
        text_nilai.text = nilai.ToString();
        text_jwbbenar.text = jwbenar.ToString();
        text_jwbsalah.text = jwbsalah.ToString();
        text_nilaiakhir.text = nilai.ToString();
    }

    void Update() {
        output();
    }

    void Start() {
        savePos_tombol();
        set_soal();
        jwbsalah = soal.Length;
    }
}
