using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    public GameObject gameOver_Obj;
    

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
        
    }
    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
        if (this.hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            gameOver_Obj.SetActive(true);
            
        }
    }

    public void CreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount += 0.1f;
        if (this.hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            gameOver_Obj.SetActive(true);

        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
