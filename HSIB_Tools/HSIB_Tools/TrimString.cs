using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace HSIB_Tools
{
    public class TrimString
    {
        public SimplSharpString TrimThis(SimplSharpString sData)
        {
            SimplSharpString sNewData = new SimplSharpString();
            string sTempData;

            sTempData = sData.ToString();
            sNewData.UpdateValue(sTempData.Trim());
            return(sNewData);
        }
    }
}