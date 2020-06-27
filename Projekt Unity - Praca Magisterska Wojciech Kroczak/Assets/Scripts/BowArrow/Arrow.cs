using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 150.0f;
    public Transform tip = null;

    private Rigidbody rigid = null;
    private bool isStopped = true;
    private Vector3 lastPosition = Vector3.zero;

    public AudioSource _audioSource;
    private string volumeValue = "Volume";
    private float volume;

    public GameObject collider;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();      
    }

    private void FixedUpdate()
    {
        if (isStopped)
        {
            return;
        }

        rigid.MoveRotation(Quaternion.LookRotation(rigid.velocity, transform.up));

        if (Physics.Linecast(lastPosition, tip.position))
        {
            Stop();
        }
        lastPosition = tip.position;
    }

    private void Stop()
    {
        Sound();
        CapsuleCollider caps = collider.GetComponent<CapsuleCollider>();
        caps.enabled = true;
        isStopped = true;
        rigid.isKinematic = true;
        rigid.useGravity = false;   
    }

    private void OnCollisionEnter(Collision collision)
    {
        CapsuleCollider caps = collider.GetComponent<CapsuleCollider>();
        caps.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        CapsuleCollider caps = collider.GetComponent<CapsuleCollider>();
        caps.enabled = false;
    }

    public void Fire(float pullValue)
    {
        isStopped = false;
        transform.parent = null;
        rigid.isKinematic = false;
        rigid.useGravity = true;
        rigid.AddForce(transform.forward * (pullValue * speed));
        Destroy(gameObject, 55.0f);
    }

    private void Sound()
    {
        volume = PlayerPrefs.GetFloat(volumeValue);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = volume;
        _audioSource.Play();
    }
}
