using System;
class Q {
    static void Main() {
        int firma = 0, N = Convert.ToInt32(Console.ReadLine());
        double m = 0, min = Double.MaxValue;
        for (int i = 0; i < N; i++) {
            string L = Console.ReadLine();
            L = L.Replace('.', ',');
            string[] K = L.Split(' ');
            double[] l = new double[K.Length];
            for (int j = 0; j < K.Length; j++) l[j] = double.Parse(K[j]);
            m = 1000 * (l[6] * (l[3] * l[4] + l[3] * l[5] + l[4] * l[5]) - l[7] * (l[0] * l[1] + l[0] * l[2] + l[1] * l[2])) / (l[0] * l[1] * l[2] * (l[3] * l[4] + l[3] * l[5] + l[4] * l[5]) - l[3] * l[4] * l[5] * (l[0] * l[1] + l[0] * l[2] + l[1] * l[2]));
            if (m < min) {
                min = m;
                firma = i + 1;
            }
        }
        string answer = string.Format("{0:F2}", min);
        answer = answer.Replace(',', '.');
        Console.WriteLine(firma + " " + answer);
    }
}
