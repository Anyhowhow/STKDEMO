using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
    public class CStartOpnetIC : RACoN.RTILayer.CHlaInteractionClass
    {
        #region Declarations
        public RACoN.RTILayer.CHlaInteractionParameter qualnet_ready;
        public RACoN.RTILayer.CHlaInteractionParameter ScenarioIndex;
        #endregion //Declarations

        #region Constructor
        public CStartOpnetIC() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.StartQualnet";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            // opnet_ready
            qualnet_ready = new RACoN.RTILayer.CHlaInteractionParameter("qualnet_ready");
            this.Parameters.Add(qualnet_ready);
            ScenarioIndex = new RACoN.RTILayer.CHlaInteractionParameter("ScenarioIndex");
            this.Parameters.Add(ScenarioIndex);
        }
        #endregion //Constructor
    }
}
