using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class RabbitView : MonoBehaviour
{
    private SpriteRenderer icon;
    // Start is called before the first frame update
    public void Initialization()
    {
        icon = GetComponent<SpriteRenderer>();
    }




    // Update is called once per frame
    void Update()
    {

    }


    public void ExcuteBehavior(RabbitBehavior behavior)
    {
        string animationName = "Idle";
        switch (behavior.BehaviorType)
        {
            case BehaviorType.None:
                break;
            case BehaviorType.Idle:
                Move2Target(behavior.Position, BehaviorType.Idle);
                break;
            case BehaviorType.Talk:
                break;
            case BehaviorType.Work:
                Move2Target(behavior.Position, BehaviorType.Work);
                break;
            default:
                break;
        }

    }
    private void Move2Target(Vector3 position,BehaviorType behaviorType)
    {
        icon.flipX = transform.position.x < position.x;
        float distanceX = transform.position.x - position.x;
        float offset = 0;
        Timer.Register(Mathf.Abs(distanceX),
            () =>
            {
                transform.position = position;
                ChangeAnimation(behaviorType);
            },
            (x) =>
            {
                offset = x - offset;
                Vector3 newPos = Vector3.zero;
                if (distanceX > 0)
                    newPos = new Vector3(transform.position.x + offset, transform.position.y, 0);
                else
                    newPos = new Vector3(transform.position.x - offset, transform.position.y, 0);
                transform.position = newPos;
            });
    }
    private void ChangeAnimation(BehaviorType behaviorType)
    {
        switch (behaviorType)
        {
            case BehaviorType.None:
                break;
            case BehaviorType.Idle:
                break;
            case BehaviorType.Talk:
                break;
            case BehaviorType.Work:
                break;
            default:
                break;
        }
    }
 
}
