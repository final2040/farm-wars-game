using TMPro;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 positionOffset;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + positionOffset;
        }
    }

    public void Show(GameObject target, int damage)
    {
        this.target = target;
        text.text = damage.ToString();
        animator.SetTrigger("show_trigger");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
