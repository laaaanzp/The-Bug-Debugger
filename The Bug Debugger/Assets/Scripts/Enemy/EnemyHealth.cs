using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;

    [SerializeField] private UnityEvent onHit;
    [SerializeField] private UnityEvent onDeath;

    private string hpType;


    void Awake()
    {
        GenerateHP();
    }

    void Update()
    {
        if (transform.localScale.x == -1) hpText.transform.localScale = new Vector3(-1, 1, 1);
        else hpText.transform.localScale = new Vector3(1, 1, 1);
    }

    public void TakeDamage(string damage)
    {
        if (damage == hpType) Destroy(gameObject);
        else GenerateHP();
    }

    private void GenerateHP()
    {
        int randomNumber = Random.Range(1, 5);
        string hp = string.Empty;

        switch (randomNumber)
        {
            case 1:
                hpType = "string";
                hp = GenerateString();
                break;
            case 2:
                hpType = "int";
                hp = GenerateInt();
                break;
            case 3:
                hpType = "float";
                hp = GenerateFloat();
                break;
            case 4:
                hpType = "bool";
                hp = GenerateBool();
                break;
        }

        hpText.text = hp;
    }

    private string GenerateString()
    {
        int length = Random.Range(4, 10);
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return "\"" + new string(Enumerable.Repeat(chars, length)
          .Select(s => s[Random.Range(0, s.Length)]).ToArray() ) + "\"";
    }

    private string GenerateInt()
    {
        return Random.Range(int.MinValue, int.MaxValue).ToString();
    }

    private string GenerateFloat()
    {
        return $"{Random.Range(100f, 99999f):f2}";
    }

    private string GenerateBool()
    {
        return (Random.Range(1, 3) == 1).ToString();
    }
}
