using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    // เปลี่ยนจาก string ธรรมดา เป็น array ของ string เพื่อเก็บชื่อหลายรายการ
    public string[] characterNames;   // <--- แก้ไขตรงนี้: รายการชื่อตัวละครสำหรับแต่ละบรรทัด
    public string[] dialogueLines;    // ประโยคทั้งหมดของ NPC
    public DialogueSystem dialogueSystem; // ต้องแน่ใจว่าได้อ้างอิงถึง DialogueSystem ใน Inspector

    private bool playerInRange = false;
    private bool isTalking = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
            {
                StartDialogue();
            }
            else
            {
                dialogueSystem.NextSentence();
            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;

        // **ส่วนที่ถูกแก้ไข:**
        // ลบโค้ดวนลูปเดิมที่สร้างชื่อซ้ำ ๆ ออกไป
        // และส่ง array ชื่อ (characterNames) ที่เรากำหนดไว้ใน Inspector เข้าไปแทน

        dialogueSystem.StartDialogue(characterNames, dialogueLines);
    }

    // ฟังก์ชัน OnTriggerEnter2D และ OnTriggerExit2D ยังคงเหมือนเดิม
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            isTalking = false;
        }
    }
}