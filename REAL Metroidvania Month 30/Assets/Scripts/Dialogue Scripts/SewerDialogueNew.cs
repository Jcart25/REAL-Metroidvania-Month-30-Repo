using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class SewerDialogueNew : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject NicoleBubble1;
    public GameObject NicoleBubble2;
    public GameObject NicoleBubble3;

    public int DialogueNumber;
    public bool TalkToNicole = false;
    public bool TalkToNicole2 = false;
    public bool TalkToNicole3 = false;

    public bool Nicole1Talk = false;
    public bool Nicole2Talk = false;
    public bool Nicole3Talk = false;


    //Get the player Rigidbody
    public Rigidbody2D rb;

    //public SewerCollision SC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueNumber = 0;
        DialoguePanel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        NicoleBubble1.SetActive(false);
        NicoleBubble2.SetActive(false);
        NicoleBubble3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (InputAction.GetKeyDown(KeyCode.Space) && SC.Nicole1Talk)
        {
            DialoguePanel.SetActive(true);
            Nicole1Talking = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && SC.Nicole2Talk)
        {
            DialoguePanel.SetActive(true);
            Nicole2Talking = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && SC.Nicole3Talk)
        {
            DialoguePanel.SetActive(true);
            Nicole3Talking = true;
        }
        

        if(Nicole1Talk)
        {
            NicoleSpeech1();
        }
        */
        //Talk();
    }

    private void FixedUpdate()
    {
        if (TalkToNicole)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech1();
        }

        if (TalkToNicole2)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech2();
        }

        if (TalkToNicole3)
        {
            DialoguePanel.SetActive(true);
            NicoleSpeech3();
        }
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && Nicole1Talk)
        {
            Debug.Log("Character Talking");
            TalkToNicole = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && Nicole2Talk)
        {
            Debug.Log("Character Talking");
            TalkToNicole2 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && Nicole3Talk)
        {
            Debug.Log("Character Talking");
            TalkToNicole3 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Nicole 1")
        {
            Debug.Log("Player Collision");
            NicoleBubble1.SetActive(true);
            Nicole1Talk = true;
        }

        if (collision.gameObject.name == "Nicole 2")
        {
            Debug.Log("Player Collision");
            NicoleBubble2.SetActive(true);
            Nicole2Talk = true;
        }

        if (collision.gameObject.name == "Nicole 3")
        {
            Debug.Log("Player Collision");
            NicoleBubble3.SetActive(true);
            Nicole3Talk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Nicole 1")
        {
            Debug.Log("Player Leaving");
            NicoleBubble1.SetActive(false);
            Nicole1Talk = false;
        }

        if (collision.gameObject.name == "Nicole 2")
        {
            Debug.Log("Player Collision");
            NicoleBubble2.SetActive(false);
            Nicole2Talk = false;
        }

        if (collision.gameObject.name == "Nicole 3")
        {
            Debug.Log("Player Collision");
            NicoleBubble3.SetActive(true);
            Nicole3Talk = false;
        }
    }

    void NicoleSpeech1()
    {
        DialoguePanel.SetActive(true);

        if (TalkToNicole)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Hey, are you alright? That was a rough fall.";
                break;

            case 2:
                CharacterText.text = "Ugh, what happened?";
                break;

            case 3:
                CharacterText.text = "My guess is that you didn't land quite right and hit your head when you fell.";
                break;

            case 4:
                CharacterText.text = "No! I mean in general!";
                break;

            case 5:
                CharacterText.text = "Oh. Your guess is as good as mine, pal. I don't think anyone knows what the hell we just witnessed.";
                break;

            case 6:
                CharacterText.text = "So... We're lost?";
                break;

            case 7:
                CharacterText.text = "Totally. But the remains of our squad are gathered up ahead. Maybe we can figure SOMETHING out.";
                break;

            case 8:
                CharacterText.text = "Yeah... Okay.";
                break;

            case 9:
                CharacterText.text = "Name's Nicole by the way. I know they don't like us using anything but our ID numbers,";
                break;

            case 10:
                CharacterText.text = "But I think we're a little beyond company protocol at this point.";
                break;

            case 11:
                CharacterText.text = "Then you can call me Ray.";
                break;

            case 12:
                CharacterText.text = "Well then Ray, follow me. Our squad, or what's left of it, is just up ahead.";
                break;

            case 13:
                DialoguePanel.SetActive(false);
                TalkToNicole = false;
                Nicole1Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }

    }

    void NicoleSpeech2()
    {
        if (TalkToNicole2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Wow, when was the last time that you saw axtual plants in this city?";
                break;

            case 2:
                CharacterText.text = "Well, they may look pretty, but you do not wanna fall in there.";
                break;

            case 3:
                CharacterText.text = "But there's nothing a good jump can't fix! Press the space bar!";
                break;

            case 4:
                DialoguePanel.SetActive(false);
                TalkToNicole2 = false;
                Nicole2Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void NicoleSpeech3()
    {
        if (TalkToNicole3)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Alight, just a little bit further.";
                break;

            case 2:
                CharacterText.text = "But be careful, some of these plants have some weird effects.";
                break;

            case 3:
                CharacterText.text = "This one right here is really bouncy, which could come in handy if you're in a pinch.";
                break;

            case 4:
                CharacterText.text = "But the other ones ahead? Not so much.";
                break;

            case 5:
                CharacterText.text = "If you catch a whiff of those spores they shoot, it's lights out for you!";
                break;

            case 6:
                CharacterText.text = "So yeah, best to avoid those.";
                break;

            case 7:
                DialoguePanel.SetActive(false);
                TalkToNicole3 = false;
                Nicole3Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }
}

