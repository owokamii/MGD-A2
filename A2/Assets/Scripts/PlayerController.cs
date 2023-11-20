using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem bloodSplatter;
    public GameObject GameOverScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            bloodSplatter.Play();
            GameOverScreen.SetActive(true);
        }
    }
}
