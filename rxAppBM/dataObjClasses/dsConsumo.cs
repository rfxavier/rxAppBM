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

        public static List<BlueMeteringConsumoPorDiaView> GetConsumoPorDiaPorCliente(DateTime dataIni, DateTime dataFim, Guid? clienteId)
        {
            var db = new ApplicationDbContext();

            var ret = db.BlueMeteringConsumoPorDiaViews.AsNoTracking().Where(c => c.TimestampDate >= dataIni && c.TimestampDate <= dataFim && c.ClienteId == clienteId).ToList();
            return ret;
        }


        public static List<BlueMeteringConsumoPorDiaView> GetConsumoPorDia()
        {
            var db = new ApplicationDbContext();

            var ret = db.BlueMeteringConsumoPorDiaViews.AsNoTracking().ToList();
            return ret;
        }
    }
}