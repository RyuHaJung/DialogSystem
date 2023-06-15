using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI�� ��Ʈ�� �� ���̶� �߰�
using System;                       //Arry ���� ����� ����ϱ� ���� �߰�
using UnityEngine.SceneManagement;  //Scene �̵��� ���� �߰� 

public class DialogSystem : MonoBehaviour
{
    public enum DIALOGSTATE
    {
        DIALONGING,
        SELECTBUTTON
    }

    public Image BackGround;                            //����̹���

    [SerializeField]
    private SpeakerUI[] speakers;                       //��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    [SerializeField]
    private DialogData[] dialogs;                       //���� �б��� ��� ��� �迭
    [SerializeField]
    private SelectData[] selectData;                       //���� �б��� ��� ��� �迭
    [SerializeField]
    private bool DialogInit = true;                     //�ڵ� ���� ����
    [SerializeField]
    private bool dialogsDB = false;                     //DB�� ���� �д°� ����

    public int currentDialogIndex = -1;                 //���� ��� ����
    public int currentSpeakerIndex = 0;                 //���� ���� �ϴ� ȭ���� Speakers �迭 ����
    public float typingSpeed = 0.1f;                    //�ؽ�Ʈ Ÿ���� ȿ���� ����ӵ�
    public bool isTypingEffect = false;                 //�ؽ�Ʈ Ÿ���� ȿ���� ��������� �Ǵ�.

    public GameObject select_001;
    public Text selectTextMain_01;
    public Button select_001_Button_01;
    public Text select_001_Button_01_Text;
    public Button select_001_Button_02;
    public Text select_001_Button_02_Text;

    public GameObject select_002;
    public Text selectTextMain_02;
    public Button select_002_Button_01;
    public Text select_002_Button_01_Text;
    public Button select_002_Button_02;
    public Text select_002_Button_02_Text;
    public Button select_002_Button_03;
    public Text select_002_Button_03_Text;

    public Entity_Dialogue entity_Dialogue;
    public Entity_SelectData entity_SelectData;

    public DIALOGSTATE dialogstate;

    public int currentSelectIndex;

    public void SetButtonEvent()
    {
        select_001_Button_01.onClick.AddListener(() => ButtonCliecked(1));
        select_001_Button_02.onClick.AddListener(() => ButtonCliecked(2));
        select_002_Button_01.onClick.AddListener(() => ButtonCliecked(1));
        select_002_Button_02.onClick.AddListener(() => ButtonCliecked(2));
        select_002_Button_03.onClick.AddListener(() => ButtonCliecked(3));
    }

    public void ButtonCliecked(int type)
    {
        if (type == 1) SetNextDialog(selectData[currentSelectIndex].nextindex_01);
        if (type == 2) SetNextDialog(selectData[currentSelectIndex].nextindex_02);
        if (type == 3) SetNextDialog(selectData[currentSelectIndex].nextindex_03);

         dialogstate = DIALOGSTATE.DIALONGING;
    }

    private void Awake()
    {
        SetAllClose();
        SetButtonEvent();
        if (dialogsDB)
        {
            Array.Clear(dialogs, 0, dialogs.Length);
            Array.Resize(ref dialogs, entity_Dialogue.sheets[0].list.Count);

            int ArrayCursor = 0;
            foreach (Entity_Dialogue.Param param in entity_Dialogue.sheets[0].list)
            {
                dialogs[ArrayCursor].index = param.index;
                dialogs[ArrayCursor].speakerUIindex = param.speakerUIindex;
                dialogs[ArrayCursor].name = param.name;
                dialogs[ArrayCursor].dialogue = param.dialogue;
                dialogs[ArrayCursor].characterPath = param.characterPath;
                dialogs[ArrayCursor].backGroundPath = param.BackGroundPath;
                dialogs[ArrayCursor].tweenType = param.tweenType;
                dialogs[ArrayCursor].nextindex = param.nextindex;
                dialogs[ArrayCursor].selectIndex = param.selectIndex;
                dialogs[ArrayCursor].nextScene = param.nextScene;

                ArrayCursor += 1;
            }

            Array.Clear(selectData, 0, selectData.Length);
            Array.Resize(ref selectData, entity_SelectData.sheets[0].list.Count);

            ArrayCursor = 0;
            foreach (Entity_SelectData.Param param in entity_SelectData.sheets[0].list)
            {
                selectData[ArrayCursor].index = param.index;
                selectData[ArrayCursor].selectAmount = param.selectAmount;
                selectData[ArrayCursor].selectMain = param.selectMain;
                selectData[ArrayCursor].select_01 = param.select_01;
                selectData[ArrayCursor].select_02 = param.select_02;
                selectData[ArrayCursor].select_03 = param.select_03;
                selectData[ArrayCursor].nextindex_01 = param.nextindex_01;
                selectData[ArrayCursor].nextindex_02 = param.nextindex_02;
                selectData[ArrayCursor].nextindex_03 = param.nextindex_03;

                ArrayCursor += 1;
            }
        }
    }

