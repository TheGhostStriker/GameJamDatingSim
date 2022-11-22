using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ComedyMiniGame : MonoBehaviour
{
    bool active;
    [SerializeField] UnityEvent onComplete;
    [SerializeField] int currentLine, currentScore, currentStreak, leftToSpawn, maxSpawn;
    [SerializeField] Transform cursor;
    int maxLines;
    [SerializeField] float speed;
    [SerializeField] Transform[] lines;
    [SerializeField] SpriteRenderer[] backings;
    Vector2 cursorTargetPos;
    [SerializeField] float cursorSnapSpeed, successThreshold;
    float leftFader, rightFader;
    [SerializeField] List<Transform> pips;
    [SerializeField] Transform pip, booText, hahaText;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Vector4 textSpawnBounds; //XL -XR -YB -YU
    [SerializeField] TMP_Text statText, charismaLevelUp;

    // Start is called before the first frame update
    void Start()
    {
        leftFader = transform.position.x - 4;
        rightFader = transform.position.x + 4;
        maxLines = lines.Length - 1;
        cursorTargetPos = cursor.position;
        StartCoroutine(SpawnPips());
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        cursor.position = Vector2.MoveTowards(cursor.position, cursorTargetPos, cursorSnapSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentLine++;
            currentLine = Mathf.Clamp(currentLine, 0, maxLines);
            cursorTargetPos = new Vector2(cursor.position.x, lines[currentLine].position.y);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentLine--;
            currentLine = Mathf.Clamp(currentLine, 0, maxLines);
            cursorTargetPos = new Vector2(cursor.position.x, lines[currentLine].position.y);
        }
        MovePips();
    }

    void MovePips()
    {
        for (int i = 0; i < pips.Count; i++)
        {
            pips[i].position += speed * Time.deltaTime * Vector3.left;
            float x = pips[i].position.x;
            SpriteRenderer sr = pips[i].GetComponent<SpriteRenderer>();
            Color col = sr.color;
            if (x > rightFader)
            {
                pips[i].localScale = Vector2.Lerp(Vector2.one, Vector2.zero, x - rightFader);
                col.a = Mathf.Lerp(1, 0, x - rightFader);
                sr.color = col;
            }
            if (x < leftFader)
            {
                pips[i].localScale = Vector2.Lerp(Vector2.one, Vector2.zero, leftFader - x);
                col.a = Mathf.Lerp(1, 0, x - leftFader);
                sr.color = col;
            }
        }

        for (int i = pips.Count - 1; i >= 0; i--)
        {
            if (Vector2.Distance(pips[i].position, cursor.position) < successThreshold)
            {
                currentScore++;
                currentStreak++;
                backings[pips[i].GetComponent<ComedyLineKeeper>().lineNum].GetComponent<ComedyLineBacking>().Hit();
                backings[pips[i].GetComponent<ComedyLineKeeper>().lineNum].GetComponent<CameraShake>().shakeDuration = .1f;
                particles.Play();
                SpawnText(0);
                DestroyPip(i);
            }
        }

        for (int i = pips.Count - 1; i >= 0; i--)
        {
            if (pips[i].position.x < leftFader - 1)
            {
                backings[pips[i].GetComponent<ComedyLineKeeper>().lineNum].GetComponent<ComedyLineBacking>().Miss();
                SpawnText(1);
                DestroyPip(i);
            }
        }
    }

    void SpawnText(int num)
    {
        Transform splashText = Instantiate(num == 1 ? booText : hahaText, new Vector3(Random.Range(textSpawnBounds.w, textSpawnBounds.x), Random.Range(textSpawnBounds.y, textSpawnBounds.z), 0), Quaternion.identity);
        splashText.rotation = Quaternion.Euler(0, 0, Random.Range(0, 75));
    }

    void DestroyPip(int i)
    {
        Transform temp = pips[i];
        pips.RemoveAt(i);
        Destroy(temp.gameObject);

        if (leftToSpawn <= 0 && pips.Count == 0)
        {
            float t = Mathf.Clamp(((float)currentStreak / maxSpawn) * 100, 0, 100);
            statText.gameObject.SetActive(true);
            statText.text = $"{t}%";
            if (t > 80)
            {
                charismaLevelUp.gameObject.SetActive(true);
                statText.GetComponent<Animator>().Play("Flashing");
                Attributes.IncreaseCharisma();
            }
            else
            {
                statText.color = Color.red;
            }

            if (onComplete != null) onComplete.Invoke();
        }
    }

    public void ActivateIn(float count)
    {
        Invoke("Activate", count);
    }

    void Activate()
    {
        active = true;
    }

    IEnumerator SpawnPips()
    {
        while (!active)
        {
            yield return new WaitForEndOfFrame();
        }
        while (leftToSpawn > 0)
        {
            int rand = Random.Range(0, lines.Length);
            pips.Add(Instantiate(pip, lines[rand].position + Vector3.right * 5, Quaternion.identity));
            pips[pips.Count - 1].GetComponent<ComedyLineKeeper>().lineNum = rand;
            leftToSpawn--;
            if (leftToSpawn == maxSpawn - 1) DestroyPip(0);
            yield return new WaitForSeconds(.45f);
        }
    }
}
