using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject arrowFactory;

    public Queue<GameObject> arrowPool;
    int poolingMax = 40;

    [SerializeField] Transform firePosition;

    public float attackCount = 1.0f;
    float count = 1.0f;

    void Start()
    {
        InitObjectPooling();
    }

    private void InitObjectPooling()
    {
        arrowPool = new Queue<GameObject>();
        for (int i = 0; i < poolingMax; i++)
        {
            GameObject arrow = Instantiate(arrowFactory);
            arrow.SetActive(false);
            arrowPool.Enqueue(arrow);
        }
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            count += Time.deltaTime;
            if(count >= attackCount)
            {
                count = 0f;
                GameObject arrow = arrowPool.Dequeue();
                arrow.SetActive(true);
                arrow.transform.position = firePosition.transform.position;
                arrow.transform.forward = firePosition.transform.forward;
            }
        }
    }
}
