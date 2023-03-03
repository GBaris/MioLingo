using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ULDeneme.Core.Entity;
using ULDeneme.Model.Enums;

namespace ULDeneme.Model.Entities
{
    public class TranslationType : BaseEntity
    {
        public TranslationType()
        {
            IsActive = true;
        }
        public int UserID { get; set; }
        public User? User { get; set; }
        public UserRole UserRole { get; set; }
        private string _knownLang;
        public string KnownLang
        {
            get { return _knownLang; }
            set
            {
                _knownLang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                KnownLangShort = GetLangShort(_knownLang);
            }
        }

        private string _unknownLang;
        public string UnknownLang
        {
            get { return _unknownLang; }
            set
            {
                _unknownLang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
                UnknownLangShort = GetLangShort(_unknownLang);
            }
        }
        private string _name;
        public string? Name
        {
            get { return _name; }
            set { _name = UnknownLang + "-" + KnownLang + " Dictionary"; }
        }

        public string KnownLangShort { get; set; }
        public string UnknownLangShort { get; set; }

        public ICollection<Sozluk> Sozluks { get; set; }

        private string GetLangShort(string lang)
        {
            switch (lang)
            {
                case "Almanca":
                    return "de";
                case "Fransızca":
                    return "fr";
                case "İngilizce":
                    return "en";
                case "Türkçe":
                    return "tr";
                default:
                    return "";
            }
        }
    }
}
