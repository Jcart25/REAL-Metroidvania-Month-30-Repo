using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideoutDialogue : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject SupervisorBubble;
    public int DialogueNumber;

    public bool TalkToSupervisor;
    public bool SupervisorTalk;

    //Get the player Rigidbody
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueNumber = 0;
        DialoguePanel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        SupervisorBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (TalkToSupervisor)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech();
        }
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && SupervisorTalk)
        {
            Debug.Log("Character Talking");
            TalkToSupervisor = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Supervisor")
        {
            Debug.Log("Player Collision");
            SupervisorBubble.SetActive(true);
            SupervisorTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Supervisor")
        {
            Debug.Log("Player Leaving");
            SupervisorBubble.SetActive(false);
            SupervisorTalk = false;
        }
    }

    void NicoleSpeech()
    {
        DialoguePanel.SetActive(true);

        if (TalkToSupervisor)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "61375! Report!";
                break;

            case 2:
                CharacterText.text = "One more confirmed survivor ma’am.";
                break;

            case 3:
                CharacterText.text = "Well it’s better than nothing. Alright maggots, listen up! It seems the forces of nature have risen against us! And boy do they pack a punch!";
                break;

            case 4:
                CharacterText.text = "So what do we do?";
                break;

            case 5:
                CharacterText.text = "The job hasn’t changed! We’re to proceed with Project Full Measure. It’s just going to be a bit more challenging than we thought.";
                break;

            case 6:
                CharacterText.text = "Or maybe, and I’m just spitballing here, we take this as a sign to leave the forest alone?";
                break;

            case 7:
                CharacterText.text = "Are you questioning your orders, 61375? If you are, I can have your whole family out on the streets!";
                break;

            case 8:
                CharacterText.text = "Alright, I guess I'm not then.";
                break;

            case 9:
                CharacterText.text = "Excellent! You! You’re in charge of scouting ahead. There’s probably gonna be some crazy shit in this tunnel, so be prepared.";
                break;

            case 10:
                CharacterText.text = "You should find another supervisor back on the surface. They’ll give you your next assignment. Everyone else, get equipped for battle. Dismissed!";
                break;

            case 11:
                DialoguePanel.SetActive(false);
                TalkToSupervisor = false;
                SupervisorTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }
}
