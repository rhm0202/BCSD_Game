using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateDate();
    }

    void GenerateDate()
    {
        talkData.Add(1000,new string[] {"안녕?:0", "이곳에 처음왔구나?:1",});
        talkData.Add(2000, new string[] { "안녕?:0", "너도 잡혀왔구나:1", "집 가고 싶다.:2",});

        talkData.Add(100, new string[] {"평범한 나무 상자다.",});
        talkData.Add(200, new string[] {"누군가 사용했던 흔적이 있는 책상이다.",});

        talkData.Add(10 + 1000, new string[] { "어서와:0", "다음은 루도랑 대화해봐:1", });
        talkData.Add(11 + 2000, new string[] { "소식 들었구나:0", "너에게 부탁할 일이 있어:1", "동전 좀 찾아줘:0", });

        talkData.Add(20 + 1000, new string[] { "루도의 동전?:1","나도 몰라:2", });
        talkData.Add(20 + 2000, new string[] { "제발 찾아줘...:0", });
        talkData.Add(20 + 5000, new string[] { "근처의 동전을 찾았다.", });
        talkData.Add(21 + 2000, new string[] { "엇 찾아줘서 고마워:2", });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {

            if (!talkData.ContainsKey(id - id % 10)){
                return GetTalk(id - (id % 100), talkIndex);
            }
            else
            {
                return GetTalk(id -  (id % 10), talkIndex);
            }
            
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
