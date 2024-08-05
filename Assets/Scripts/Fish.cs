using Unity.Mathematics;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 5f; // Uygun bir baþlangýç deðeri verdim
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedGround;
    public GameMenager gameMenager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public EngelSpawner engelSpawner;
    [SerializeField] private AudioSource swim,hit,point;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0; // Baþlangýçta yer çekimini 0 yapýyoruz
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameMenager.gameOver == false)
        {
            swim.Play();
            if (GameMenager.gameStarted == false)
            {

                _rb.gravityScale = 4f; // Oyuna baþlarken yer çekimini normal yapýyoruz
                _rb.linearVelocity = Vector2.zero;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _speed);
                engelSpawner.InstantiateObstacle();
                gameMenager.GameHasStarted();
            }
            else
            {
                _rb.linearVelocity = Vector2.zero;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _speed);
            }
        }
    }

    void FishRotation()
    {
        if (_rb.linearVelocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (_rb.linearVelocity.y < -1.2f)
        {
            if (angle > minAngle)
            {
                angle -= 2;
            }
        }

        if (!touchedGround)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("engel"))
        {
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("sütun") && GameMenager.gameOver == false)
        {
            FishDiedEffect();
            gameMenager.GameOver();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alt"))
        {
            if (GameMenager.gameOver == false)
            {
                FishDiedEffect();
                gameMenager.GameOver();
                GameOver();
                
            }
            else
            {
                GameOver();
                
            }
        }
    }

    void FishDiedEffect()
    {
        hit.Play();
    }
    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
