using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Tests
{
    public class BotteCtorParams
    {
        public int A { get; set; }
        public int B { get; set; }
    }

    public class BotteCtorOptional
    {
        public int C { get; set; }
        public int D { get; set; }
    }

    public class ConstructeurBotte
    {
        void ConstructionBotte()
        {
            var obligatoires = new BotteCtorParams { A = 1, B = 2 };
            var options = new BotteCtorOptional { C = 3, D = 4 };
            var botte = new BotteBuilder()
                .WithObligatoires(obligatoires)
                .WithOptions(options)
                .Build();
        }
    }
    public class Botte
    {
        public Botte(BotteCtorParams obligatoires, BotteCtorOptional options)
        {
            
        }
    }

    public class BotteBuilder
    {
        private BotteCtorParams obligatoires;
        private BotteCtorOptional options;
        public BotteBuilder WithObligatoires(BotteCtorParams obligatoires)
        {
            this.obligatoires = obligatoires;
            return this;
        }
        public BotteBuilder WithOptions(BotteCtorOptional options)
        {
            this.options = options;
            return this;
        }
        public Botte Build()
        {
            return new Botte(obligatoires, options);
        }
    }

}
