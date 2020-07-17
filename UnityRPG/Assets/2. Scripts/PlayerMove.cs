using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 5f;
    public Transform joystick;

    Vector3 stickFirestPos;
    Vector3 joyVec;
    float radius;
    bool moveFlag;

    private void Start()
    {
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        stickFirestPos = joystick.transform.position;

        float can = transform.parent.GetComponent<RectTransform>().localScale.x;
        radius *= can;

        moveFlag = false;
    }

    void Update()
    {
        if (moveFlag)
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
    }

    public void Drag(BaseEventData _data)
    {
        
    }
}
