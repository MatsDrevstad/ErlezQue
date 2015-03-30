using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ErlezQue
{
    public static class Globals
    {
        private static string _sqlType;

        public static string SqlType
        {
            get { return _sqlType ?? TransActType.NvarChar.ToString(); }
            set { _sqlType = value; }
        }

        public enum TransActType { NvarChar, VarChar }

        public static string SwitchSqlType()
        {
            return (SqlType.Equals(TransActType.NvarChar.ToString())) ? TransActType.VarChar.ToString() : TransActType.NvarChar.ToString();
        }
    }
}
