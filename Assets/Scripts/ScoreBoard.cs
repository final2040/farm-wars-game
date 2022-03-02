using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ScoreBoard : ICollection<PlayerScore>
{
    public readonly int maxLength;
    public IList<PlayerScore> scores = new List<PlayerScore>();

    public ScoreBoard()
    {
        maxLength = 10;
    }

    public ScoreBoard(int maxLength)
    {
        this.maxLength = maxLength;
    }


    public IEnumerator<PlayerScore> GetEnumerator()
    {
        return scores.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(PlayerScore item)
    {
        scores.Add(item);
        Sort();
        if (scores.Count >= maxLength)
            RemoveLast();
    }

    private void RemoveLast()
    {
        scores.RemoveAt(scores.Count - 1);
    }

    public void Sort()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            for (int j = 0; j < scores.Count -1; j++)
            {
                if (scores[j].Score < scores[j + 1].Score)
                {
                    var aux = scores[j];
                    scores[j] = scores[j + 1];
                    scores[j + 1] = aux;
                }
                
            }
        }
    }

    public void Clear()
    {
        scores.Clear();
    }

    public bool Contains(PlayerScore item)
    {
        return scores.Contains(item);
    }

    public void CopyTo(PlayerScore[] array, int arrayIndex)
    {
        scores.CopyTo(array, arrayIndex);
    }

    public bool Remove(PlayerScore item)
    {
        return scores.Remove(item);
    }

    public int Count => scores.Count;
    public bool IsReadOnly => scores.IsReadOnly;
    public PlayerScore MaxScore
    {
        get
        {
            if (scores.Count > 0)
            {
                return scores[0];
            }

            return new PlayerScore();
        }
    }
}