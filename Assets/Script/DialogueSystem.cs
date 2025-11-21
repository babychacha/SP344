using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text npcNameText;

    private string[] sentences;
    private string[] speakers;   // เพิ่มอันนี้
    private int index;

    void Start()
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    // ใช้ชื่อ + ประโยคเป็นอาร์เรย์คู่กัน
    public void StartDialogue(string[] speakerNames, string[] lines)
    {
        speakers = speakerNames;
        sentences = lines;
        index = 0;

        dialoguePanel.SetActive(true);
        npcNameText.text = speakers[index];   // ใช้ชื่อจาก speakers
        dialogueText.text = sentences[index];
    }

    public void NextSentence()
    {
        if (sentences == null || sentences.Length == 0) return;

        if (index < sentences.Length - 1)
        {
            index++;
            npcNameText.text = speakers[index];   // เปลี่ยนชื่อให้ตรงคนพูด
            dialogueText.text = sentences[index];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (dialoguePanel != null && dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }
}
