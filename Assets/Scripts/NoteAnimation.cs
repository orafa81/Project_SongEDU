using UnityEngine;
using System.Collections.Generic;

public class NoteAnimation : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    public List<NoteData> noteDataList;
    private int currentNoteIndex = 0;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = noteDataList[0].startPos;
    }

    private void Update()
    {
        MoveNote();
    }

    private void MoveNote()
    {
        if (currentNoteIndex >= noteDataList.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector2 newPos = rectTransform.anchoredPosition;
        newPos.x -= moveSpeed * Time.deltaTime;
        rectTransform.anchoredPosition = newPos;

        if (newPos.x < noteDataList[currentNoteIndex].startPos.x - noteDataList[currentNoteIndex].duration)
        {
            currentNoteIndex++;
            if (currentNoteIndex < noteDataList.Count)
            {
                rectTransform.anchoredPosition = noteDataList[currentNoteIndex].startPos;
            }
        }
    }
}

[System.Serializable]
public class NoteData
{
    public Vector2 startPos;
    public float duration;
    public string pianoKey;
    // Add more properties as needed
}
