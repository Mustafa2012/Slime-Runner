using UnityEngine;

public class PlayerSpriteAnimator : MonoBehaviour
{
    [Header("Sprite Renderer")]
    public SpriteRenderer spriteRenderer;

    [Header("Color Selection")]
    public SlimeColor slimeColor = SlimeColor.Green;

    [Header("Idle Sprites")]
    public Sprite[] greenIdle;
    public Sprite[] redIdle;
    public Sprite[] blueIdle;
    public Sprite[] brownIdle;

    [Header("Walk Sprites")]
    public Sprite[] greenWalk;
    public Sprite[] redWalk;
    public Sprite[] blueWalk;
    public Sprite[] brownWalk;

    [Header("Animation Settings")]
    public float frameRate = 0.12f;

    Sprite[] currentIdle;
    Sprite[] currentWalk;

    float timer;
    int frame;
    bool isWalking;

    void Start()
    {
        SelectColor(slimeColor);
    }

    void Update()
    {
        Animate();
    }

    public void SetWalking(bool walking)
    {
        if (isWalking != walking)
        {
            isWalking = walking;
            frame = 0;
            timer = 0f;
        }
    }

    void Animate()
    {
        Sprite[] sprites = isWalking ? currentWalk : currentIdle;
        if (sprites == null || sprites.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0f;
            frame = (frame + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[frame];
        }
    }

    void SelectColor(SlimeColor color)
    {
        switch (color)
        {
            case SlimeColor.Green:
                currentIdle = greenIdle;
                currentWalk = greenWalk;
                break;
            case SlimeColor.Red:
                currentIdle = redIdle;
                currentWalk = redWalk;
                break;
            case SlimeColor.Blue:
                currentIdle = blueIdle;
                currentWalk = blueWalk;
                break;
            case SlimeColor.Brown:
                currentIdle = brownIdle;
                currentWalk = brownWalk;
                break;
        }

        frame = 0;
        timer = 0f;
        spriteRenderer.sprite = currentIdle[0];
    }
}
