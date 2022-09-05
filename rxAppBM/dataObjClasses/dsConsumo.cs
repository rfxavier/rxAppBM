using rxAppBM.Domain.Entities;
using rxAppBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rxAppBM.dataObjClasses
{
    public class dsConsumo
    {
        public static List<BlueMeteringConsumoPorDiaView> GetConsumoPorDia(DateTime dataIni, DateTime dataFim)
        {
            var db = new ApplicationDbContext();

            var ret = db.BlueMeteringConsumoPorDiaViews.AsNoTracking().Where(c => c.TimestampDate >= dataIni && c.TimestampDate <= dataFim).ToList();
            return ret;
        }

        public static List<BlueMeteringConsumoPorDiaView> GetConsumoPorDia()
        {
            var db = new ApplicationDbContext();

            var ret = db.BlueMeteringConsumoPorDiaViews.AsNoTracking().ToList();
            return ret;
        }
        //QUERY Last Seen Devices
        //select PayloadId, max(LigacaoId) ligacao_id, max(ConsumidorIdConsumidor) consumidor_id, max(ConsumidorNomeCompleto) consumidor_nome, max(ParamsRxTimeDateTime) comm_date, DATEDIFF(second, max(ParamsRxTimeDateTime), GETDATE()) secDiff, CAST(DATEDIFF(Minute, max(ParamsRxTimeDateTime), GETDATE())/60/24 as Varchar(50)) ++ 'd ' ++ CAST((DATEDIFF(Minute, max(ParamsRxTimeDateTime), GETDATE())/60)-((DATEDIFF(Minute, max(ParamsRxTimeDateTime), GETDATE())/60/24)*24) as Varchar(50)) ++ 'h ' ++ CAST((DATEDIFF(Minute, max(ParamsRxTimeDateTime), GETDATE())) - (DATEDIFF(HOUR, max(ParamsRxTimeDateTime), GETDATE())*60) as Varchar(50)) ++ 'm' commRemark from message_view group by PayloadId

    }
}