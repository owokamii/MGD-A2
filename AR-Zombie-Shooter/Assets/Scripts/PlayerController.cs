using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodSplatter;
    public GameObject GameOverScreen;
    public float deathTime;
    public static bool PlayerIsDead = false;

    private void Awake()
    {
        bloodSplatter = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            bloodSplatter.Play();
            StartCoroutine(PlayerDies(deathTime));
        }
    }

    private IEnumerator PlayerDies(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);

        PlayerIsDead = true;
        GameOverScreen.SetActive(true);
    }
}
