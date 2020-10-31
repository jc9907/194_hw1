using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour {
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    void Start() {
        dest = transform.position;
    }

    void FixedUpdate() {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        string curDir = "";

        if (Input.GetKey(KeyCode.UpArrow))
        {
            curDir = "up";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            curDir = "right";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            curDir = "down";
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            curDir = "left";
        }

        if ((Vector2)transform.position == dest)
        {
            if (curDir == "up" && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (curDir == "right" && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (curDir == "down" && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (curDir == "left" && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right; }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir) {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
