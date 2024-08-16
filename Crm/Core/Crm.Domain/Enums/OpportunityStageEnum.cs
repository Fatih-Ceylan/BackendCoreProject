using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCrm.Domain.Enums
{
    public  enum  OpportunityStageEnum
    {
        HaberdarOlundu = 1,
        Fırsat = 2,
        HedefFırsat = 3,
        ProjeyeDonusturuldu = 4,
        TeklifSunuldu = 5,
        PazarlıkYapılıyor = 6,
        SozelOnayAlındı = 7,
        SozlesmeAsamasında = 8,
        Kazanıldı = 9,
        Kaybedildi=10,
        Terkedildi=11
    }
}
