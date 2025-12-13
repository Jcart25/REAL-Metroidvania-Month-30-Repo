using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondSewerDialogue : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject NicoleBubble;
    public GameObject NicoleBubble2;
    public int DialogueNumber;

    public bool TalkToNicole;
    public bool TalkToNicole2;

    public bool NicoleTalk;
    public bool NicoleTalk2;

    //Get the player Rigidbody
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueNumber = 0;
        DialoguePanel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        NicoleBubble.SetActive(false);
        NicoleBubble2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (TalkToNicole)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech();
        }
        
        if(TalkToNicole2)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech2();
        }
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && NicoleTalk)
        {
            Debug.Log("Character Talking");
            TalkToNicole = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && NicoleTalk2)
        {
            Debug.Log("Character Talking");
            TalkToNicole2 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Nicole")
        {
            Debug.Log("Player Collision");
            NicoleBubble.SetActive(true);
            NicoleTalk = true;
        }

        if (collision.gameObject.name == "Nicole 2")
        {
            Debug.Log("Player Collision");
            NicoleBubble2.SetActive(true);
            NicoleTalk2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Nicole")
        {
            Debug.Log("Player Leaving");
            NicoleBubble.SetActive(false);
            NicoleTalk = false;
        }

        if (collision.gameObject.name == "Nicole 2")
        {
            Debug.Log("Player Collision");
            NicoleBubble2.SetActive(false);
            NicoleTalk2 = false;
        }
    }

    void NicoleSpeech()
    {
        DialoguePanel.SetActive(true);

        if (TalkToNicole)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Yeah, the supervisor's kind of an asshole.";
                break;

            case 2:
                CharacterText.text = "You could probably tell back there, but the two of us don't exactly see eye to eye.";
                break;

            case 3:
                CharacterText.text = "And talk about by the book! She's continuing with the assignment even though the world is literally telling us to stop!";
                break;

            case 4:
                CharacterText.text = "*Sigh*";
                break;

            case 5:
                CharacterText.text = "Well, it's either the plants kill us or she does. So I guess for now we need to keep moving.";
                break;

            case 6:
                CharacterText.text = "Be careful, things are probably going to get a lot more dangerous from this point on.";
                break;

            case 7:
                DialoguePanel.SetActive(false);
                TalkToNicole = false;
                NicoleTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void NicoleSpeech2()
    {
        DialoguePanel.SetActive(true);

        if (TalkToNicole2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Alright. Not much further now. I think I can see daylight just above us.";
                break;

            case 2:
                CharacterText.text = "I don't know about you, but I'm DEFINITELY putting in a request for some vacation time after this.";
                break;

            case 3:
                CharacterText.text = "...";
                break;

            case 4:
                CharacterText.text = "Bad joke?";
                break;

            case 5:
                DialoguePanel.SetActive(false);
                TalkToNicole2 = false;
                NicoleTalk2 = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }
}

