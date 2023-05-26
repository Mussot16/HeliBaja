using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HeliBajaInitializer : DropCreateDatabaseIfModelChanges<HeliBajaDBContext>
    {
        protected override void Seed(HeliBajaDBContext context)
        {
            context.SaveChanges();
        }
    }
}