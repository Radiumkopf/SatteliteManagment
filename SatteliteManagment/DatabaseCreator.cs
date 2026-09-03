using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class DatabaseCreator
    {
        public AppDbContext Context { get; private set; }

        public bool IsAvailable => Context != null;

        public bool TryInitialize()
        {
            AppDbContext context = null;

            try
            {
                context = new AppDbContext();

                context.Database.Migrate();

                Context = context;
                return true;
            }
            catch (Exception ex)
            {
                // logging

                context?.Dispose();
                Context = null;

                return false;
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
            Context = null;
        }
    }
}
