using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [Header("Speaker & Lines")]
    public string[] speakerNames;   // <-- เพิ่มอันนี้
    [TextArea(2, 5)]
    public string[] lines;

    public DialogueSystem dialogue;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogue.StartDialogue(speakerNames, lines);  // ส่งชื่อ+ข้อความไป
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
