using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _inputHorizontal;
    private readonly float _playerSpeed = 25F;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Movimentação do player
        _inputHorizontal = Input.GetAxis("Horizontal");
        _rigidbody.AddForce(new Vector2(_inputHorizontal * _playerSpeed, 0));
    }
}