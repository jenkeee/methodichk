using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    public bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    /// //////////////////////////////// для счетчика
    public GameObject ScoreText;
    int Score =0;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }
    public void Count()
    {
        Score ++;
        ScoreText.GetComponent<Text>().text = "закидано какахами: " + Score.ToString() + "/ 4.";
        //if (Score >= 4) ;
            //gameEnding.EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (Score >= 4) m_IsPlayerAtExit = true;
        else if (!m_IsPlayerCaught)
        {
            if (player.transform.position.y < -30) m_IsPlayerCaught = true;
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

   public void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
            
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                if (SceneManager.GetActiveScene().buildIndex == 1) SceneManager.LoadScene(0);
                else
                SceneManager.LoadScene(0);
            }
        }
    }
}
