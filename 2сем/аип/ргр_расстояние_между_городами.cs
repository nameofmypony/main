using System;
using System.IO;
class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        string[] city1 = lines[0].Split();
        string[] city2 = lines[1].Split();
        int latitude1 = int.Parse(city1[0]);
        int longitude1 = int.Parse(city1[1]);
        int latitude2 = int.Parse(city2[0]);
        int longitude2 = int.Parse(city2[1]);
        int R = int.Parse(lines[2]);

        double lat1 = DegreesToRadians(latitude1);
        double lon1 = DegreesToRadians(longitude1);
        double lat2 = DegreesToRadians(latitude2);
        double lon2 = DegreesToRadians(longitude2);

        double dlat = Math.Abs(lat1 - lat2);
        double dlon = Math.Abs(lon1 - lon2);
        dlon = Math.Min(dlon, 2 * Math.PI - dlon);

        double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
        double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double distance = R * angle;

        string result = Math.Round(distance, 3).ToString("0.000").Replace(',', '.');
        File.WriteAllText("output.txt", result);
    }
    static double DegreesToRadians(double degrees) => degrees * Math.PI / 180.0;
}
