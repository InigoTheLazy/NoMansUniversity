using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private Animator animator;
    private static bool playerExists;
    public string startPoint;
    float lockPos = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

		if (!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(this.transform.gameObject);
		}
		else
		    Destroy(this.gameObject);

    }

    void Update()
    {
        GetInput();
        Move();
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "BattleScene")
            this.gameObject.SetActive(false);
        if (scene.name == "BattleScene2")
            this.gameObject.SetActive(false);
        if (scene.name == "BattleScene3")
            this.gameObject.SetActive(false);
    }
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(direction.x != 0 || direction.y != 0)
            AnimateMovement(direction);
        else
            animator.SetLayerWeight(1, 0);
        
    }
    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector2.up;
        if (Input.GetKey(KeyCode.A))
            direction += Vector2.left;
        if (Input.GetKey(KeyCode.S))
            direction += Vector2.down;
        if (Input.GetKey(KeyCode.D))
            direction += Vector2.right;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Door")
            SceneManager.LoadScene("BattleScene");

    }
    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    void Footstep()
    {
        if (audio && !audio.isPlaying)
            audio.PlayOneShot(footstepSound);
    }
}
