using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float MaxHealth = 10f;
    [SerializeField] public TextMeshProUGUI healthBar;

    public float currentHealth;

    private void Awake()
    {
        currentHealth = MaxHealth;
        healthBar.text = "HP: " + currentHealth + "/" + MaxHealth;
    }

    private void Update()
    {
        healthBar.text = "HP: " + currentHealth + "/" + MaxHealth;

        if (currentHealth == 0)
        {
            //SceneManager.SetActiveScene(); Place Gameover Screen here
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Thorns"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
