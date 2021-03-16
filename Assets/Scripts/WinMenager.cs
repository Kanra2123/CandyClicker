using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenager : MonoBehaviour
{
    public GameObject Win;
    public GameObject Game;
    public GameObject Sure;
    
    public void EndGame()
    {
        FindObjectOfType<AudioMenager>().Play("Click");
        Win.SetActive(true);
        Game.SetActive(false);
    }

    public void PlayAgain()
    {
        FindObjectOfType<AudioMenager>().Play("Click");
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        FindObjectOfType<AudioMenager>().Play("Click");
        Application.Quit();
    }

    public void sure()
    {
        FindObjectOfType<AudioMenager>().Play("Click");
        Sure.SetActive(true);
    }

    public void not()
    {
        FindObjectOfType<AudioMenager>().Play("Click");
        Sure.SetActive(false);
    }

}
