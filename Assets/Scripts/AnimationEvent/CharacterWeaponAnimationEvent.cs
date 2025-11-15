using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponAnimationEvent : MonoBehaviour
{
    [SerializeField] Transform hipGS;
    [SerializeField] Transform handGS;
    [SerializeField] Transform handkatana;
    void ShowGS()
    {
        if (!handGS.gameObject.activeSelf)
        {
            hipGS.gameObject.SetActive(false);
            handkatana.gameObject.SetActive(false);
            handGS.gameObject.SetActive(true);
        }
    }
    void HideGS()
    {
        if (handGS.gameObject.activeSelf)
        {
            hipGS.gameObject.SetActive(true);
            handkatana.gameObject.SetActive(true);
            handGS.gameObject.SetActive(false);
        }
    }
}

