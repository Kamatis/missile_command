using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    public float power;
    public Vector3 initialScale;

    public void Start()
    {
        transform.localScale = initialScale;
        Expand();
    }

    private void Expand()
    {
        transform.DOScale(initialScale * power, 2f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            ScoreController.Instance.CurrentPoints += enemy.point;
            Destroy(collision.gameObject);
        }
    }
}
