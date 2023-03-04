using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULDeneme.BLL.Abstract
{
    public interface ITanslatorBLL
    {
        Task<string> TranslateText(string textToTranslate, string fromLang, string toLang);
    }
}
