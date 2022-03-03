using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private int activationCooldown = 2;
    private Collider col;

    protected  virtual void Start()
    {
        col = GetComponent<Collider>();
        StartCoroutine((IEnumerator)Activate());
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(activationCooldown);
        col.enabled = true;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            var player = other.GetComponent<Player>();
            Deliver(player);
        }
    }

    protected abstract void Deliver(Player player);
}