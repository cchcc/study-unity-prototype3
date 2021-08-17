using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public Transform startingPoint;
    public float lerpSpeed;

    private PlayerController playerController;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        
        playerController.gameOver = true;
        StartCoroutine(PlayIntro());
    }
    
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerController.transform.position;
        Vector3 endPos = Vector3.zero;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerController.GetComponent<Animator>().SetFloat("Booster_f",
            0.5f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerController.transform.position = Vector3.Lerp(startPos, endPos,
                fractionOfJourney);
            yield return null;
        }
        playerController.GetComponent<Animator>().SetFloat("Booster_f",
            1.0f);
        playerController.gameOver = false;
    }
}