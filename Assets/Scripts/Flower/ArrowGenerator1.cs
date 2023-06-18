using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator1 : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;  //박진감 넘치게 하고 싶으면 0.5초로 바꿔라
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-9, 10);    //무작위로 -9에서 9까지 나온다 인트여서 7포함 x
            go.transform.position = new Vector3(px, 7, 0);
        }

    }
}
