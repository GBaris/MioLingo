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
            set { _knownLang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
        }

        private string _unknownLang;
        public string UnknownLang
        {
            get { return _unknownLang; }
            set { _unknownLang = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
        }

        private string _name;
        public string? Name
        {
            get { return _name; }
            set { _name = UnknownLang + "-" + KnownLang + " Dictionary"; }
        }

        public string KnownLangAbbreviation
        {
            get
            {
                switch (KnownLang)
                {
                    case "Almanca":
                        return "DE";
                    case "Fransızca":
                        return "FR";
                    case "Türkçe":
                        return "TR";
                    case "İngilizce":
                        return "EN";
                    default:
                        return "";
                }
            }
        }

        public string UnknownLangAbbreviation
        {
            get
            {
                switch (UnknownLang)
                {
                    case "Almanca":
                        return "DE";
                    case "Fransızca":
                        return "FR";
                    case "Türkçe":
                        return "TR";
                    case "İngilizce":
                        return "EN";
                    default:
                        return "";
                }
            }
        }

        public ICollection<Sozluk> Sozluks { get; set; }
    }
}
