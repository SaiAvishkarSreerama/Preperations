using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.ConcpetsAndPrograms
{
    class ShallowCopyVsDeepCopy
    {
        //static void Main(string[] args)
        //{
        //    //ShallowCopy
        //    Company c1 = new Company(1, "C1Name", "C1Owner");
        //    Company c2 = (Company)c1.ShallowCopy();
        //    Console.WriteLine("C1 details- Rank: {0}; Name:{1}; Owner:{2} ", c1.GBRank, c1.desc.CompanyName, c1.desc.Owner);
        //    Console.WriteLine("C2details- Rank: {0}; Name:{1}; Owner:{2} ", c2.GBRank, c2.desc.CompanyName, c2.desc.Owner);

        //    //Deep Copy
        //    Company c3 = (Company)c1.DeepCopy();
        //    c1 = new Company(2, "C1ChangeName", "C1NewOwner");
        //    Console.WriteLine("C3details- Rank: {0}; Name:{1}; Owner:{2} ", c3.GBRank, c3.desc.CompanyName, c3.desc.Owner);
        //    Console.WriteLine("C1 details- Rank: {0}; Name:{1}; Owner:{2} ", c1.GBRank, c1.desc.CompanyName, c1.desc.Owner);
        //}

        class Company
        {
            public int GBRank;
            public CompanyDescription desc;

            public Company(int gbRank, string companyName, string owner)
            {
                GBRank = gbRank;
                desc = new CompanyDescription(companyName, owner);
            }

            public object ShallowCopy()
            {
                return this.MemberwiseClone();
            }

            public object DeepCopy()
            {
                return new Company(this.GBRank,
                                desc.CompanyName, desc.Owner);
            }
        }

        class CompanyDescription
        {

            public string CompanyName;
            public string Owner;
            public CompanyDescription(string c, string o)
            {
                this.CompanyName = c;
                this.Owner = o;
            }
        }
    }
}
