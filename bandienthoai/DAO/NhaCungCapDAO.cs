using bandienthoai.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.DAO
{
    public class NhaCungCapDAO
    {
        BanDienThoaiContext db = new BanDienThoaiContext();

        public NhaCungCap GetNCCById(int id)
        {
            return db.NhaCungCaps.Find(id);
        }

        public NhaCungCap GetNCCByName(string name)
        {
            return db.NhaCungCaps.SingleOrDefault(x => x.TenNCC == name);
        }
    }
}