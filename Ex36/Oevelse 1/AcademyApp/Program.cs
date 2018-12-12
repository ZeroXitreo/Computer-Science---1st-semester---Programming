using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Academy("UCL", "Seebladsgade");

            var s1 = new Student(p, "Jens");
            var s2 = new Student(p, "Niels");
            var s3 = new Student(p, "Susan");

            p.Attach(s1);
            p.Attach(s2);
            p.Attach(s3);

            p.Message = "Så er der julefrokost!";

            p.Detach(s2);

            p.Message = "Så er der fredagsbar!";
        }
    }
}
