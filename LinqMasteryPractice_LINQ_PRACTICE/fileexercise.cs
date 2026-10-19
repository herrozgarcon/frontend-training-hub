namespace LinqMastery;

public class Fileexercise
{
    public static void Run()
    {
        string path = "demo1.txt";
        string contents = "this the text file to be written"; 
        // File.WriteAllText(path, contents);

        string cont=File.ReadAllText(path);
        Console.WriteLine(cont);


        // FileInfo  f1 = new FileInfo(path);
        // bool is_exist = f1.Exists;
        // Console.WriteLine(is_exist);
        // Console.WriteLine(f1.LastWriteTime);

        using StreamReader reader = new StreamReader("demo.txt");
        
        


    }
}
