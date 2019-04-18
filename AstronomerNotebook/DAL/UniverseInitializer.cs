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
            base.Seed(context);
        }
    }
}