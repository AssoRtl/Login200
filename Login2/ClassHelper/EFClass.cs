using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login2.DataBase;
namespace Login2.ClassHelper
{
    internal class EFClass
    {
        public static Entities context { get; } = new Entities();
    }
}
