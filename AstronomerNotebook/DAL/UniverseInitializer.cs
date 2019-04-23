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
                new Astronomer{ Id=1, Name="William Herschel" }
            };

            astronomers.ForEach(s => context.Astronomers.Add(s));
            context.SaveChanges();

            var galaxies = new List<Galaxy>
            {
                new Galaxy{ Id=1, Name="Milky Way",ApparentMagnitude=1,RightAscension=1249,Declination=27.4,Constellation=Constellation.NA,GalaxyType=GalaxyType.Spiral}
            };

            galaxies.ForEach(s => context.Galaxies.Add(s));
            context.SaveChanges();

            var clusters = new List<Cluster>
            {
                new Cluster{ Id=1, Name="NGC 7686",ApparentMagnitude=15,RightAscension=2329,Declination=49,Constellation=Constellation.Andromeda, AstronomerId=1, GalaxyId=1}
            };

            clusters.ForEach(s => context.Clusters.Add(s));
            context.SaveChanges();

            var stars = new List<Star>
            {
                new Star{ Id=1, Name="Polaris",ApparentMagnitude=9.2,RightAscension=0231,Declination=89,Constellation=Constellation.Ursa_Minor,AstronomerId=1},
                new Star{ Id=2, Name="HD 221246",ApparentMagnitude=6.17,RightAscension=2330,Declination=49,Constellation=Constellation.Andromeda,AstronomerId=1,ClusterId=1}
            };

            stars.ForEach(s => context.Stars.Add(s));
            context.SaveChanges();
        }
    }
}