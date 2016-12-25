namespace _20161119.IO.Import
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using _20161119.IO.DTO;
    using _20161119.Models;
    using System.Linq;
    using System.CodeDom;
    class ImportFromJson
    {
        public static void ImportSolarSystems()
        {
            var context = new MassDefectDatabaseContext();
            var json = File.ReadAllText(@"..\..\Datasets\solar-systems.json");
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);
            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.name == null || context.SolarSystems.Any(s => s.Name == solarSystem.name))
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var currentSolarSystem = new SolarSystem()
                    {
                        Name = solarSystem.name
                    };
                    context.SolarSystems.Add(currentSolarSystem);
                    Console.WriteLine("Successfully imported Solar System {0}.", solarSystem.name);
                }
            }
            context.SaveChanges();
        }
        public static void ImportStars()
        {
            var context = new MassDefectDatabaseContext();
            var json = File.ReadAllText(@"..\..\Datasets\stars.json");
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);
            foreach (var star in stars)
            {
                if (star.name == null || context.Stars.Any(s => s.Name == star.name))
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    int? currentStarSolarSystemId = null;
                    int? hasSolarSystem = GetSolarSystemId(star.solarSystem);
                    if (hasSolarSystem != null)
                    {
                        currentStarSolarSystemId = hasSolarSystem;
                    }
                    var currentStar = new Star()
                    {
                        Name = star.name,
                        SolarSystemId = currentStarSolarSystemId
                    };
                    context.Stars.Add(currentStar);
                    Console.WriteLine("Successfully imported Star {0}.", star.name);
                }
            }
            context.SaveChanges();
        }
        public static void ImportPlanets()
        {
            var context = new MassDefectDatabaseContext();
            var json = File.ReadAllText(@"..\..\Datasets\planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(json);
            foreach (var planet in planets)
            {
                if (planet.name == null || context.Planets.Any(p => p.Name == planet.name))
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    int? currentPlanetSolarSystemId = null;
                    int? currentPlanetSunId = null;
                    int? solarSystemId = GetSolarSystemId(planet.solarSystem);
                    int? sunId = GetStarId(planet.sun);
                    if (solarSystemId != null)
                    {
                        currentPlanetSolarSystemId = solarSystemId;
                    }
                    if (sunId != null)
                    {
                        currentPlanetSunId = sunId;
                    }
                    var currentPlanet = new Planet()
                    {
                        Name = planet.name,
                        SolarSystemId = currentPlanetSolarSystemId,
                        SunId = currentPlanetSunId
                    };
                    context.Planets.Add(currentPlanet);
                    Console.WriteLine("Successfully imported Planet {0}.", planet.name);
                }
            }
            context.SaveChanges();
        }
        public static void ImportPeople()
        {
            var context = new MassDefectDatabaseContext();
            var json = File.ReadAllText(@"..\..\Datasets\persons.json");
            var people = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(json);
            foreach (var person in people)
            {
                if (person.name == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    int? currentHomePlanetId = null;
                    int? homePlanetId = GetPlanetId(person.homePlanet);
                    if (homePlanetId != null)
                    {
                        currentHomePlanetId = homePlanetId;
                    }
                    var currentPerson = new Person()
                    {
                        Name = person.name,
                        HomePlanetId = currentHomePlanetId,
                    };
                    context.People.Add(currentPerson);
                    Console.WriteLine("Successfully imported Person {0}.", person.name);
                }
            }
            context.SaveChanges();
        }
        public static void ImportAnomalities()
        {
            var context = new MassDefectDatabaseContext();
            var json = File.ReadAllText(@"..\..\Datasets\anomalies.json");
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(json);
            foreach (var anomaly in anomalies)
            {
                if (anomaly.originPlanet == null || anomaly.teleportPlanet == null || GetPlanetId(anomaly.originPlanet) == null || GetPlanetId(anomaly.teleportPlanet) == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var currentAnomaly = new Anomaly()
                    {
                        OriginPlanetId = GetPlanetId(anomaly.originPlanet),
                        TeleportPlanetId = GetPlanetId(anomaly.teleportPlanet)
                    };
                    context.Anomalies.Add(currentAnomaly);
                    Console.WriteLine("Successfully imported anomaly");
                }
            }
            context.SaveChanges();
        }
        public static void ImportAnomalityVictims()
        {
            var context = new MassDefectDatabaseContext();
            var json = File.ReadAllText(@"..\..\Datasets\anomaly-victims.json");
            var victims = JsonConvert.DeserializeObject<IEnumerable<VictimDTO>>(json);
            foreach (var victim in victims)
            {
                if (victim.id == null || victim.person == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    if (context.Anomalies.Any(a => a.Id == victim.id) || GetPersonId(victim.person) != null)
                    {
                        int? tempId = GetPersonId(victim.person);
                        if (tempId.HasValue)
                        {
                            int victimId = tempId.Value;
                            Person victimToAdd = context.People.FirstOrDefault(p => p.Id == victimId);
                            context.Anomalies.First(v => v.Id == victim.id).Victims.Add(victimToAdd);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            context.SaveChanges();
        }

        private static int? GetSolarSystemId(string name)
        {
            var context = new MassDefectDatabaseContext();
            if (context.SolarSystems.Any(s => s.Name == name))
            {
                int id = context.SolarSystems.First(s => s.Name == name).Id;
                return id;
            }
            else
            {
                return null;
            }
        }
        private static int? GetStarId(string name)
        {
            var context = new MassDefectDatabaseContext();
            if (context.Stars.Any(s => s.Name == name))
            {
                int id = context.Stars.First(s => s.Name == name).Id;
                return id;
            }
            else
            {
                return null;
            }
        }
        private static int? GetPlanetId(string name)
        {
            var context = new MassDefectDatabaseContext();
            if (context.Planets.Any(p => p.Name == name))
            {
                int id = context.Planets.First(s => s.Name == name).Id;
                return id;
            }
            else
            {
                return null;
            }
        }
        private static int? GetPersonId(string name)
        {
            var context = new MassDefectDatabaseContext();
            if (context.People.Any(p => p.Name == name))
            {
                int id = context.People.First(s => s.Name == name).Id;
                return id;
            }
            else
            {
                return null;
            }
        }
    }
}