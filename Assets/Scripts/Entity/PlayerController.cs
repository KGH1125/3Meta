using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 1f;
    private bool isLeft = false;
    private AnimationHandler animationHandler;
    private bool isEventZone = false;
    private GameObject npc;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animationHandler = GetComponent<AnimationHandler>();
        
    }

    void Start()
    {
       npc = GameObject.Find("MiniGameNPC/Canvas/NPCTalkBoxUI");
       npc.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //npc ���� ������ space�� ����
        if (isEventZone && Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.OnClickEvent();
            Time.timeScale = 0f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 input = GetMoveInput();
        Move(input);
        UpdateDirection(input);
        animationHandler.Move(input);
    }

    //ĳ���� �̵�
    private void Move(Vector2 direction)
    {
        Vector2 moveDelta = direction * speed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + moveDelta);
    }

    //����Ű ��ǲ�� �Է�
    private Vector2 GetMoveInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        return new Vector2(moveX, moveY).normalized;
    }

    //�¿����
    private void UpdateDirection(Vector2 direction)
    {
        if (direction.x < 0 && !isLeft)
        {
            spriteRenderer.flipX = true;
            isLeft = true;
        }
        else if (direction.x > 0 && isLeft)
        {
            spriteRenderer.flipX = false;
            isLeft = false;
        }
    }
    //�浹����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Trigger")
        {
            npc.gameObject.SetActive(true);
            isEventZone = true;
        }
        
    }
    //�浹���� Ż��
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Trigger")
        {
            npc.gameObject.SetActive(false);
            isEventZone = false;
        }
    }

}
