using UnityEngine;

public class QuestData
{
    public string questName;
    public int[] npcId;

    public QuestData(string questName, int[] npcId)
    {
        this.questName = questName;
        this.npcId = npcId;
    }
}
