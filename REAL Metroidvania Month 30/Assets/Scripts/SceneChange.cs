using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.name == "Sewer 1 Exit")
        {
            SceneManager.LoadScene(sceneName: "Employee Hideout");
        }

        if (collision.gameObject.name == "Hideout Exit")
        {
            SceneManager.LoadScene(sceneName: "SecondSewer");
        }

        if (collision.gameObject.name == "Surface Entrance")
        {
            SceneManager.LoadScene(sceneName: "SampleScene");
        }

        if (collision.gameObject.name == "Corporation Door")
        {
            SceneManager.LoadScene(sceneName: "Side Building Interior");
        }

        if (collision.gameObject.name == "CEO Door")
        {
            SceneManager.LoadScene(sceneName: "CEO Office");
        }

        if (collision.gameObject.name == "CEO Office Exit")
        {
            SceneManager.LoadScene(sceneName: "Root Bridge");
        }

        if (collision.gameObject.name == "Village Entrance")
        {
            SceneManager.LoadScene(sceneName: "Nature Village");
        }

        if (collision.gameObject.name == "Village Exit")
        {
            SceneManager.LoadScene(sceneName: "Tree 1");
        }

        if (collision.gameObject.name == "Roots Entrance")
        {
            SceneManager.LoadScene(sceneName: "Underground Roots");
        }

        if (collision.gameObject.name == "Throne Room Entrance")
        {
            SceneManager.LoadScene(sceneName: "Throne Room");
        }

        if (collision.gameObject.name == "Throne Room Exit")
        {
            SceneManager.LoadScene(sceneName: "Final Area");
        }
    }
}
