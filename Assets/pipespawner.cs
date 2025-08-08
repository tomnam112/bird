using UnityEngine;

public class pipespawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 10;

    private logicscript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    void Update()
    {
        if (logic.gameIsOver) return;
        // ปรับ spawnRate ตามคะแนน
        float dynamicSpawnRate = Mathf.Clamp(spawnRate - logic.playerScore * 0.05f, 0.6f, 2f);

        if (timer < dynamicSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}