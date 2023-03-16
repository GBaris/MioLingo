using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULDeneme.BLL.Abstract
{
    public interface ISpeechBLL
    {
        Task<byte[]> TextToSpeechAsync(string text, string language);
    }
}
