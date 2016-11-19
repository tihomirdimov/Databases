namespace _20161119.IO.Export
{
    using System.Linq;
    using System.Xml.Linq;
    public class ExportToXml
    {
        public static void ExportAnomlaies()
        {
            var context = new MassDefectDatabaseContext();
            var anomalies = context.Anomalies
                .Select(a => new
                {
                    id = a.Id,
                    OriginPlanet = a.OriginPlanetId,
                    TeleportPlanet = a.TeleportPlanetId,
                    a.Victims
                })
                .ToList();
            var anomaliesNode = new XElement("anomalies");
            foreach (var anomaly in anomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", anomaly.id));
                anomalyNode.Add(new XAttribute("teleport-planet", anomaly.OriginPlanet));
                anomalyNode.Add(new XAttribute("origin-planet", anomaly.TeleportPlanet));
                var victimsNode = new XElement("victims");
                foreach (var victim in anomaly.Victims)
                {
                    var victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name", victim.Name));
                    victimsNode.Add(victimNode);
                }
                anomaliesNode.Add(anomalyNode);
            }
            anomaliesNode.Save(@"..\..\ExportData\anomalies.xml");
        }
    }
}