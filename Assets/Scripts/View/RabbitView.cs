using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class RabbitView : MonoBehaviour
{
    private SpriteRenderer Icon;
    private Queue<RabbitOrder> OrderQueue;
    private bool Executing;
    // Start is called before the first frame update
    public void Initialization()
    {
        Icon = GetComponent<SpriteRenderer>();
        OrderQueue = new Queue<RabbitOrder>();
        Executing = false;
    }




    // Update is called once per frame
    void Update()
    {
        if (OrderQueue.Count != 0&&!Executing)
        {
            RabbitOrder order = OrderQueue.Dequeue();
            Execute(order);
            Executing = true;
        }
    }


    public void AddOrder(RabbitOrder order)
    {
        OrderQueue.Enqueue(order);
    }
    private void Execute(RabbitOrder order)
    {
        
    }
    private void Move2Target(Vector3 position,OrderType orderType)
    {
        if (position == Vector3.zero) return;
        Icon.flipX = transform.position.x < position.x;
        float distanceX = transform.position.x - position.x;
        float offset = 0;
        Timer.Register(Mathf.Abs(distanceX),
            () =>
            {
                transform.position = position;
                ChangeAnimation(orderType);
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
    private void ChangeAnimation(OrderType behaviorType)
    {
        switch (behaviorType)
        {
            case OrderType.None:
                break;
            case OrderType.Idle:
                break;
            case OrderType.Talk:
                break;
            case OrderType.Work:
                break;
            default:
                break;
        }
    }
 
}
