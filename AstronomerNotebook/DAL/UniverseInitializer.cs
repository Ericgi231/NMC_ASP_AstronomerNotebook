using System;
using System.Collections.Generic;
using System.Data.Entity;
using AstronomerNotebook.Models;
using System.Linq;
using System.Web;

namespace AstronomerNotebook.DAL
{
    public class UniverseInitializer : DropCreateDatabaseIfModelChanges<UniverseContext>
    {
        protected override void Seed(UniverseContext context)
        {
            var astronomers = new List<Astronomer>
            {
                new Astronomer{ Id=1, Name="William Herschel" },
                new Astronomer{ Id=2, Name="Edward Joshua Cooper"},
                new Astronomer{ Id=3, Name="Charles Messier"}
            };

            astronomers.ForEach(s => context.Astronomers.Add(s));
            context.SaveChanges();

            var galaxies = new List<Galaxy>
            {
                new Galaxy{ Id=1, Name="Milky Way",RightAscension=1249,Declination=27.4,Constellation=Constellation.NA,GalaxyType=GalaxyType.Spiral},
                new Galaxy{ Id=2, Name="Messier 110",RightAscension=40,Declination=41,Constellation=Constellation.Andromeda,GalaxyType=GalaxyType.Elliptical, AstronomerId=3}
            };

            galaxies.ForEach(s => context.Galaxies.Add(s));
            context.SaveChanges();

            var clusters = new List<Cluster>
            {
                new Cluster{ Id=1, Name="NGC 7686",ApparentMagnitude=15,RightAscension=2329,Declination=49,Constellation=Constellation.Andromeda, AstronomerId=1, GalaxyId=1},
                new Cluster{ Id=1, Name="Messier 48",ApparentMagnitude=5.8,RightAscension=813,Declination=-5,Constellation=Constellation.Hydra, AstronomerId=3, GalaxyId=1}
            };

            clusters.ForEach(s => context.Clusters.Add(s));
            context.SaveChanges();

            var stars = new List<Star>
            {
                new Star{ Id=1, Name="Polaris",ApparentMagnitude=9.2,RightAscension=0231,Declination=89,Constellation=Constellation.Ursa_Minor,AstronomerId=1},
                new Star{ Id=2, Name="HD 221246",ApparentMagnitude=6.17,RightAscension=2330,Declination=49,Constellation=Constellation.Andromeda,AstronomerId=1,ClusterId=1},
                new Star{ Id=3, Name="NGC 46", ApparentMagnitude=11.8, RightAscension=14, Declination=5, Constellation=Constellation.Pisces, AstronomerId=2}
            };

            stars.ForEach(s => context.Stars.Add(s));
            context.SaveChanges();
        }
    }
}