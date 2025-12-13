using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class NatureVillageDialogue : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI CharacterText;
    public GameObject CharacterImage;

    public GameObject AriaBubble;
    public GameObject AriaBubble2;
    public GameObject VillagerBubble1;
    public GameObject VillagerBubble2;
    public GameObject VillagerBubble3;
    public GameObject VillagerBubble4;
    public int DialogueNumber;

    //Village Characters
    public GameObject Aria1;
    public bool TalkToAria;
    public bool AriaTalk;

    public bool AriaTalk2;
    public bool TalkToAria2;

    public bool TalkToVillager1;
    public bool Villager1Talk;

    public bool TalkToVillager2;
    public bool Villager2Talk;

    public bool Villager3Talk;
    public bool TalkToVillager3;

    public bool TalkToVillager4;
    public bool Villager4Talk;

    //Assign a Village Gate to get rid of
    public GameObject VillageGate;

    //Get the player Rigidbody
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueNumber = 1;
        AriaSpeech1();
        AriaTalk = true;
        TalkToAria = true;
        rb = GetComponent<Rigidbody2D>();
        AriaBubble.SetActive(false);
        VillagerBubble1.SetActive(false);
        VillagerBubble2.SetActive(false);
        VillagerBubble3.SetActive(false);
        VillagerBubble4.SetActive(false);
        AriaBubble2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (TalkToAria)
        {
            DialoguePanel.SetActive(true);
            AriaSpeech1();
        }

        if (TalkToVillager1)
        {
            DialoguePanel.SetActive(true);
            {
                Villager1Speech();
            }
        }

        if (TalkToVillager2)
        {
            DialoguePanel.SetActive(true);
            {
                Villager2Speech();
            }
        }

        if(TalkToVillager3)
        {
            DialoguePanel.SetActive(true);
            Villager3Speech();
        }

        if(TalkToVillager4)
        {
            DialoguePanel.SetActive(true);
            Villager4Speech();
        }

        if(TalkToAria2)
        {
            DialoguePanel.SetActive(true);
            AriaSpeech2();
        }
    }

    public void Talk(InputAction.CallbackContext context)
    {
        if (context.performed && AriaTalk)
        {
            Debug.Log("Character Talking");
            TalkToAria = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && Villager1Talk)
        {
            Debug.Log("Character Talking");
            TalkToVillager1 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && Villager2Talk)
        {
            Debug.Log("Character Talking");
            TalkToVillager2 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && Villager3Talk)
        {
            Debug.Log("Character Talking");
            TalkToVillager3 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && Villager4Talk)
        {
            Debug.Log("Character Talking");
            TalkToVillager4 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

        if (context.performed && AriaTalk2)
        {
            Debug.Log("Character Talking");
            TalkToAria2 = true;
            DialogueNumber++;
            //DialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Aria 1")
        {
            Debug.Log("Player Collision");
            AriaBubble.SetActive(true);
            AriaTalk = true;
        }

        if (collision.gameObject.name == "Aria 2")
        {
            Debug.Log("Player Collision");
            AriaBubble2.SetActive(true);
            AriaTalk2 = true;
        }

        if (collision.gameObject.name == "Villager 1")
        {
            Debug.Log("Player Collision");
            VillagerBubble1.SetActive(true);
            Villager1Talk = true;
        }

        if (collision.gameObject.name == "Villager 2")
        {
            Debug.Log("Player Collision");
            VillagerBubble2.SetActive(true);
            Villager2Talk = true;
        }

        if (collision.gameObject.name == "Villager 3")
        {
            Debug.Log("Player Collision");
            VillagerBubble3.SetActive(true);
            Villager3Talk = true;
        }

        if (collision.gameObject.name == "Villager 4")
        {
            Debug.Log("Player Collision");
            VillagerBubble4.SetActive(true);
            Villager4Talk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Aria 1")
        {
            Debug.Log("Player Leaving");
            AriaBubble.SetActive(false);
            AriaTalk = false;
        }

        if (collision.gameObject.name == "Aria 2")
        {
            Debug.Log("Player Collision");
            AriaBubble2.SetActive(false);
            AriaTalk2 = false;
        }

        if (collision.gameObject.name == "Villager 1")
        {
            Debug.Log("Player Collision");
            VillagerBubble1.SetActive(false);
            Villager1Talk = false;
        }

        if (collision.gameObject.name == "Villager 2")
        {
            Debug.Log("Player Collision");
            VillagerBubble2.SetActive(false);
            Villager2Talk = false;
        }

        if (collision.gameObject.name == "Villager 3")
        {
            Debug.Log("Player Collision");
            VillagerBubble3.SetActive(false);
            Villager3Talk = false;
        }

        if (collision.gameObject.name == "Villager 4")
        {
            Debug.Log("Player Collision");
            VillagerBubble4.SetActive(false);
            Villager4Talk = true;
        }
    }

    void AriaSpeech1()
    {
        DialoguePanel.SetActive(true);

        if (TalkToAria)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Huh? Who are you?";
                break;

            case 2:
                CharacterText.text = "Well you see, I'm...";
                break;

            case 3:
                CharacterText.text = "Oh no. You're one of those people from outside the forest, right? Please, just... just leave. I can't do this anymore.";
                break;

            case 4:
                CharacterText.text = "Wait! Please! I'm not here to hurt anyone! I was sent to try and resolve this whole thing peacefully.";
                break;

            case 5:
                CharacterText.text = ".....";
                break;

            case 6:
                CharacterText.text = "How can I trust you?";
                break;

            case 7:
                CharacterText.text = "Well, I don't really have anything to earn your trust, but I will say this. When it comes to the New Day Corporation, I'm just a grunt worker.";
                break;

            case 8:
                CharacterText.text = "I didn't order this attack, and the Executives who did don't care much more about me than they do about you.";
                break;

            case 9:
                CharacterText.text = "Hmmm....";
                break;

            case 10:
                CharacterText.text = "Please. I can tell we're both looking for a similar way out of this mess.";
                break;

            case 11:
                CharacterText.text = "Very well. But we can't talk here. Come to my house. It's directly above us.";
                break;

            case 12:
                DialoguePanel.SetActive(false);
                Aria1.SetActive(false);
                TalkToAria = false;
                AriaTalk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void Villager1Speech()
    {
        DialoguePanel.SetActive(true);

        if (TalkToVillager1)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "Why the hell are you here? Do you seriously think you're welcome in our village?";
                break;

            case 2:
                CharacterText.text = "I mean, kind of? Your entrance guard let me in. And invited me invited to her house.";
                break;

            case 3:
                CharacterText.text = "Typical Aria. She trusts way too easily.";
                break;

            case 4:
                CharacterText.text = "If I were on guard duty today, I'd have spit-roasted you by now.";
                break;

            case 5:
                DialoguePanel.SetActive(false);
                TalkToVillager1 = false;
                Villager1Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void Villager2Speech()
    {
        DialoguePanel.SetActive(true);

        if(TalkToVillager2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "This is my house.";
                break;

            case 2:
                CharacterText.text = "...";
                break;

            case 3:
                CharacterText.text = "What did you think you could just come inside? GET OUT!";
                break;

            case 4:
                CharacterText.text = "Sheesh, some people...";
                break;

            case 5:
                DialoguePanel.SetActive(false);
                TalkToVillager2 = false;
                Villager2Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void Villager3Speech()
    {
        DialoguePanel.SetActive(true);

        if(TalkToVillager3)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch(DialogueNumber)
        {
            case 1:
                CharacterText.text = "This way to the upper layer.";
                break;

            case 2:
                CharacterText.text = "Take care of your business and leave.";
                break;

            case 3:
                CharacterText.text = "We aren't very welcoming of outsiders right now.";
                break;

            case 4:
                CharacterText.text = "Why is that?";
                break;

            case 5:
                CharacterText.text = "Do I really need to explain?";
                break;

            case 6:
                CharacterText.text = "Fair enough. Hope I can change your mind.";
                break;

            case 7:
                CharacterText.text = "Screw off.";
                break;

            case 8:
                DialoguePanel.SetActive(false);
                TalkToVillager3 = false;
                Villager3Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void Villager4Speech()
    {
        DialoguePanel.SetActive(true);

        if(TalkToVillager4)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch (DialogueNumber)
        {
            case 1:
                CharacterText.text = "This hole takes you out of the village and towards the lower layers of the forest.";
                break;

            case 2:
                CharacterText.text = "Be careful. There's a lot of fighting going on down there. There's so much carnage, no one can tell friend from foe.";
                break;

            case 3:
                CharacterText.text = "Or don't be careful. I really couldn't care less.";
                break;

            case 4:
                DialoguePanel.SetActive(false);
                TalkToVillager4 = false;
                Villager4Talk = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }

    void AriaSpeech2()
    {
        DialoguePanel.SetActive(true);

        if(TalkToAria2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        switch(DialogueNumber)
        {
            case 1:
                CharacterText.text = "Ah, good. You made it.";
                break;

            case 2:
                CharacterText.text = "It may have already been mentioned by some of my friends, but my name is Aria.";
                break;

            case 3:
                CharacterText.text = "You're lucky I was on guard duty. If it was anyone else, you'd probably be dead by now.";
                break;

            case 4:
                CharacterText.text = "Yeah, I gathered that. You really-";
                break;

            case 5:
                CharacterText.text = "HOWEVER!";
                break;

            case 6:
                CharacterText.text = "This doesn't mean I trust you. I'm simply willing to hear you out.";
                break;

            case 7:
                CharacterText.text = "Fair enough. I'm trying to find a way to resolve this whole thing peacefully.";
                break;

            case 8:
                CharacterText.text = "Just killing each other clearly isn't going to solve anything.";
                break;

            case 9:
                CharacterText.text = "You speak the truth. But how do I know your true intentions match your words?";
                break;

            case 10:
                CharacterText.text = "I guess you'll just have to trust me.";
                break;

            case 11:
                CharacterText.text = "As I said, I don't trust you. But right now, you might be the only hope I have.";
                break;

            case 12:
                CharacterText.text = "What do you mean?";
                break;

            case 13:
                CharacterText.text = "My associates aren't simply defending our home. They're out for your people's blood.";
                break;

            case 14:
                CharacterText.text = "!!!";
                break;

            case 15:
                CharacterText.text = "We've had countless acres of our home torn down, and now that our last stronghold is threatened, they believe that our only option is...";
                break;

            case 16:
                CharacterText.text = "'Getting to the root of the problem.'";
                break;

            case 17:
                CharacterText.text = "Killing everyone?";
                break;

            case 18:
                CharacterText.text = "And you don't believe that?";
                break;

            case 19:
                CharacterText.text = "Don't mistake my mercy for kindness. I still want your employers to pay DEARLY for their actions.";
                break;

            case 20:
                CharacterText.text = "However, I'm a firm believer in a fair justice system. I'm aware that those in positions like yours have little choice in their actions.";
                break;

            case 21:
                CharacterText.text = "In addition, if you pay your price in cold blood, we'll be no better than you.";
                break;

            case 22:
                CharacterText.text = "And not to mention the horrific example that we'll be setting for future generations.";
                break;

            case 23:
                CharacterText.text = "I see. Thank you for your willingness to hear me out";
                break;

            case 24:
                CharacterText.text = "....";
                break;

            case 25:
                CharacterText.text = "On the other side of the village, you'll find a pit. The gate should be open now.";
                break;

            case 26:
                CharacterText.text = "This pit will take you to the lower layers of the forest.";
                break;

            case 27:
                CharacterText.text = "Keep making your way down until you reach the lowest layer, the roots of the forest trees.";
                break;

            case 28:
                CharacterText.text = "There you'll find our king.";
                break;

            case 29:
                CharacterText.text = "He ordered this attack himself. And as such, he's the only one who can call it off.";
                break;

            case 30:
                CharacterText.text = "He's a very stubborn man, so negotiating with him won't be easy. But right now, it's the only option we have.";
                break;

            case 31:
                CharacterText.text = "I see. Thank you.";
                break;

            case 32:
                CharacterText.text = "Keep your thanks until the job is done. There are a thousand ways you can die between now and then.";
                break;

            case 33:
                CharacterText.text = "Right....";
                break;

            case 34:
                CharacterText.text = "Go now. Before anyone notices.";
                break;

            case 35:
                VillageGate.SetActive(false);
                DialoguePanel.SetActive(false);
                TalkToAria2 = false;
                AriaTalk2 = false;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //SC.Nicole1Talk = false;
                DialogueNumber = 0;
                break;
        }
    }
}
