using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public float restartDelay = 5f; // 게임 종료 후 재시작까지의 딜레이 시간 설정

    private float timer; // 시간 측정용 변수

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // 시간 측정

        if (timer >= restartDelay) // 재시작 딜레이 시간이 지났을 때
        {
            if (Input.anyKeyDown) // 아무 키나 누르면 다시 시작
            {
                SceneManager.LoadScene("07ChickAvoidingPoopGame"); // "Game" 씬으로 이동하여 게임 다시 시작
            }
        }
    }
}
