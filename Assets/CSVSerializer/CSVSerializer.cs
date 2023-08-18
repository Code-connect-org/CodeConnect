using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CSVSerializer
{
    public static T[] Deserialize<T>(string text)
    {
        return CreateArray<T>(ParseCSV(text));
    }

    public static T[] Deserialize<T>(List<string[]> rows)
    {
        return CreateArray<T>(rows);
    }

    public static T DeserializeIdValue<T>(string text, int id_col = 0, int value_col = 1)
    {
        return CreateIdValue<T>(ParseCSV(text), id_col, value_col);
    }

    public static T DeserializeIdValue<T>(List<string[]> rows, int id_col = 0, int value_col = 1)
    {
        return CreateIdValue<T>(rows, id_col, value_col);
    }

    private static T[] CreateArray<T>(List<string[]> rows)
    {
        T[] array_value = new T[rows.Count - 1];
        Dictionary<string, int> table = new Dictionary<string, int>();

        for (int i = 0; i < rows[0].Length; i++)
        {
            string id = rows[0][i];
            string id2 = new string(id.Where(c => Char.IsLetterOrDigit(c)).ToArray()).ToLower();

            table.Add(id, i);
            if (!table.ContainsKey(id2))
                table.Add(id2, i);
        }

        for (int i = 1; i < rows.Count; i++)
        {
            T rowdata = Create<T>(rows[i], table);
            array_value[i - 1] = rowdata;
        }
        return array_value;
    }

    private static T Create<T>(string[] cols, Dictionary<string, int> table)
    {
        T v = Activator.CreateInstance<T>();

        FieldInfo[] fieldinfo = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (FieldInfo tmp in fieldinfo)
        {
            if (table.ContainsKey(tmp.Name))
            {
                int idx = table[tmp.Name];
                if (idx < cols.Length)
                    SetValue(v, tmp, cols[idx]);
            }
        }
        return v;
    }

    private static void SetValue<T>(T v, FieldInfo fieldinfo, string value)
    {
        if (string.IsNullOrEmpty(value))
            return;

        if (fieldinfo.FieldType.IsArray)
        {
            Type elementType = fieldinfo.FieldType.GetElementType();
            string[] elem = value.Split(',');
            Array array_value = Array.CreateInstance(elementType, elem.Length);
            for (int i = 0; i < elem.Length; i++)
            {
                if (elementType == typeof(string))
                    array_value.SetValue(elem[i], i);
                else
                    array_value.SetValue(Convert.ChangeType(elem[i], elementType), i);
            }
            fieldinfo.SetValue(v, array_value);
        }
        else if (fieldinfo.FieldType.IsEnum)
            fieldinfo.SetValue(v, Enum.Parse(fieldinfo.FieldType, value));
        else if (value.IndexOf('.') != -1 &&
            (fieldinfo.FieldType == typeof(int) || fieldinfo.FieldType == typeof(long) || fieldinfo.FieldType == typeof(short)))
        {
            float f = Convert.ToSingle(value);
            fieldinfo.SetValue(v, Convert.ChangeType(f, fieldinfo.FieldType));
        }
#if UNITY_EDITOR
        else if (fieldinfo.FieldType == typeof(UnityEngine.Sprite))
        {
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(value);
            fieldinfo.SetValue(v, sprite);
        }
#endif
        else if (fieldinfo.FieldType == typeof(string))
            fieldinfo.SetValue(v, value);
        else
            fieldinfo.SetValue(v, Convert.ChangeType(value, fieldinfo.FieldType));
    }

    private static T CreateIdValue<T>(List<string[]> rows, int id_col = 0, int val_col = 1)
    {
        T v = Activator.CreateInstance<T>();

        Dictionary<string, int> table = new Dictionary<string, int>();

        for (int i = 1; i < rows.Count; i++)
        {
            if (rows[i][id_col].Length > 0)
                table.Add(rows[i][id_col].TrimEnd(' '), i);
        }

        FieldInfo[] fieldinfo = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (FieldInfo tmp in fieldinfo)
        {
            if (table.ContainsKey(tmp.Name))
            {
                int idx = table[tmp.Name];
                if (rows[idx].Length > val_col)
                    SetValue(v, tmp, rows[idx][val_col]);
            }
            else
            {
                Debug.Log("Miss " + tmp.Name);
            }
        }
        return v;
    }

    public static List<string[]> ParseCSV(string text, char separator = ',')
    {
        List<string[]> lines = new List<string[]>();
        List<string> line = new List<string>();
        StringBuilder token = new StringBuilder();
        bool quotes = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (quotes == true)
            {
                if ((text[i] == '\\' && i + 1 < text.Length && text[i + 1] == '\"') || (text[i] == '\"' && i + 1 < text.Length && text[i + 1] == '\"'))
                {
                    token.Append('\"');
                    i++;
                }
                else if (text[i] == '\\' && i + 1 < text.Length && text[i + 1] == 'n')
                {
                    token.Append('\n');
                    i++;
                }
                else if (text[i] == '\"')
                {
                    line.Add(token.ToString());
                    token = new StringBuilder();
                    quotes = false;
                    if (i + 1 < text.Length && text[i + 1] == separator)
                        i++;
                }
                else
                {
                    token.Append(text[i]);
                }
            }
            else if (text[i] == '\r' || text[i] == '\n')
            {
                if (token.Length > 0)
                {
                    line.Add(token.ToString());
                    token = new StringBuilder();
                }
                if (line.Count > 0)
                {
                    lines.Add(line.ToArray());
                    line.Clear();
                }
            }
            else if (text[i] == separator)
            {
                line.Add(token.ToString());
                token = new StringBuilder();
            }
            else if (text[i] == '\"')
            {
                quotes = true;
            }
            else
            {
                token.Append(text[i]);
            }
        }

        if (token.Length > 0)
        {
            line.Add(token.ToString());
        }
        if (line.Count > 0)
        {
            lines.Add(line.ToArray());
        }
        return lines;
    }
}
