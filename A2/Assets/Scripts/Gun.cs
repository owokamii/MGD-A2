using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private AudioSource pistolGun;
    [SerializeField] private Transform firePoint;
    public GameObject bulletPrefab;
    public float fireForce = 20.0f;

    private void Awake()
    {
        pistolGun = GetComponent<AudioSource>();
        firePoint = GetComponentInChildren<Transform>();
    }

    public void Fire()
    {
        pistolGun.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
    }
}
