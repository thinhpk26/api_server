using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web06.RESTful.Application
{
    /// <summary>
    /// Cấu hình mapper cho các thuộc tính được yêu cầu có thời gian hiện tại
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    /// Created by: Nguyễn Văn Thịnh (10/09/2023)
    public class CurrentDateResolver<TSource, TDestination> : IMemberValueResolver<TSource, TDestination, DateTime, DateTime>
    {
        public DateTime Resolve(TSource source, TDestination destination, DateTime sourceMember, DateTime destMember, ResolutionContext context)
        {
            return DateTime.Now;
        }
    }
}
