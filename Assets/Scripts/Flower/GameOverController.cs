using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public float restartDelay = 5f; // ���� ���� �� ����۱����� ������ �ð� ����

    private float timer; // �ð� ������ ����

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // �ð� ����

        if (timer >= restartDelay) // ����� ������ �ð��� ������ ��
        {
            if (Input.anyKeyDown) // �ƹ� Ű�� ������ �ٽ� ����
            {
                SceneManager.LoadScene("07ChickAvoidingPoopGame"); // "Game" ������ �̵��Ͽ� ���� �ٽ� ����
            }
        }
    }
}
