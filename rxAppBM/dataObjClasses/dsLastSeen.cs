using rxAppBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rxAppBM.dataObjClasses
{
    public class dsLastSeen
    {
        public class DeviceDiffComm
        {
            public string PayloadId { get; set; }
            public string LigacaoId { get; set; }
            public string ConsumidorId { get; set; }
            public string ConsumidorNome { get; set; }
            public string HidrometroRedeIotId { get; set; }
            public string HidrometroNumeroSerie { get; set; }
            public string UnidadeNegocioNome { get; set; }
            public string UnidadeGerenciamentoRegionalId { get; set; }
            public string UnidadeGerenciamentoRegionalNome { get; set; }
            public Nullable<System.DateTime> CommDate { get; set; }
            public int? secDiff { get; set; }
            public string commRemark { get; set; }
            public string commStatus { get; set; }
            public string commStatusCode { get; set; }
        }

        public static List<DeviceDiffComm> GetDeviceCommStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var deviceList = ctx.Database.SqlQuery<DeviceDiffComm>(
                    "SELECT RedeIotId PayloadId, NumeroSerie HidrometroNumeroSerie FROM BlueMeteringHidrometro");

                var deviceCommList = ctx.Database.SqlQuery<DeviceDiffComm>(
                    "SELECT PayloadId, MAX(LigacaoId) LigacaoId, MAX(ConsumidorIdConsumidor) ConsumidorId, MAX(ConsumidorNomeCompleto) ConsumidorNome, MAX(HidrometroRedeIotId) HidrometroRedeIotId, MAX(HidrometroNumeroSerie) HidrometroNumeroSerie, MAX(UnidadeNegocioIdUnidadeNegocio) UnidadeNegocioId, MAX(UnidadeNegocioNome) UnidadeNegocioNome, MAX(UnidadeGerenciamentoRegionalIdUnidadeGerenciamentoRegional) UnidadeGerenciamentoRegionalId, MAX(UnidadeGerenciamentoRegionalNome) UnidadeGerenciamentoRegionalNome, MAX(ParamsRxTimeDateTime) CommDate, DATEDIFF(SECOND, MAX(ParamsRxTimeDateTime), GETDATE()) secDiff, CAST(DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE()) / 60 / 24 AS VARCHAR(50)) + +'d ' + +CAST((DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE()) / 60) - ((DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE()) / 60 / 24) * 24) AS VARCHAR(50)) + +'h ' + +CAST((DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE())) - (DATEDIFF(HOUR, MAX(ParamsRxTimeDateTime), GETDATE()) * 60) AS VARCHAR(50)) + +'m' commRemark FROM message_view GROUP BY PayloadId").ToList();

                foreach (var cofreComm in deviceCommList)
                {
                    cofreComm.commStatus = "Sem dados";
                    cofreComm.commStatusCode = "00";

                    if (cofreComm.secDiff != null)
                    {
                        cofreComm.commStatus = "Dentro de 24h";
                        cofreComm.commStatusCode = "01";
                        if (cofreComm.secDiff > 86400 && cofreComm.secDiff <= 172800)
                        {
                            cofreComm.commStatus = "Entre 24 e 48h";
                            cofreComm.commStatusCode = "02";
                        }
                        else
                        {
                            cofreComm.commStatus = "Acima de 48h";
                            cofreComm.commStatusCode = "03";
                        }
                    }
                }

                foreach (var device in deviceList)
                {
                    if (deviceCommList.All(cc => cc.PayloadId != device.PayloadId))
                    {
                        deviceCommList.Add(new DeviceDiffComm()
                        {
                            PayloadId = device.PayloadId,
                            HidrometroRedeIotId = device.HidrometroRedeIotId,
                            HidrometroNumeroSerie = device.HidrometroNumeroSerie,
                            commStatus = "Sem dados",
                            commStatusCode = "00"
                        });
                    }
                }


                return deviceCommList;
            }
        }
    }
}