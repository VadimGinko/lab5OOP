using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace lab5OOP
{
    [Serializable]
    [XmlRoot(Namespace = "NetW")]
    [XmlType("discipline")]
    public class Discipline
    {

        public Discipline() { }
        public Discipline(string NameOfTheDiscipline, int Semestr, int Course, string Specialty, string TypeOfControl, int CountOfLections, int CountOfLabs)
        {
            this.NameOfTheDiscipline = NameOfTheDiscipline;
            this.Semestr = Semestr;
            this.Course = Course;
            this.Specialty = Specialty;
            this.TypeOfControl = TypeOfControl;
            this.CountOfLections = CountOfLections;
            this.CountOfLabs = CountOfLabs;
        }
        [XmlElement(ElementName = "nameOfTheDiscipline")]
        public string NameOfTheDiscipline { get; set; }
        [XmlElement(ElementName = "semestr")]
        public int Semestr { get; set; }
        [XmlElement(ElementName = "course")]
        public int Course { get; set; }
        [XmlElement(ElementName = "specialty")]
        public string Specialty { get; set; }
        [XmlElement(ElementName = "typeOfControl")]
        public string TypeOfControl { get; set; }
        [XmlElement(ElementName = "countOfLection")]
        public int CountOfLections { get; set; }
        [XmlElement(ElementName = "countOfLab")]
        public int CountOfLabs { get; set; }

        [XmlElement(ElementName = "lector")]
        public Lector Lector = new Lector();
    }
    [Serializable]
    public class Lector
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "surname")]
        public string Surname { get; set; }
        [XmlElement(ElementName = "department")]
        public string Department { get; set; }
        [XmlElement(ElementName = "auditorium")]
        public int Auditorium { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
    }
    public static class XmlSerializeWrapper
    {
        public static void Serialize<T>(T obj, string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public static T Deserialize<T>(string filename)
        {
            T obj;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    obj = (T)formatter.Deserialize(fs);
                    return obj;
                }
            }
            return default(T);
        }
    }
}
