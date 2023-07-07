using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using PBK_dita.Models;

namespace PBK_dita.Utils
{
    public static class Cbr
    {

        private const double alfa = 0.001;
        public static List<(int Id,double d)> Retrieve(List<RekamMedis> dataRekamMedis, int[] kasusBaru)
        {
            List<(int Id,double d)> result = new();

            foreach (var rekamMedis in dataRekamMedis)
            {
                //tampung daftar gejala di rekam medis biar codingnya gk kepanjangan
                var listGejalaRekamMedis = rekamMedis.ListGejala.Select(gejala => gejala.Id);
                
                //cari dulu gejala yg beda di rekam medis
                var differentGejalaInRekamMedis = rekamMedis.ListGejala.Where(gejala => !kasusBaru.Contains(gejala.Id));
                var di1 = differentGejalaInRekamMedis.Count();
                
                //cari lagi gejala yg beda di kasus baru
                var differentGejalaInNewCase = kasusBaru.Where(gejala => !listGejalaRekamMedis.Contains(gejala));
                var di2 = differentGejalaInNewCase.Count();
                
                //gabungin di1 dan di2 buat dapat nilai di
                var di = di1 + di2;
                result.Add((Id:rekamMedis.Penyakit.Id, d:di));
            }
            
            return result;

        }

        public static List<(int Id,double Similiarity)> Reuse(List<(int Id,double d)> listNilaiKemiripan)
        {
            var sm = listNilaiKemiripan.Select(ctx => (Id:ctx.Id,Similiarity:1 / (1 + alfa *  ctx.d) * 100)).ToList();

            return sm;

        } 
    }
}