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
public struct Getry: INullable, IBinarySerialize
{
    private string _marka;
    private string _model;
    private string _kolor;
    private double _cena;
    private bool _null;
    public Getry(string marka, string model, string kolor, double cena)
    {
        _marka = marka;
        _model = model;
        _kolor = kolor;
        _cena = cena;
        _null = false;
    }

    public string getMarka() { return _marka; }
    public string getModel() { return _model; }
    public string getKolor() { return _kolor; }
    public double getCena() { return _cena; }

    
    public override string ToString()
    {
        if (this.IsNull) return "NULL";
        else
        {
            string s = "Getry:" +
                "\tMarka: " + _marka + "\n" +
                "\tModel: " + _model + "\n" +
                "\tKolor: " + _kolor + "\n" +
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
    
    public static Getry Null
    {
        get
        {
            Getry h = new Getry();
            h._null = true;
            return h;
        }
    }
    
    public static Getry Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        string[] val = s.Value.Split("/".ToCharArray());
        if (val.Length != 4)
        {
            throw new ArgumentException("Niepoprawna liczba argumentów! (wymagane 4)");
        }
        Getry u = new Getry();

        u._marka = val[0];
        u._model = val[1];
        u._kolor = val[2];
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
        _kolor = stringValue;

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
        s = _kolor.PadRight(maxStringSize, '\0');
        for (int i = 0; i < s.Length; i++)
        {
            w.Write(s[i]);
        }
        w.Write(_cena);
    }
}