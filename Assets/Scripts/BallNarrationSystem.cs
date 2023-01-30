using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallNarrationSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject _ballSubject;

    [SerializeField] Score score;

    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;

    [SerializeField] GameObject gameOverWindow;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnNotify(BallActions actions)
    {
        if(actions == BallActions.CollisionWithBlocks)
        {
            score.IncreaseScore();
            score.UpdateBestScore();

            if (PlayerPrefs.GetInt("Muted") == 0)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
        else if(actions == BallActions.Drop)
        {
            gameOverWindow.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _ballSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _ballSubject.RemoveObserver(this);
    }
}
