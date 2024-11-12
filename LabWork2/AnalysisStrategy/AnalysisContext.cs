using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabWork2
{
    public class AnalysisContext
    {
        private IAnalysisStrategy strategy;

        public AnalysisContext(IAnalysisStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<Student> ExecuteStrategy(XDocument xmlData)
        {
            return strategy.Analyze(xmlData);
        }

        public void SetStrategy(IAnalysisStrategy strategy)
        {
            this.strategy = strategy;
        }
    }

}
