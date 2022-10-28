using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IconFollow : MonoBehaviour
{

    public Transform target;

    public RectTransform canvas;

    public RectTransform icon, helper;

    public Camera cam;

    //Limites del canvas
    private float limitRight, limitLeft, limitUp, limitDown;


    void Start()
    {
        limitRight = canvas.sizeDelta.x / 2;
        limitLeft = -limitRight;

        limitUp = canvas.sizeDelta.y / 2;
        limitDown = -limitUp;
    }


    void Update()
    {
        Vector2 finalPos = cam.WorldToScreenPoint(target.position);
        icon.position = finalPos;
        helper.position = finalPos;

        if (icon.anchoredPosition.x < limitRight - (icon.sizeDelta.x / 2) && icon.anchoredPosition.x > limitLeft + (icon.sizeDelta.x / 2)
            && icon.anchoredPosition.y < limitUp - (icon.sizeDelta.y / 2)&&(icon.anchoredPosition.y > limitDown + (icon.sizeDelta.y / 2)))
            {
                icon.gameObject.SetActive(false);
            }
        else
        {
            icon.gameObject.SetActive(true);
            if (icon.anchoredPosition.x > limitRight - (icon.sizeDelta.x / 2)) //si te has pasado del limite de la derecha
            {
                icon.anchoredPosition = new Vector2(limitRight - (icon.sizeDelta.x / 2), icon.anchoredPosition.y);
            }
            else if (icon.anchoredPosition.x < limitLeft + (icon.sizeDelta.x / 2))
            {
                icon.anchoredPosition = new Vector2(limitLeft + (icon.sizeDelta.x / 2), icon.anchoredPosition.y);
            }
            if (icon.anchoredPosition.y > limitUp - (icon.sizeDelta.y / 2))
            {
                icon.anchoredPosition = new Vector2(icon.anchoredPosition.x, limitUp - (icon.sizeDelta.y / 2));
            }
            else if (icon.anchoredPosition.y < limitDown + (icon.sizeDelta.y / 2))
            {
                icon.anchoredPosition = new Vector2(icon.anchoredPosition.x, limitDown + (icon.sizeDelta.y / 2));
            }
        }
        Vector2 dirLookAt = helper.position - icon.position;
        float angle = Mathf.Atan2(dirLookAt.y, dirLookAt.x) * Mathf.Rad2Deg;
        icon.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

    }
}
