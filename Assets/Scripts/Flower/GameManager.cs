using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 30f;
    private float timeElapsed = 0f;
    private bool gameEnded = false; // 게임이 끝났는지 여부를 나타내는 변수

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeLimit)
            {
                EndGame();
            }
        }
    }

    public GameObject endGameButton;

    public void EndGame()
    {
        // 게임 종료 처리
        Time.timeScale = 1f;
        endGameButton.SetActive(true);
        gameEnded = true;
    }

    public void OnEndGameButtonClick()
    {
        // 버튼 클릭 처리
        // 예를 들어, 메인 메뉴로 돌아가는 기능을 구현할 수 있습니다.
    }
}
