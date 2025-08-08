using UnityEngine;

public class PipeMovescript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -70;
    private logicscript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    void Update()
    {
        if (logic.gameIsOver) return;
        // เพิ่มความเร็วตามคะแนน (ปรับตามต้องการ)
        float currentSpeed = moveSpeed + logic.playerScore * 0.1f;

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