    //�Լ��� ���� UI�� �������ų� �Ⱥ������� ����
    private void SetActiveObjects(SpeakerUI speaker, bool visible)  
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        //ȭ��ǥ ��簡 ����Ǿ��� ���� Ȱ��ȭ �Ǳ� ������ 
        speaker.objectArrow.SetActive(false);

        Color color = speaker.imgCharacter.color;
        if(visible)
        {
            color.a = 1;
        }
        else
        {
            color.a = 0.2f;
        }
        speaker.imgCharacter.color = color;
    }

    private void SetActiveObjectsOFF(SpeakerUI speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        //ȭ��ǥ ��簡 ����Ǿ��� ���� Ȱ��ȭ �Ǳ� ������ 
        speaker.objectArrow.SetActive(false);

        Color color = speaker.imgCharacter.color;
        if (visible)
        {
            color.a = 1;
        }
        else
        {
            color.a = 0.0f;
        }
        speaker.imgCharacter.color = color;
    }

    private void SetAllClose()
    {
        select_001.SetActive(false);
        select_002.SetActive(false);
        for (int i = 0; i < speakers.Length; i++)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    private void SetAllCloseOFF()
    {
        select_001.SetActive(false);
        select_002.SetActive(false);
        for (int i = 0; i < speakers.Length; i++)
        {
            SetActiveObjectsOFF(speakers[i], false);
        }
    }

    private void SetNextDialog(int currentIndex)
    {
        SetAllClose();
        currentDialogIndex = currentIndex;          //���� ��縦 �����ϵ���
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerUIindex;       //���� ȭ�� ���� ����
        if(currentSpeakerIndex < 0)
        {
            SetAllCloseOFF();
        }
        else
        {
            SetActiveObjects(speakers[currentSpeakerIndex], true);                  //���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
            speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name; //���� ȭ���� �̸� �ؽ�Ʈ ����
            StartCoroutine("OnTypingText");
        }
       
    }

    private void SetNextSelect(int currentIndex)
    {
        dialogstate = DIALOGSTATE.SELECTBUTTON;
        currentSelectIndex = currentIndex;

        if (selectData[currentIndex].selectAmount == 2)
        {
            select_001.SetActive(true);
            selectTextMain_01.text = selectData[currentIndex].selectMain;
            select_001_Button_01_Text.text = selectData[currentIndex].select_01;
            select_001_Button_02_Text.text = selectData[currentIndex].select_02;
        }
        else if (selectData[currentIndex].selectAmount == 3)
        {
            select_002.SetActive(true);
            selectTextMain_02.text = selectData[currentIndex].selectMain;
            select_002_Button_01_Text.text = selectData[currentIndex].select_01;
            select_002_Button_02_Text.text = selectData[currentIndex].select_02;
            select_002_Button_03_Text.text = selectData[currentIndex].select_03;
        }       
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;

        if(dialogs[currentDialogIndex].characterPath.CompareTo("None") != 0) //None�� �ƴҰ�� DB�� �־���� ����� ĳ���� �̹����� �����´�.
        {
            speakers[currentSpeakerIndex].imgCharacter.gameObject.SetActive(true);
            speakers[currentSpeakerIndex].imgCharacter.sprite =
                Resources.Load<Sprite>(dialogs[currentDialogIndex].characterPath);
        }
        else
        {
            speakers[currentSpeakerIndex].imgCharacter.gameObject.SetActive(false);
        }

        if (dialogs[currentDialogIndex].backGroundPath.CompareTo("None") != 0) //None�� �ƴҰ�� DB�� �־���� ����� ��� �̹����� �����´�
        {
            BackGround.sprite =
                Resources.Load<Sprite>(dialogs[currentDialogIndex].backGroundPath);
        }

        while (index < dialogs[currentDialogIndex].dialogue.Length + 1)
        {
            speakers[currentSpeakerIndex].textDialogue.text =
                dialogs[currentDialogIndex].dialogue.Substring(0, index);   //�ؽ�Ʈ�� �ѱ��ھ� Ÿ���� ��� 

            index++;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }

    public bool UpdateDialog(int currentIndex, bool InitType)
    {
        //��� �бⰡ 1ȸ�� ȣ�� 
        if(DialogInit == true && InitType == true)
        {
            SetAllClose();
            SetNextDialog(currentIndex);
            DialogInit = false;
            dialogstate = DIALOGSTATE.DIALONGING;
        }
        if(Input.GetMouseButtonDown(0) && dialogstate == DIALOGSTATE.DIALONGING)
        {
            if(isTypingEffect == true)
            {
                isTypingEffect = false;
                StopCoroutine("OnTypingText");          //Ÿ���� ȿ���� �����ϰ� , ���� ��� ��ü�� ����Ѵ�.
                speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
                //��簡 �Ϸ�Ǿ��� �� Ŀ�� 
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }

            if (dialogs[currentDialogIndex].speakerUIindex == -1)
            {
                SetNextDialog(dialogs[currentDialogIndex].nextindex);
            }

            if (dialogs[currentDialogIndex].selectIndex != -100)
            {
                SetNextSelect(dialogs[currentDialogIndex].selectIndex);
            }                       
            else if (dialogs[currentDialogIndex].nextScene.CompareTo("None") != 0)
            {
                SceneManager.LoadScene(dialogs[currentDialogIndex].nextScene);
            }
            else if (dialogs[currentDialogIndex].nextindex != -100)
            {
                SetNextDialog(dialogs[currentDialogIndex].nextindex);
            }           
            else
            {
                SetAllClose();
                DialogInit = true;
                return true;
            }
        }
        return false;
    }

    [System.Serializable]
    public struct SpeakerUI
    {
        public Image imgCharacter;          //ĳ���� �̹���
        public Image imageDialog;           //��ȭâ ImageUI
        public Text textName;               //���� ������� ĳ���� �̸� ��� TextUI
        public Text textDialogue;           //���� ��� ��� Text UI
        public GameObject objectArrow;      //��簡 �Ϸ�Ǿ��� �� ����ϴ� Ŀ�� ������Ʈ
    }

    [System.Serializable]
    public struct DialogData
    {
        public int index;                   //��� ��ȣ
        public int speakerUIindex;          //����Ŀ �迭 ��ȣ
        public string name;                 //�̸�
        public string dialogue;             //���
        public string characterPath;        //ĳ���� �̹��� ���
        public string backGroundPath;        //ĳ���� �̹��� ���
        public int tweenType;               //Ʈ�� ��ȣ
        public int nextindex;               //���� ��� 
        public int selectIndex;             //���� ����       
        public string nextScene;            //���� ��

    }

    [System.Serializable]
    public struct SelectData
    {
        public int index;                   //������ ��ȣ
        public int selectAmount;            //������ ����
       
        public string selectMain;         //���� UI String

        public string select_01;
        public string select_02;
        public string select_03;

        public int nextindex_01;
        public int nextindex_02;
        public int nextindex_03;
    }


}