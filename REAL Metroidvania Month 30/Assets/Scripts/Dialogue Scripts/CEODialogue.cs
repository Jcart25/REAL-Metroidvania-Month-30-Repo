using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class CEODialogue : MonoBehaviour
{

    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject SupervisorBubble;
    public GameObject BodyguardBubble;
    public int DialogueNumber;

    //Office Characters
    public bool TalkToCEO;
    public bool CEOTalk;

    public bool TalkToBodyguard;
    public bool BodyguardTalk;

    //Get the player Rigidbody
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueNumber = 0;
        DialoguePanel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        SupervisorBubble.SetActive(false);
        BodyguardBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (TalkToCEO)
        {
            DialoguePanel.SetActive(true);
            CEOSpeech();
        }

        if (TalkToBodyguard)
        {
            DialoguePanel.SetActive(true);
            {
                BodyguardSpeech();
            }
        }
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && CEOTalk)
        {
            Debug.Log("Character Talking");
            TalkToCEO = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && BodyguardTalk)
        {
            Debug.Log("Character Talking");
            TalkToBodyguard = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "CEO")
        {
            Debug.Log("Player Collision");
            SupervisorBubble.SetActive(true);
            CEOTalk = true;
        }

        if (collision.gameObject.name == "CEO Bodyguard")
        {
            Debug.Log("Player Collision");
            BodyguardBubble.SetActive(true);
            BodyguardTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "CEO")
        {
            Debug.Log("Player Leaving");
            SupervisorBubble.SetActive(false);
            CEOTalk = false;
        }

        if (collision.gameObject.name == "CEO Bodyguard")
        {
            Debug.Log("Player Collision");
            BodyguardBubble.SetActive(false);
            BodyguardTalk = false;
        }
    }
    
    void BodyguardSpeech()
    {
        DialoguePanel.SetActive(true);

        if (TalkToBodyguard)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Hey hold it right there!";
                break;

            case 2:
                CharacterText.text = "Oh, you're employees. What do you want?";
                break;

            case 3:
                CharacterText.text = "We're here to check on the CEO. Is he alright?";
                break;

            case 4:
                CharacterText.text = "Yeah he's fine. And he's got enough shit to deal with. So out you go.";
                break;

            case 5:
                CharacterText.text = "Wait! There are hundreds of employees who are running around in chaos right now! We need to know what we're going to do next!";
                break;

            case 6:
                DialoguePanel.SetActive(false);
                TalkToBodyguard = false;
                BodyguardTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void CEOSpeech()
    {
        DialoguePanel.SetActive(true);

        if (TalkToCEO)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "So you've made it all the way here from the sewers? Color me impressed.";
                break;

            case 2:
                CharacterText.text = "We were assigned to check your condition, sir.";
                break;

            case 3:
                CharacterText.text = "Well as you can see, I'm fine. Do you have anything else to say?";
                break;

            case 4:
                CharacterText.text = "Well, what's our next move?";
                break;

            case 5:
                CharacterText.text = "What do you think? We're proceeding with Operation Full Measure!";
                break;

            case 6:
                CharacterText.text = "Urgh... Permission to speak freely, sir?";
                break;

            case 7:
                CharacterText.text = "Hm, granted.";
                break;

            case 8:
                CharacterText.text = "Sir, do you really think that this is a good idea? It's pretty clear that those who live in the forest don't want it to be torn down.";
                break;

            case 9:
                CharacterText.text = "Yes it is. But I don't know if you've noticed, 61375, but our city is dying as well. More and more people are living in the streets. I'm trying to give them a home!";
                break;

            case 10:
                CharacterText.text = "But sir, look at what's happening! Even if that's the case, we don't have the resources to keep this up!";
                break;

            case 11:
                CharacterText.text = "Hm... Perhaps you're right. It would be a tremendous waste of resources if we continue with this fighting.";
                break;

            case 12:
                CharacterText.text = "Alright. 013003, you have a new assignment. I'm sending you into the forest as my laisson. See if you can find a way to resolve this peacefully.";
                break;

            case 13:
                CharacterText.text = "And me, sir?";
                break;

            case 14:
                CharacterText.text = "You're staying here. Based on how you spoke to me, I don't trust you not to betray me.";
                break;

            case 15:
                CharacterText.text = "But sir, I can be-";
                break;

            case 16:
                CharacterText.text = "My decision is FINAL. You both are dismissed.";
                break;

            case 17:
                CharacterText.text = "Well shit. I guess this is goodbye. Do what you can. I'm sure anything is better than this.";
                break;

            case 18:
                DialoguePanel.SetActive(false);
                TalkToCEO = false;
                CEOTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }
}
