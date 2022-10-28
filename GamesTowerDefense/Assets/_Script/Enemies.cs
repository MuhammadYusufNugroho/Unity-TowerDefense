using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemies : MonoBehaviour
{
    Sco score;

    int _scorePerHit = 10;

    private void Awake()
    {
        score = new Sco();
    }

    private void OnParticleCollision(GameObject other)
    {
        score.increaseScore(_scorePerHit);
        Debug.Log(score._score);

    }
}
