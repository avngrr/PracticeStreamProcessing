string fileName = @"stream processing - input.txt";

using (StreamReader reader = File.OpenText(fileName))
{
    StreamProcessing.StreamProcessor sp = new StreamProcessing.StreamProcessor();
    (int score, int scoreOnzin) = sp.ProcessStream(reader);
    Console.WriteLine(score.ToString());
    Console.WriteLine(scoreOnzin.ToString());
}