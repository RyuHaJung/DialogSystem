using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 30f;
    private float timeElapsed = 0f;
    private bool gameEnded = false; // ������ �������� ���θ� ��Ÿ���� ����

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
        // ���� ���� ó��
        Time.timeScale = 1f;
        endGameButton.SetActive(true);
        gameEnded = true;
    }

    public void OnEndGameButtonClick()
    {
        // ��ư Ŭ�� ó��
        // ���� ���, ���� �޴��� ���ư��� ����� ������ �� �ֽ��ϴ�.
    }
}
