using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GradeJournal
{
    public string StudentFIO { get; set; }
    public string Discipline { get; set; }
    public int Grade { get; set; }
    public DateTime Date { get; set; }

    public void WriteToBinary(BinaryWriter writer)
    {
        writer.Write(StudentFIO ?? "");
        writer.Write(Discipline ?? "");
        writer.Write(Grade);
        writer.Write(Date.ToBinary());
    }

    public static GradeJournal ReadFromBinary(BinaryReader reader)
    {
        return new GradeJournal
        {
            StudentFIO = reader.ReadString(),
            Discipline = reader.ReadString(),
            Grade = reader.ReadInt32(),
            Date = DateTime.FromBinary(reader.ReadInt64())
        };
    }
}
