using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 10;
    private Rigidbody2D _rb2d;
    private float horizontalInput;
    private float verticalInput;

    private Animator animator;
    private static readonly int MoveXProperty = Animator.StringToHash("Move X");
    private static readonly int MoveYProperty = Animator.StringToHash("Move Y");

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //I know that x isn't vertical but this seems to work and I don't know what I did wrong in the inspector 
        animator.SetFloat(MoveXProperty, verticalInput);
        animator.SetFloat(MoveYProperty, horizontalInput);
    }

    private void FixedUpdate()
    {
        Vector2 position = _rb2d.position;
        position.x = position.x + horizontalInput * moveSpeed * Time.deltaTime;
        position.y += verticalInput * moveSpeed * Time.deltaTime;

        _rb2d.MovePosition(position);
    }

    private void RaycastForConversation()
    {
        //todo - do this directionally. Maybe all directions rather than facing directions? good lazy coding
        RaycastHit2D hit = Physics2D.Raycast(_rb2d.position + Vector2.up * 0.2f, Vector2.left, 1.5f,
            LayerMask.GetMask(("NPC")));
        if (hit.collider is not null)
        {
            hit.collider.GetComponent<Squirrel>()?.ActivateDialog();
            hit.collider.GetComponent<PondFish>()?.ActivateDialog();
        }
    }

    public void UpdateAxes(float verticalInput, float horizontalInput)
    {
        this.verticalInput = verticalInput;
        this.horizontalInput = horizontalInput;
    }

    public void ONActionPressed()
    {
        RaycastForConversation();
    }
}