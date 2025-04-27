using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject endCursor;
    string targetMsg;
    Text msgText;
    AudioSource audioSource;
    int index;
    float interval;
    public bool isAni;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();  
    }

    public void SetMsg(string msg)
    {
        if (isAni)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
            
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);
        
        interval = 1.0f/ CharPerSeconds;
        isAni = true;

        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        
        msgText.text += targetMsg[index];
        

        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
        {
            audioSource.Play();
        }
        
        index++;

        Debug.Log(interval);
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        endCursor.SetActive(true);
        isAni = false;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
