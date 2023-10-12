using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Domain
{
    public interface IEntity<TKey>
    {
        #region Properties
        TKey GetId();
        #endregion
        #region Methods
        void SetId(TKey id);

        bool isEqualId(TKey id); 
        #endregion
    }
}
