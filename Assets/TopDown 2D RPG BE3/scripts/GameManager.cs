using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator talkpanel;
    public TalkManager talkManager;
    public int talkIndex;
    public TypeEffect talk;
    public Text quesTtalk;

    public QuestManager questManager;
    
    public Image portraitImg;
    public Animator portraitAni;
    public Sprite prePort;
    public GameObject scanObject;
    public GameObject menuSet;
    public bool isAction;
    
    

    private void Start()
    {
        quesTtalk.text = questManager.CheckQuest();
    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
            }
            else
                menuSet.SetActive(true);
        }   
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkpanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {

        int questTalkIndex = 0;
        string talkData = "";

        if ((talk.isAni))
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        }

        if ((talkData == null))
        {
            isAction = false;
            talkIndex = 0;
            quesTtalk.text = questManager.CheckQuest(id);
            return;
        }
        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            if(prePort != portraitImg.sprite)
            {
                portraitAni.SetTrigger("doEffect");
                prePort = portraitImg.sprite;
            }
            
        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}