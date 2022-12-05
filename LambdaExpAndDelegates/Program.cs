// See https://aka.ms/new-console-template for more information

//var sayiKarsilastir = new SayiKarsilastirma();
//var c = sayiKarsilastir.SayiKarsilastir(2, 2, new Karsilastirma());
//var d = sayiKarsilastir.SayiKarsilastir(2, 2, new BuyukKucukKarsilastirma());

//Console.WriteLine(c);
//Console.WriteLine(d);

//public interface IKarsilastirma
//{
//    bool Karsilastir(int a, int b);
//}

//public class Karsilastirma : IKarsilastirma
//{
//    public bool Karsilastir(int a, int b)
//    {
//        return a == b;
//    }
//}

//public class BuyukKucukKarsilastirma : IKarsilastirma
//{
//    public bool Karsilastir(int a, int b)
//    {
//        return a < b;
//    }
//}

//public class SayiKarsilastirma
//{
//    public bool SayiKarsilastir(int a, int b, IKarsilastirma karsilastirma)
//    {
//        return karsilastirma.Karsilastir(a, b);
//    }
//}

// Delegate ile kolaylaştırılması
//var sayiKarsilastir = new SayiKarsilastirma();
//Karsilastir karsilastir = new Karsilastir(EsitlikKarsilastirmasi);
//Karsilastir karsilastir2 = new Karsilastir(BuyukKucukKarsilastirmasi);

//var c = sayiKarsilastir.SayiKarsilastir(2, 2, karsilastir);
//var d = sayiKarsilastir.SayiKarsilastir(2, 2, karsilastir2);
//Console.WriteLine(c);
//Console.WriteLine(d);

//bool EsitlikKarsilastirmasi(int a, int b)
//{
//    return a == b;
//}

//bool BuyukKucukKarsilastirmasi(int a, int b)
//{
//    return a < b;
//}

//public delegate bool Karsilastir(int a, int b);

//public class SayiKarsilastirma
//{
//    public bool SayiKarsilastir(int a, int b, Karsilastir karsilastir)
//    {
//        return karsilastir(a, b);
//    }
//}

// Anonymous Expression Func ile kolaylaştırılması
//var sayiKarsilastir = new SayiKarsilastirma();

//var c = sayiKarsilastir.SayiKarsilastir(2, 2, delegate(int a , int b) { return a == b; });
//var d = sayiKarsilastir.SayiKarsilastir(2, 2, delegate (int a, int b) { return a < b; });
//Console.WriteLine(c);
//Console.WriteLine(d);

//public delegate bool Karsilastir(int a, int b);

//public class SayiKarsilastirma
//{
//    public bool SayiKarsilastir(int a, int b, Karsilastir karsilastir)
//    {
//        return karsilastir(a, b);
//    }
//}

// Lambda Expression Func ile kolaylaştırılması
//var sayiKarsilastir = new SayiKarsilastirma();

//var c = sayiKarsilastir.SayiKarsilastir(2, 2, (a, b) => a == b);
//var d = sayiKarsilastir.SayiKarsilastir(2, 2, (a, b) => a < b);
//Console.WriteLine(c);
//Console.WriteLine(d);

//public delegate bool Karsilastir(int a, int b);

//public class SayiKarsilastirma
//{
//    public bool SayiKarsilastir(int a, int b, Karsilastir karsilastir)
//    {
//        return karsilastir(a, b);
//    }
//}

// Function Delegate ile kolaylaştırılması
var sayiKarsilastir = new SayiKarsilastirma();

var c = sayiKarsilastir.SayiKarsilastir(2, 2, (a, b) => a == b);
var d = sayiKarsilastir.SayiKarsilastir(2, 2, (a, b) => a < b);
Console.WriteLine(c);
Console.WriteLine(d);
Console.WriteLine("test");

public class SayiKarsilastirma
{
    public bool SayiKarsilastir(int a, int b, Func<int, int, bool> karsilastir)
    {
        return karsilastir(a, b);
    }
}