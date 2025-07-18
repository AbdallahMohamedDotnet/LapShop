using LapShopv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Icontract
{
    public interface ISliders
    {
        public List<TbSlider> GetAll();
        public TbSlider GetById(int id);
        public bool Save(TbSlider os);
        public bool Dekete(int id);
    }
}
