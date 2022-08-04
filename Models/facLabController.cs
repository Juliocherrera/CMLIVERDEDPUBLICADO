using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLIVERDEDCM.Models
{
    public class facLabController
    {
        // GET: FacCp
        public ModelFact modelFact = new ModelFact();


        public void getMercancias(string Ai_orden, string Av_cmd_code, string Av_cmd_description, string Af_weight, string Av_weightunit, string Af_count, string Av_countunit)
        {
            this.modelFact.getMercancias(Ai_orden, Av_cmd_code, Av_cmd_description, Af_weight, Av_weightunit, Af_count, Av_countunit);
        }
        public void GetMerc(string Ai_orden, string Av_cmd_code, string Av_cmd_description, string Af_weight, string Av_weightunit, string Af_count, string Av_countunit)
        {
            this.modelFact.GetMerc(Ai_orden, Av_cmd_code, Av_cmd_description, Af_weight, Av_weightunit, Af_count, Av_countunit);
        }
        public DataTable TieneMercancias(string leg)
        {
            return this.modelFact.TieneMercancias(leg);
        }
        public void DeleteMerc(string Ai_orden)
        {
            this.modelFact.DeleteMerc(Ai_orden);
        }

    }
}
