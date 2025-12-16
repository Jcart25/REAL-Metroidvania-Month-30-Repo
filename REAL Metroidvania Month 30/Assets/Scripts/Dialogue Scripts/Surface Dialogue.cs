using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class SurfaceDialogue : MonoBehaviour
{

    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject SupervisorBubble;
    public int DialogueNumber;

    public bool NEWTalkToSupervisor;
    public bool NEWSupervisorTalk;

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
        if (NEWTalkToSupervisor)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech();
        }
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && NEWSupervisorTalk)
        {
            Debug.Log("Character Talking");
            NEWTalkToSupervisor = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "New Supervisor")
        {
            Debug.Log("Player Collision");
            SupervisorBubble.SetActive(true);
            NEWSupervisorTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "New Supervisor")
        {
            Debug.Log("Player Leaving");
            SupervisorBubble.SetActive(false);
            NEWSupervisorTalk = false;
        }
    }

    void NicoleSpeech()
    {
        DialoguePanel.SetActive(true);

        if (NEWTalkToSupervisor)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Who the hell are you? Can't you see I'm in the middle of something here?";
                break;

            case 2:
                CharacterText.text = "Emplyee 61375 reporting sir! And Employee... Uh, what's your number?";
                break;

            case 3:
                CharacterText.text = "13003";
                break;

            case 4:
                CharacterText.text = "And Employee 13003! There's a squad in the sewers that's still alive! We were told to report to you for our next assignment!";
                break;

            case 5:
                CharacterText.text = "Right. Your assignment right now is to check on the CEO. The building is crawling with these plant freaks, so be careful.";
                break;

            case 6:
                CharacterText.text = "Well what are you waiting for?! Go?!";
                break;

            case 7:
                DialoguePanel.SetActive(false);
                NEWTalkToSupervisor = false;
                NEWSupervisorTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }
}
