using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_demonstration.Som
{
   public class CInterSatellitePathIC : RACoN.RTILayer.CHlaInteractionClass
    {

        #region Declarations
        //public RACoN.RTILayer.CHlaInteractionParameter route_path_flag;
        public RACoN.RTILayer.CHlaInteractionParameter ISLPath;
        public RACoN.RTILayer.CHlaInteractionParameter ISLid;
        #endregion //Declarations

        #region Constructor
        public CInterSatellitePathIC() : base()
        {
            // Initialize Class Properties
            this.ClassName = "InteractionRoot.InterSatellitePath";
            this.ClassPS = RACoN.RTILayer.PSKind.Subscribe;

            // Create Parameters
            ISLPath = new RACoN.RTILayer.CHlaInteractionParameter("ISLPath");
            this.Parameters.Add(ISLPath);
            ISLid = new RACoN.RTILayer.CHlaInteractionParameter("ISLid");
            this.Parameters.Add(ISLid);
        }
        #endregion //Constructor
    }
}
