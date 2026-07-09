using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    // var context=new SensorContext()
    // var s=context.Sensors.Find("44a45f0e-2fde-4ee7-b747-b64723f1525d");
    // var values=s.Values.Where(v=>v.DateCreation>DateTime.Now.AddDays(-1)).ToList();
    [Table("TBL_Sensor")]
    internal class SensorDAO
    {
        [Column("PK_Sensor")]
   
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }=DateTime.Now;

        public string ConfigJson { get; set; }

        public virtual ICollection<SensorValueDAO> Values { get; set; }


    }
}
