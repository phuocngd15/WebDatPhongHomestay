using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Data.DataModel;
using CaChepFinal2.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    public class nhap
    {
        public void Index()
        {
            //List<int> lstsPhongCart = HttpContext.Session.Get<List<int>>("ssPhongCart");
            //if (lstsPhongCart == null) return View(_DatPhongCart);
            //if (lstsPhongCart.Count > 0)
            //{
            //    foreach (int cartItem in lstsPhongCart)
            //    {
            //        Phong listPhongDat = _Context.Phongs.Find(cartItem);
            //        _DatPhongCart.LsPhongDatPhongs.Add(listPhongDat);
            //    }
            //}
            //List<int> lstsDichVuCart = HttpContext.Session.Get<List<int>>("ssDichVuCart");
            //if (lstsDichVuCart == null) return View(_DatPhongCart);
            //if (lstsDichVuCart.Count > 0)
            //{
            //    foreach (int cartItem in lstsDichVuCart)
            //    {
            //        DichVu oneDichVu = _Context.DichVus.Find(cartItem);
            //        _DatPhongCart.LsDichVuDatPhongs.Add(oneDichVu);
            //    }
            //}

            //return View(_DatPhongCart);
        }
    }
}
