using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private ObjectBehaviour _objectBehaviour;
    [SerializeField] private Animator _animator;
    private readonly float _playerSpeed = 35F;
    private bool _facingRight = true;
    private float _inputHorizontal;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _objectBehaviour.SpawnObject(); // Spwawna o presente ao inicial o jogo
    }

    // Update is called once per frame
    private void Update()
    {
        // Sair do game
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKey(KeyCode.R))
            Restart();

        // Movimentação do player
        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (_inputHorizontal != 0)
            _rigidbody
                .AddForce(new Vector2(_inputHorizontal * _playerSpeed, 0));

        // Flip player
        if (_inputHorizontal > 0 && !_facingRight)
            Flip();

        else if (_inputHorizontal < 0 && _facingRight)
            Flip();

        // Animação do player
        _animator.SetFloat("Speed",
            Mathf.Abs(_inputHorizontal)); // Usamos Abs. devido ao eixo x na esquerda ser negativo
    }

    /// <summary>
    ///     Obtem a scale atual do jogador
    ///     e muda para o sentido oposto
    /// </summary>
    private void Flip()
    {
        var currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }

    // Reiniciar jogo
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}