using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class WMISensor : SensorBase<double>
    {
        private readonly string espace;
        private readonly string requete;

        // new WMISensor("CPU Temp")
        // nom : "WMI sensor : CPU Temp"
        public WMISensor(string nom, string espace, string requete) : base("WMI sensor : " + nom)
        {
            this.espace = espace;
            this.requete = requete;
        }


        public override double ReadValue()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                espace,
                requete
            );
            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    double tempKelvin = Convert.ToDouble(obj["CurrentTemperature"]);
                    return tempKelvin;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erreur de requète WMI", ex); 
            }

            throw new Exception("Pas diosponible");
        }
    }
}
