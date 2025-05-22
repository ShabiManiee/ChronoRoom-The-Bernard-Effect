using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public ParticleSystem goalParticle; // پارتیکل سیستم که باید در Inspector ست بشه
    public int scorePerGoal = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // مطمئن شو توپ تگ "Ball" داره
        {
            // پارتیکل پلی کن
            if (goalParticle != null)
                goalParticle.Play();

            // امتیاز اضافه کن
            ScoreManager.instance.AddScore(scorePerGoal);
        }
    }
}