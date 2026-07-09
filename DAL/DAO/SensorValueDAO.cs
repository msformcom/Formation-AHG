using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    [Table("TBL_SensorValue")]
    internal class SensorValueDAO
    {
        // SELECT * FROM Table WHERE DATEADD(Day,1,dateCreation)='2026-06-06' non sargable=> index no
        // SELECT * FROM Table WHERE dateCreation=DATEADD(day,-1,'2026-06-06') 
        [Column("PK_SensorValue")]
        public Guid Id { get; set; }=Guid.NewGuid();
        [Column("FK_Sensor")]
        public Guid SensorId { get; set; }
        public DateTime DateCreation { get; set; }
        public string ValueJson { get; set; }

        [ForeignKey(nameof(SensorId))]
        public virtual SensorDAO Sensor { get; set; }
    }
}
