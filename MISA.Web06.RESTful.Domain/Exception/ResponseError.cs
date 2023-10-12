namespace MISA.Web06.RESTful.Domain
{
    /// <summary>
    /// Model lỗi trả về
    /// Created by: Nguyễn Văn Thịnh (10/08/2023)
    /// </summary>
    /// <typeparam name="TNofity"></typeparam>
    public class ResponseError<TNofity>
    {
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Thông tin cho nhà phát triển
        /// </summary>
        public TNofity DevMsg { get; set; }

        /// <summary>
        /// Thông tin cho người dùng
        /// </summary>
        public TNofity UserMsg { get; set; }

        /// <summary>
        /// Tra thông tin
        /// </summary>
        public string MoreInfo { get; set; }

        /// <summary>
        /// Mã nhận diện lỗi
        /// </summary>
        public string TraceId { get; set; }
    }
}
