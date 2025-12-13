using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThroneRoomDialogue : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject KingBubble;
    public int DialogueNumber;

    //Village Characters
    //public GameObject Aria1;
    public bool TalkToKing;
    public bool KingTalk;

    //Get the player Rigidbody
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialoguePanel.SetActive(false);
        KingBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (TalkToKing)
        {
            DialoguePanel.SetActive(true);
            KingSpeech();
        }
    }
    
    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && KingTalk)
        {
            Debug.Log("Character Talking");
            TalkToKing = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Elf King")
        {
            Debug.Log("Player Collision");
            KingBubble.SetActive(true);
            KingTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Elf King")
        {
            Debug.Log("Player Collision");
            KingBubble.SetActive(false);
            KingTalk = false;
        }
    }

    void KingSpeech()
    {
        DialoguePanel.SetActive(true);

        if (TalkToKing)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch(DialogueNumber)
        {
            case 1:
                CharacterText.text = "So, you're the outsider that I've heard so much about.";
                break;

            case 2:
                CharacterText.text = "Woah. I assume you're the king of this place?";
                break;

            case 3:
                CharacterText.text = "Hold your tongue, scum! The only reason I haven't struck you down is because Lieutenant Aria vouched for you.";
                break;

            case 4:
                CharacterText.text = "Thank you again for your consideration, my king.";
                break;

            case 5:
                CharacterText.text = "And it's because of her that I know you wish to parlay.";
                break;

            case 6:
                CharacterText.text = "Yes, your plantiness.";
                break;

            case 7:
                CharacterText.text = "First of all, you will NEVER call me that again.";
                break;

            case 8:
                CharacterText.text = "Understood. I'm here to request that you call off your invasion. Continuing this fight is worse for everyone.";
                break;

            case 9:
                CharacterText.text = "Oh I beg to differ! If I hadn't launched my attack, our entire home would be ash right now!";
                break;

            case 10:
                CharacterText.text = "That may be true, but now that war has begun, most of your home will be destroyed anyway.";
                break;

            case 11:
                CharacterText.text = "Hmmmm.............";
                break;

            case 12:
                CharacterText.text = "And not to mention that my people possess very advanced technology. Once we break out our REAL weapons, it's only a matter of time.";
                break;

            case 13:
                CharacterText.text = "And with all due respect my king, I concur. With the world the way it is, our forces have been severely depleted.";
                break;

            case 14:
                CharacterText.text = "If we continue this fight, it will be a slaughter. It's best to offer negotiation now, while we still have leverage.";
                break;

            case 15:
                CharacterText.text = "You defy me, Aria?";
                break;

            case 16:
                CharacterText.text = "Please, I beg that you listen to reason, your majesty.";
                break;

            case 17:
                CharacterText.text = "Hmm.... If things are as bad as you say, would you be willing to express your willingness to negotiate yourself, Aria?";
                break;

            case 18:
                CharacterText.text = "If that's what it takes, my king.";
                break;

            case 19:
                CharacterText.text = "Very well. Aria, accompany this one back to his people and tell them your beliefs.";
                break;

            case 20:
                CharacterText.text = "If I don't receive an update from you within the next 24 hours, I will assume you've failed. And the war will continue.";
                break;

            case 21:
                CharacterText.text = "Very well, my king. Let's go.";
                break;

            case 22:
                CharacterText.text = "Oh yes, before I forget, the path up ahead has some of the deadliest fighting I've ever seen. Good luck!";
                break;

            case 23:
                DialoguePanel.SetActive(false);
                TalkToKing = false;
                KingTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;

        }
    }
}
