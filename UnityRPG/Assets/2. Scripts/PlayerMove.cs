using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 8.0f;
    public float rotSpeed = 80.0f;

    [SerializeField] Transform tr;

    Animator playerAnim;

    private void Start()
    {
        tr = GetComponent<Transform>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float r = Input.GetAxis("Mouse X");

        Debug.Log("h=" + h.ToString());
        Debug.Log("v=" + v.ToString());

        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        tr.Translate(dir.normalized * playerSpeed * Time.deltaTime, Space.Self);

        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        if (v >= 0.1f)
        {
            if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("ForwardRun"))
            {
                playerAnim.SetTrigger("ForwardRun");
            }
        }
        else if (v <= -0.1f)
        {
            if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("BackRun"))
            {
                playerAnim.SetTrigger("BackRun");
            }
        }
        else if (h >= 0.1f)
        {
            if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("RightRun"))
            {
                playerAnim.SetTrigger("RightRun");
            }
        }
        else if (h <= -0.1f)
        {
            if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("LeftRun"))
            {
                playerAnim.SetTrigger("LeftRun");
            }
        }
        else
        {
            playerAnim.SetTrigger("Idle");
        }
    }
}
