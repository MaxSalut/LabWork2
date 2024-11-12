using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabWork2
{
    public class HtmlTransformer
    {
        public string TransformToHtml(XDocument xmlData)
        {
            var html = "<html><body><table border='1'>";
            html += "<tr><th>Full Name</th><th>Faculty</th><th>Department</th><th>Course</th><th>Room</th></tr>";

            foreach (var student in xmlData.Descendants("Student"))
            {
                html += "<tr>";
                html += $"<td>{student.Element("FullName")?.Value}</td>";
                html += $"<td>{student.Element("Faculty")?.Value}</td>";
                html += $"<td>{student.Element("Department")?.Value}</td>";
                html += $"<td>{student.Element("Course")?.Value}</td>";
                html += $"<td>{student.Element("Room")?.Value}</td>";
                html += "</tr>";
            }

            html += "</table></body></html>";
            return html;
        }
    }

}
