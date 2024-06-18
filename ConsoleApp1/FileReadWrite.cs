using System;
using System.IO;

public class FileReadWrite
{
    public static void exec(string[] args)
    {
        string fileName = "vixfile.txt";
        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader( fs );
        string fileContent = sr.ReadToEnd();
        if( string.IsNullOrEmpty(fileContent) )
        {
            fs.Close();
            fs = new FileStream( fileName, FileMode.OpenOrCreate, FileAccess.Write );
            StreamWriter sw = new StreamWriter( fs );
            sw.Write( "This is the file content." );
            sw.Close();
            Console.WriteLine("I've written in file: " + fileName );
        }
        else   {
            Console.WriteLine("I've read the file content: " + fileContent );
        }
    }
}