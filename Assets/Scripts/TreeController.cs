using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class TreeController : MonoBehaviour
{
    private float timer;
    private int seconds;
    public GameObject alert;
    private bool alerted = false;
    private bool isFishing = false;
    private Manager manager;

    [SerializeField] private int moveSpeed = 10;
    private Rigidbody2D _rb2d;
    private float horizontalInput;
    private float verticalInput;
    public TextMeshProUGUI output; 

    private Animator animator;
    private static readonly int MoveXProperty = Animator.StringToHash("Move X");
    private static readonly int MoveYProperty = Animator.StringToHash("Move Y");

    Vector2 viewDir = Vector2.zero;

    [SerializeField] private ConversationManager _conversationManager;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        seconds = 0;
        GameObject empty = GameObject.Find("Manager");
        manager = empty.GetComponent<Manager>();
        Debug.Log(manager);
    }

    // Update is called once per frame
    void Update()
    {
        //I know that x isn't vertical but this seems to work and I don't know what I did wrong in the inspector 
        animator.SetFloat(MoveXProperty, verticalInput);
        animator.SetFloat(MoveYProperty, horizontalInput);

        timer += Time.deltaTime;
        float sec = timer % 60;
        seconds = (int) sec;

        if (alerted)
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("Loot");
                //Randomise loot 0 = boot, 1 = tire, 2 = tin can. 
                int rand = UnityEngine.Random.Range(0, 3);
                if (rand == 0)
                {
                    if (manager.boot == false)
                    {
                        manager.boot = true;
                        output.text = "Boot caught";
                    }
                    else
                    {
                        output.text = "Boot already in inventory";
                    }
                }

                if (rand == 1)
                {
                    if (manager.tire == false)
                    {
                        manager.tire = true;
                        output.text = "Tire caught";
                    }
                    else
                    {
                        output.text ="Tire already in inventory";
                    }
                }

                if (rand == 2)
                {
                    if (manager.tinCan == false)
                    {
                        manager.tinCan = true;
                        output.text = "Tin can caught";
                    }
                    else
                    {
                        output.text = "Tin can already in inventory";
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("F Pressed");
            GoFish();
        }

        if (isFishing)
        {
            if (seconds == 3)
            {
                alert.SetActive(true);
                alerted = true;
            }

            if (seconds == 5)
            {
                alert.SetActive(false);
                alerted = false;
                isFishing = false;
                output.text = " ";
            }
        }
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
        RaycastHit2D hit = Physics2D.Raycast(_rb2d.position + Vector2.up * 0.2f, viewDir, 1.5f,
            LayerMask.GetMask(("NPC")));
        if (hit.collider is not null)
        {
            Debug.Log($"hit is {hit}");
            //todo - sort all tags, also make this less janky
            if (hit.collider.gameObject.CompareTag("Squirrel")
                || hit.collider.gameObject.CompareTag("Cave")
                || hit.collider.gameObject.CompareTag("Bird")
                || hit.collider.gameObject.CompareTag("Turtle"))
            {
               
                _conversationManager.playNextConversation();
            }

            hit.collider.GetComponent<PondFish>()?.ActivateDialog();
        }
    }

    public void UpdateAxes(float verticalInput, float horizontalInput)
    {
        this.verticalInput = verticalInput;
        this.horizontalInput = horizontalInput;
        if (verticalInput == 0 && horizontalInput == 0) return;
        viewDir = new Vector2(horizontalInput, verticalInput).normalized;
    }

    public void OnActionPressed()
    {
        RaycastForConversation();
    }

    public void GoFish()
    {
        Debug.Log("GoFishCalled");
        //RaycastHit2D cast1; 
        Debug.Log(viewDir);
        Debug.Log(Vector2.right);
        if (Physics2D.Raycast(_rb2d.position + Vector2.up * 0.2f, viewDir, 1.5f, LayerMask.GetMask(("Water")))
            .collider != null)
        {
            Debug.Log("Raycast Hit");
            seconds = 0;
            timer = 0;
            isFishing = true;
        }
        /*
        while(seconds < 6){
            Debug.Log(seconds);

            if(seconds == 3){
                alert.SetActive(true);
                alerted = true;
            }
            if(seconds == 5){
                alert.SetActive(false);
                alerted = false;
            }
        }
        */
    }
}