using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] Text finText;
    [SerializeField] Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        finText.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        finText.gameObject.SetActive(true);
        //ItemSound.FinishSound();

        BackButton.gameObject.SetActive(true);
        //ItemSound.FinishSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
