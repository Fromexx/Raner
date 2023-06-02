using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform player;
    [SerializeField] private FixedJoystick _fixedJoystick;
    private Rigidbody rb;
    private float deltaX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                  deltaX = touchPos.x - transform.position.x;
                  break;

                case TouchPhase.Moved:
                rb.MovePosition(new Vector3(touchPos.x - deltaX, 0, 0));
                break;

                case TouchPhase.Ended:
                rb.velocity = Vector3.zero;
                break;
            }
        }
        Move();
    }

    void Move()
    {
        var direction = new Vector3(_fixedJoystick.Direction.x, 0, _fixedJoystick.Direction.y);
        
        player.Translate(direction * (Time.deltaTime * speed), Space.World);
    }
}

