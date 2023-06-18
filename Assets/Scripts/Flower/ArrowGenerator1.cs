using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator1 : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;  //������ ��ġ�� �ϰ� ������ 0.5�ʷ� �ٲ��
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-9, 10);    //�������� -9���� 9���� ���´� ��Ʈ���� 7���� x
            go.transform.position = new Vector3(px, 7, 0);
        }

    }
}
