using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public List<Quest> quests = new List<Quest>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        quests.Add(new Quest { title = "Trouver le pistolet", isCompleted = false });
        quests.Add(new Quest { title = "Trouver des munitions", isCompleted = false });
        quests.Add(new Quest { title = "Sortir du village en tuant les zombies", isCompleted = false });
        quests.Add(new Quest { title = "Trouver l’arme au sommet de la montagne", isCompleted = false });
        quests.Add(new Quest { title = "Éliminer tous les zombies", isCompleted = false });
    }

    public void CompleteQuest(int index)
    {
        if (index < 0 || index >= quests.Count) return;

        quests[index].isCompleted = true;
        QuestUI.Instance.RefreshUI();
    }
}
