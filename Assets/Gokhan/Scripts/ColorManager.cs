using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gokhan.Scripts
{

    public class ColorManager : MonoBehaviour
    {
        public GameObject _0, _1, _2, _3;
        public Button B0, B1, B2, B3;
        public Material M0, M1, M2, M3;
        public Color A0, A1;
        

    
        public void ButtonControl(string Buton)
        {

            switch (Buton)
            {
                case "0":

                    //A0 = M1.color;
                    //A0.a = 0.5f;
                    //M1.color = A0;

                    //A1 = M1.color;
                    //A0.a = 0.5f;
                    //M1.color = A0;
                    _0.SetActive(true);
                    _1.SetActive(false);
                    _2.SetActive(false);
                    _3.SetActive(false);
                    B0.interactable = false;
                    B1.interactable = true;
                    B2.interactable = true;
                    B3.interactable = true;

                    break;
                case "1":
                    _0.SetActive(false);
                    _1.SetActive(true);
                    _2.SetActive(false);
                    _3.SetActive(false);
                    B0.interactable = true;
                    B1.interactable = false;
                    B2.interactable = true;
                    B3.interactable = true;
                    break;
                case "2":
                    _0.SetActive(false);
                    _1.SetActive(false);
                    _2.SetActive(true);
                    _3.SetActive(false);
                    B0.interactable = true;
                    B1.interactable = true;
                    B2.interactable = false;
                    B3.interactable = true;
                    break;
                case "3":
                    _0.SetActive(false);
                    _1.SetActive(false);
                    _2.SetActive(false);
                    _3.SetActive(true);
                    B0.interactable = true;
                    B1.interactable = true;
                    B2.interactable = true;
                    B3.interactable = false;
                    break;
            }


        }
    }
}