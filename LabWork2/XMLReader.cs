using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace LabWork2
{
        public class XMLReader
        {
            public List<Student> ReadStudentsFromXML(string filePath)
            {
                List<Student> students = new List<Student>();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNodeList studentNodes = xmlDoc.SelectNodes("/Dormitory/Student");
                foreach (XmlNode studentNode in studentNodes)
                {
                    Student student = new Student
                    {
                        FullName = studentNode["FullName"]?.InnerText,
                        Faculty = studentNode["Faculty"]?.InnerText,
                        Department = studentNode["Department"]?.InnerText,
                        Course = int.Parse(studentNode["Course"]?.InnerText ?? "0"),
                        Room = int.Parse(studentNode["Room"]?.InnerText ?? "0"),
                        CheckIn = DateTime.Parse(studentNode["Residence"]["CheckIn"]?.InnerText ?? "0001-01-01"),
                        CheckOut = DateTime.Parse(studentNode["Residence"]["CheckOut"]?.InnerText ?? "0001-01-01")
                    };
                    students.Add(student);
                }

                return students;
            }
        }
    }


