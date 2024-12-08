using System;
class Q
{
    static void Main()
    {
        string opera = "", all = "";
        while (true)
        {
            int number;
            string l = Console.ReadLine();
            if (l == "") break;
            opera = "";
            string[] L = l.Split(' ');
            string[] All = all.Split(' ');
            for (int i = 1; i < L.Length; i++)
            {
                if (int.TryParse(L[i], out number)) opera += All[number];
                else opera += L[i];
            }
            if (L[0] == "MIX") opera = "MX" + opera + "XM";
            if (L[0] == "WATER") opera = "WT" + opera + "TW";
            if (L[0] == "DUST") opera = "DT" + opera + "TD";
            if (L[0] == "FIRE") opera = "FR" + opera + "RF";
            all = all + " " + opera;
        }
        Console.WriteLine(opera);
    }
}
