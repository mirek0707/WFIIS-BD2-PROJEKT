using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(
    Format.UserDefined,
    MaxByteSize = 8000,
    IsByteOrdered = true
 )]
public struct Ochraniacze: INullable, IBinarySerialize
{
    private string _marka;
    private string _model;
    private string _przeznaczenie;
    private double _cena;
    private bool _null;
    public Ochraniacze(string marka, string model, string przeznaczenie, double cena)
    {
        _marka = marka;
        _model = model;
        _przeznaczenie = przeznaczenie;
        _cena = cena;
        _null = false;
    }

    public string getMarka() { return _marka; }
    public string getModel() { return _model; }
    public string getPrzeznaczenie() { return _przeznaczenie; }
    public double getCena() { return _cena; }

    
    public override string ToString()
    {
        if (this.IsNull) return "NULL";
        else
        {
            string s = "Ochraniacze:" +
                "\tMarka: " + _marka + "\n" +
                "\tModel: " + _model + "\n" +
                "\tPrzeznaczenie: " + _przeznaczenie + "\n" +
                "\tcena: " + _cena.ToString() + "z³\n";
            return s;
        }
    }
    
    public bool IsNull
    {
        get
        {
            // Put your code here
            return _null;
        }
    }
    
    public static Ochraniacze Null
    {
        get
        {
            Ochraniacze h = new Ochraniacze();
            h._null = true;
            return h;
        }
    }
    
    public static Ochraniacze Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        string[] val = s.Value.Split("/".ToCharArray());
        if (val.Length != 4)
        {
            throw new ArgumentException("Niepoprawna liczba argumentów! (wymagane 4)");
        }
        Ochraniacze u = new Ochraniacze();

        u._marka = val[0];
        u._model = val[1];
        u._przeznaczenie = val[2];
        u._cena = double.Parse(val[3]);

        if (u._cena<=0.0) throw new ArgumentException("Niepoprawna wartoœæ!");

        return u;
    }

    public void Read(BinaryReader r)
    {
        int maxStringSize = 100;
        char[] chars;
        int stringEnd;
        string stringValue;

        chars = r.ReadChars(maxStringSize);
        stringEnd = Array.IndexOf(chars, '\0');
        if (stringEnd == 0)
        {
            stringValue = null;
            return;
        }
        stringValue = new String(chars, 0, stringEnd);
        _marka = stringValue;

        chars = r.ReadChars(maxStringSize);
        stringEnd = Array.IndexOf(chars, '\0');
        if (stringEnd == 0)
        {
            stringValue = null;
            return;
        }
        stringValue = new String(chars, 0, stringEnd);
        _model = stringValue;

        chars = r.ReadChars(maxStringSize);
        stringEnd = Array.IndexOf(chars, '\0');
        if (stringEnd == 0)
        {
            stringValue = null;
            return;
        }
        stringValue = new String(chars, 0, stringEnd);
        _przeznaczenie = stringValue;

        _cena = r.ReadDouble();
    }

    public void Write(BinaryWriter w)
    {
        int maxStringSize = 100;
        string s;
        s = _marka.PadRight(maxStringSize, '\0');
        for (int i = 0; i < s.Length; i++)
        {
            w.Write(s[i]);
        }
        s = _model.PadRight(maxStringSize, '\0');
        for (int i = 0; i < s.Length; i++)
        {
            w.Write(s[i]);
        }
        s = _przeznaczenie.PadRight(maxStringSize, '\0');
        for (int i = 0; i < s.Length; i++)
        {
            w.Write(s[i]);
        }
        w.Write(_cena);
    }
}