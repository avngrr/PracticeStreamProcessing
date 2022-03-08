string fileName = @"stream processing - input.txt";

using (StreamReader reader = File.OpenText(fileName))
{
    StreamProcessing.StreamProcessor sp = new StreamProcessing.StreamProcessor();
    int score = 0;
    int scoreOnzin = 0;
    sp.ProcessStream(reader, out score, out scoreOnzin);
    Console.WriteLine(score.ToString());
    Console.WriteLine(scoreOnzin.ToString());
}