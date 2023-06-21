using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tostart : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("StartScene");
    }
}
