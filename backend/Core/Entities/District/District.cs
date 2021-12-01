using Core.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.District
{
    public class District : IEntity
    {
        public District()
        {
            SubDistricts = new List<SubDistrict>();
        }

        public int Id { get; set; }

        #region Name

        public string Name_AZ { get; set; }

        public string Name_RU { get; set; }

        public string Name_EN { get; set; }

        #endregion

        #region Location

        public string X { get; set; }

        public string Y { get; set; }

        #endregion

        #region NavigationProperties

        public ICollection<SubDistrict> SubDistricts { get; set; }

        #endregion
    }
}
