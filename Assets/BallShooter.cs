using System.Collections;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public Transform target;
    public float shootForce = 3f;
    public float destroyDelay = 6f;

    private Coroutine shootingCoroutine;

    void Start()
    {
        shootingCoroutine = StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (!TimeManager.instance.timeIsFrozen)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

                Vector3 dir = (target.position - spawnPoint.position).normalized;
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.AddForce(dir * shootForce, ForceMode.Impulse);

                StartCoroutine(DestroyBallAfterTime(ball, destroyDelay));
            }

            yield return new WaitForSeconds(Random.Range(1.5f, 3f)); // پرتاب نامنظم
        }
    }

    IEnumerator DestroyBallAfterTime(GameObject ball, float delay)
    {
        float timer = 0f;
        while (timer < delay)
        {
            if (!TimeManager.instance.timeIsFrozen)
            {
                timer += Time.deltaTime;
            }
            yield return null;
        }

        if (ball != null)
        {
            Destroy(ball);
        }
    }
}