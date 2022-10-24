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

        public class DeviceCommsPerDay
        {
            public string PayloadId { get; set; }
            public Nullable<System.DateTime> CommDate { get; set; }
            public int? CommMessages  { get; set; }
        }

        public class DeviceCommsSLAStatus
        {
            public int Order { get; set; }
            public string SLAStatus { get; set; }
            public int NumberOfDevices { get; set; }
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

        public static List<DeviceCommsSLAStatus> GetDeviceCommSLAStatus()
        {
            var mockedReturn = new List<DeviceCommsSLAStatus>()
            {
                new DeviceCommsSLAStatus()
                {
                    Order = 1,
                    SLAStatus = "Todas as leituras recebidas",
                    NumberOfDevices = 64597
                },
                new DeviceCommsSLAStatus()
                {
                    Order = 2,
                    SLAStatus = "Sem leitura por 1 dia",
                    NumberOfDevices = 2762
                },
                new DeviceCommsSLAStatus()
                {
                    Order = 3,
                    SLAStatus = "Sem leitura por 7 dias",
                    NumberOfDevices = 31500
                },
                new DeviceCommsSLAStatus()
                {
                    Order = 4,
                    SLAStatus = "Sem leitura por 30 dias",
                    NumberOfDevices = 1000
                },
                new DeviceCommsSLAStatus()
                {
                    Order = 5,
                    SLAStatus = "Total de medidores ativos",
                    NumberOfDevices = 99859
                }
            };

            var commsPerDayList = GetDeviceCommsPerDay();

            return commsPerDayList;
        }

        private static List<DeviceCommsSLAStatus> GetDeviceCommsPerDay()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var deviceCommsPerDayList = ctx.Database.SqlQuery<DeviceCommsPerDay>(
                    "SELECT PayloadId, DATEADD(dd, 0, DATEDIFF(dd, 0, ParamsRadioTimeDateTime)) CommDate, count(*) CommMessages FROM BlueMeteringMessage WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, ParamsRadioTimeDateTime)) >= DATEADD(dd, -30, GETDATE()) group by PayloadId, DATEADD(dd, 0, DATEDIFF(dd, 0, ParamsRadioTimeDateTime))");

                var commDateGroup = deviceCommsPerDayList.ToList().GroupBy(d => d.CommDate).ToList();

                var commPayloadGroup = deviceCommsPerDayList.ToList().GroupBy(d => d.PayloadId).Select(g => new {PayloadId = g.Key, PayloadCount = g.Count()}).ToList();

                var returnList = new List<DeviceCommsSLAStatus>();

                var allReadings = 0;
                var allButOneDayReadings = 0;
                var allButSevenDaysReadings = 0;
                var allButThirtyDaysReadings = 0;

                foreach (var groupedPayload in commPayloadGroup)
                {
                    if (groupedPayload.PayloadCount == commDateGroup.Count()) // Todas as leituras recebidas
                    {
                        allReadings += 1;
                    }
                    else if (groupedPayload.PayloadCount == commDateGroup.Count() - 1) // Sem leitura por 1 dia
                    {
                        allButOneDayReadings += 1;
                    }
                    else if (groupedPayload.PayloadCount == commDateGroup.Count() - 7) // Sem leitura por 7 dias
                    {
                        allButSevenDaysReadings += 1;
                    }
                    else // Sem leitura por 30 dias
                    {
                        allButThirtyDaysReadings += 1;
                    }
                }

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 1,
                    SLAStatus = "Todas as leituras recebidas",
                    NumberOfDevices = allReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 2,
                    SLAStatus = "Sem leitura por 1 dia",
                    NumberOfDevices = allButOneDayReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 3,
                    SLAStatus = "Sem leitura por 7 dias",
                    NumberOfDevices = allButSevenDaysReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 4,
                    SLAStatus = "Sem leitura por 30 dias",
                    NumberOfDevices = allButThirtyDaysReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 5,
                    SLAStatus = "Total de medidores ativos",
                    NumberOfDevices = allReadings + allButOneDayReadings + allButSevenDaysReadings + allButThirtyDaysReadings
                });

                return returnList;
            }
        }

        public static List<DeviceDiffComm> GetDeviceCommStatusPorCliente(string idCliente)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var deviceList = ctx.Database.SqlQuery<DeviceDiffComm>(
                    $"SELECT RedeIotId PayloadId, NumeroSerie HidrometroNumeroSerie FROM BlueMeteringHidrometro WHERE idCliente = '{idCliente}'");

                var deviceCommList = ctx.Database.SqlQuery<DeviceDiffComm>(
                    $"SELECT PayloadId, MAX(LigacaoId) LigacaoId, MAX(ConsumidorIdConsumidor) ConsumidorId, MAX(ConsumidorNomeCompleto) ConsumidorNome, MAX(HidrometroRedeIotId) HidrometroRedeIotId, MAX(HidrometroNumeroSerie) HidrometroNumeroSerie, MAX(UnidadeNegocioIdUnidadeNegocio) UnidadeNegocioId, MAX(UnidadeNegocioNome) UnidadeNegocioNome, MAX(UnidadeGerenciamentoRegionalIdUnidadeGerenciamentoRegional) UnidadeGerenciamentoRegionalId, MAX(UnidadeGerenciamentoRegionalNome) UnidadeGerenciamentoRegionalNome, MAX(ParamsRxTimeDateTime) CommDate, DATEDIFF(SECOND, MAX(ParamsRxTimeDateTime), GETDATE()) secDiff, CAST(DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE()) / 60 / 24 AS VARCHAR(50)) + +'d ' + +CAST((DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE()) / 60) - ((DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE()) / 60 / 24) * 24) AS VARCHAR(50)) + +'h ' + +CAST((DATEDIFF(MINUTE, MAX(ParamsRxTimeDateTime), GETDATE())) - (DATEDIFF(HOUR, MAX(ParamsRxTimeDateTime), GETDATE()) * 60) AS VARCHAR(50)) + +'m' commRemark FROM message_view WHERE ClienteIdCliente = '{idCliente}' GROUP BY PayloadId").ToList();

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

        public static List<DeviceCommsSLAStatus> GetDeviceCommSLAStatusPorCliente(string idCliente)
        {
            var commsPerDayList = GetDeviceCommsPerDayPorCliente(idCliente);

            return commsPerDayList;
        }

        private static List<DeviceCommsSLAStatus> GetDeviceCommsPerDayPorCliente(string idCliente)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var deviceCommsPerDayList = ctx.Database.SqlQuery<DeviceCommsPerDay>(
                    $"SELECT PayloadId, DATEADD(dd, 0, DATEDIFF(dd, 0, ParamsRadioTimeDateTime)) CommDate, count(*) CommMessages FROM message_view WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, ParamsRadioTimeDateTime)) >= DATEADD(dd, -30, GETDATE()) and ClienteIdCliente = '{idCliente}' group by PayloadId, DATEADD(dd, 0, DATEDIFF(dd, 0, ParamsRadioTimeDateTime))");

                var commDateGroup = deviceCommsPerDayList.ToList().GroupBy(d => d.CommDate).ToList();

                var commPayloadGroup = deviceCommsPerDayList.ToList().GroupBy(d => d.PayloadId).Select(g => new { PayloadId = g.Key, PayloadCount = g.Count() }).ToList();

                var returnList = new List<DeviceCommsSLAStatus>();

                var allReadings = 0;
                var allButOneDayReadings = 0;
                var allButSevenDaysReadings = 0;
                var allButThirtyDaysReadings = 0;

                foreach (var groupedPayload in commPayloadGroup)
                {
                    if (groupedPayload.PayloadCount == commDateGroup.Count()) // Todas as leituras recebidas
                    {
                        allReadings += 1;
                    }
                    else if (groupedPayload.PayloadCount == commDateGroup.Count() - 1) // Sem leitura por 1 dia
                    {
                        allButOneDayReadings += 1;
                    }
                    else if (groupedPayload.PayloadCount == commDateGroup.Count() - 7) // Sem leitura por 7 dias
                    {
                        allButSevenDaysReadings += 1;
                    }
                    else // Sem leitura por 30 dias
                    {
                        allButThirtyDaysReadings += 1;
                    }
                }

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 1,
                    SLAStatus = "Todas as leituras recebidas",
                    NumberOfDevices = allReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 2,
                    SLAStatus = "Sem leitura por 1 dia",
                    NumberOfDevices = allButOneDayReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 3,
                    SLAStatus = "Sem leitura por 7 dias",
                    NumberOfDevices = allButSevenDaysReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 4,
                    SLAStatus = "Sem leitura por 30 dias",
                    NumberOfDevices = allButThirtyDaysReadings
                });

                returnList.Add(new DeviceCommsSLAStatus()
                {
                    Order = 5,
                    SLAStatus = "Total de medidores ativos",
                    NumberOfDevices = allReadings + allButOneDayReadings + allButSevenDaysReadings + allButThirtyDaysReadings
                });

                return returnList;
            }
        }
    }
}