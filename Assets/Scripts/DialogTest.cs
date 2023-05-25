using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem;
    public int Dialogindex = 0;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog(Dialogindex, true)); //��ٸ��� �Լ� , ���̾�α� �ý����� �Ϸ� �ɶ� ���� 
        //�μ��� ��� ��ȣ
    }
}
