using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestUI : MonoBehaviour
{
    public static QuestUI Instance;

    public Transform questContainer;
    public GameObject questItemPrefab;

    private List<GameObject> spawnedItems = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateUI();
    }

    void GenerateUI()
    {
        foreach (var quest in QuestManager.Instance.quests)
        {
            GameObject item = Instantiate(questItemPrefab, questContainer);

        RectTransform rt = item.GetComponent<RectTransform>();
        rt.localScale = Vector3.one;

        item.transform.GetChild(0)
            .GetComponent<TextMeshProUGUI>()
            .text = quest.title;

        item.transform.GetChild(1)
            .GetComponent<Toggle>()
            .isOn = quest.isCompleted;

        spawnedItems.Add(item);
    }
    }

    public void RefreshUI()
    {
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            Toggle toggle = spawnedItems[i].transform.GetChild(1).GetComponent<Toggle>();
            toggle.isOn = QuestManager.Instance.quests[i].isCompleted;
        }
    }
}
