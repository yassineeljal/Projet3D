using UnityEngine;

public class QuestZombieCounter : MonoBehaviour
{
    public static QuestZombieCounter Instance;
    public int zombiesInVillage = 10;
    private int killed = 0;

    void Awake()
    {
        Instance = this;
    }

    public void ZombieKilled()
    {
        killed++;

        if (killed >= zombiesInVillage)
        {
            QuestManager.Instance.CompleteQuest(2);
        }
    }
}
