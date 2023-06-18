using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;  // 플레이어 이동 속도

    // Update is called once per frame
    void Update()
    {
        // 좌우 이동
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3, 0, 0);
        }*/
    }
    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }
}
