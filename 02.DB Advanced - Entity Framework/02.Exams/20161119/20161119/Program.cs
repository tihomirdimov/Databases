using System.Runtime.Serialization;
using _20161119.IO.Export;
using _20161119.IO.Import;

namespace _20161119
{
    using System.IO;
    using Models;
    class Program
    {
        static void Main(string[] args)
        {
            //not enogh time to complete XML import, JSON export and refactoring
            ImportFromJson.ImportSolarSystems();
            ImportFromJson.ImportStars();
            ImportFromJson.ImportPlanets();
            ImportFromJson.ImportPeople();
            ImportFromJson.ImportAnomalities();
            ImportFromJson.ImportAnomalityVictims();
            ExportToXml.ExportAnomlaies();
        }
    }
}