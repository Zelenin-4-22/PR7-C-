using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Teacher
{
    public string FIO { get; set; }
    public int BirthYear { get; set; }
    public List<string> Disciplines { get; set; } = new List<string>();
    public List<string> Groups { get; set; } = new List<string>();
    public string Login { get; set; }
    public string Password { get; set; }

    public void WriteToBinary(BinaryWriter writer)
    {
        writer.Write(FIO ?? "");
        writer.Write(BirthYear);
        writer.Write(Disciplines.Count);
        foreach (var discipline in Disciplines)
            writer.Write(discipline ?? "");
        writer.Write(Groups.Count);
        foreach (var group in Groups)
            writer.Write(group ?? "");
        writer.Write(Login ?? "");
        writer.Write(Password ?? "");
    }

    public static Teacher ReadFromBinary(BinaryReader reader)
    {
        var teacher = new Teacher
        {
            FIO = reader.ReadString(),
            BirthYear = reader.ReadInt32()
        };

        int disciplineCount = reader.ReadInt32();
        for (int i = 0; i < disciplineCount; i++)
            teacher.Disciplines.Add(reader.ReadString());

        int groupCount = reader.ReadInt32();
        for (int i = 0; i < groupCount; i++)
            teacher.Groups.Add(reader.ReadString());

        teacher.Login = reader.ReadString();
        teacher.Password = reader.ReadString();

        return teacher;
    }
}

