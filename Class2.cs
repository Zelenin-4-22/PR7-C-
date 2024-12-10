using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public string FIO { get; set; }
    public int Age { get; set; }
    public int BirthYear { get; set; }
    public string Group { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public void WriteToBinary(BinaryWriter writer)
    {
        writer.Write(FIO ?? "");
        writer.Write(Age);
        writer.Write(BirthYear);
        writer.Write(Group ?? "");
        writer.Write(Login ?? "");
        writer.Write(Password ?? "");
    }

    public static Student ReadFromBinary(BinaryReader reader)
    {
        return new Student
        {
            FIO = reader.ReadString(),
            Age = reader.ReadInt32(),
            BirthYear = reader.ReadInt32(),
            Group = reader.ReadString(),
            Login = reader.ReadString(),
            Password = reader.ReadString()
        };
    }
}
