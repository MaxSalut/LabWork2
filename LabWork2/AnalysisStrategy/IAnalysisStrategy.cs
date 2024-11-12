using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabWork2
{
    public interface IAnalysisStrategy
    {
        List<Student> Analyze(XDocument xmlData); // Метод для аналізу даних з XML
    }
}
