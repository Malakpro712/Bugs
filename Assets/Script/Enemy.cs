using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    private float speed = 0.01f;
    public Vector3[] positions;
    private int indexPosition;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * horizontal);
        //sprite.flipX = horizontal < 0;

        transform.position = Vector3.MoveTowards(transform.position, positions[indexPosition], speed);

        if (transform.position == positions[indexPosition])
        {
            if (indexPosition < positions.Length - 1)
            {
                indexPosition++;
                sprite.flipX = false;
            }else
            {
                indexPosition = 0;
                sprite.flipX = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
