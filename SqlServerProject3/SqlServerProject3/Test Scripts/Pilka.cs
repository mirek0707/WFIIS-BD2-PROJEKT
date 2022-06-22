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
public struct Pilka: INullable, IBinarySerialize
{
    private string _marka;
    private int _rozmiar;
    private string _model;
    private string _przeznaczenie;
    private string _kolor;
    private string _zaawansowanie;
    private double _cena;
    private bool _null;
    public Pilka(string marka, int rozmiar, string model, string przeznaczenie, string kolor, string zaawansowanie, double cena)
    {
        _marka = marka;
        _rozmiar = rozmiar;
        _model = model;
        _przeznaczenie = przeznaczenie;
        _kolor = kolor;
        _zaawansowanie = zaawansowanie;
        _cena = cena;
        _null = false;
    }

    public string getMarka() { return _marka; }
    public int getRozmiar() { return _rozmiar; }
    public string getModel() { return _model; }
    public string getPrzezn() { return _przeznaczenie; }
    public string getKolor() { return _kolor; }
    public string getZaawans() { return _zaawansowanie; }
    public double getCena() { return _cena; }

    
    public override string ToString()
    {
        if (this.IsNull) return "NULL";
        else
        {
            string s = "Pilka:" +
                "\tMarka: " + _marka + "\n" +
                "\tRozmiar: " + _rozmiar.ToString() + "\n" +
                "\tModel: " + _model + "\n" +
                "\tPrzeznaczenie: " + _przeznaczenie + "\n" +
                "\tKolor: " + _kolor + "\n" +
                "\tZaawansowanie: " + _zaawansowanie + "\n" +
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
    
    public static Pilka Null
    {
        get
        {
            Pilka h = new Pilka();
            h._null = true;
            return h;
        }
    }
    
    public static Pilka Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        string[] val = s.Value.Split("/".ToCharArray());
        if (val.Length != 7)
        {
            throw new ArgumentException("Niepoprawna liczba argumentów! (wymagane 7)");
        }
        Pilka u = new Pilka();

        u._marka = val[0];
        u._rozmiar = int.Parse(val[1]);
        u._model = val[2];
        u._przeznaczenie = val[3];
        u._kolor = val[4];
        u._zaawansowanie = val[5];
        u._cena = double.Parse(val[6]);

        if (u._cena<=0.0 || u._rozmiar<1 || u._rozmiar>5
            ) throw new ArgumentException("Niepoprawna wartoœæ!");

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

        _rozmiar = r.ReadInt32();

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

        chars = r.ReadChars(maxStringSize);
        stringEnd = Array.IndexOf(chars, '\0');
        if (stringEnd == 0)
        {
            stringValue = null;
            return;
        }
        stringValue = new String(chars, 0, stringEnd);
        _kolor = stringValue;

        chars = r.ReadChars(maxStringSize);
        stringEnd = Array.IndexOf(chars, '\0');
        if (stringEnd == 0)
        {
            stringValue = null;
            return;
        }
        stringValue = new String(chars, 0, stringEnd);
        _zaawansowanie = stringValue;

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
        w.Write(_rozmiar);
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
        s = _kolor.PadRight(maxStringSize, '\0');
        for (int i = 0; i < s.Length; i++)
        {
            w.Write(s[i]);
        }
        s = _zaawansowanie.PadRight(maxStringSize, '\0');
        for (int i = 0; i < s.Length; i++)
        {
            w.Write(s[i]);
        }
        w.Write(_cena);
    }

}