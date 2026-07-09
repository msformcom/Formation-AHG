using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAO
{
    internal class SensorContext : DbContext
    {
        // Ce constructeur permet à l'injection de dépendances de savoir que des options de context sont nécessaires pour créer une instance de SensorContext.
        // Les options sont passées au constructeur de la classe de base DbContext, qui les utilise pour configurer le contexte de base de données.
        public SensorContext(DbContextOptions options): base(options) 
        {
            
        }
        public DbSet<SensorDAO> Sensors { get; set; }
        public DbSet<SensorValueDAO> SensorValues { get; set; }
    }
}
