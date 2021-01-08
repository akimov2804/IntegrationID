using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InterfaceDesigner
{
    [XmlInclude(typeof(PropertyControls[]))]
    [XmlInclude(typeof(Figures[]))]
    [XmlInclude(typeof(List<string[]>))]
    public class XMLLayout
    {
        public PropertyControls[] PropertyControls { get; set; }
        public Figures[] Figures { get; set; }
        public List<string[]> Scripts { get; set; }
        public XMLLayout(PropertyControls[] PropertyControls, Figures[] Figures, List<string[]> Scripts)
        {
            this.PropertyControls = PropertyControls;
            this.Figures = Figures;
            this.Scripts = Scripts;
        }
        public XMLLayout()
        {

        }
    }
}
