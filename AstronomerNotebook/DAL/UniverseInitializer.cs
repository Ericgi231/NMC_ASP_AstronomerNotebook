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
                new Galaxy{ Name="Polaris",ApparentMagnitude=9.2,RightAscension=0231,Declination=89,Constellation=Constellation.Ursa_Minor}
            };

            galaxies.ForEach(s => context.Galaxies.Add(s));
            context.SaveChanges();

            var clusters = new List<Cluster>
            {
                new Cluster{ Name="Polaris",ApparentMagnitude=9.2,RightAscension=0231,Declination=89,Constellation=Constellation.Ursa_Minor}
            };

            clusters.ForEach(s => context.Clusters.Add(s));
            context.SaveChanges();

            var stars = new List<Star>
            {
                new Star{ Name="Polaris",ApparentMagnitude=9.2,RightAscension=0231,Declination=89,Constellation=Constellation.Ursa_Minor,AstronomerId=1}
            };

            stars.ForEach(s => context.Stars.Add(s));
            context.SaveChanges();
        }
    }
}