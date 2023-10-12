namespace MISA.Web06.RESTful.Domain
{
    public class Department : BaseAuditEntity, IEntity<Guid>
    {
        #region Properties

        /// <summary>
        /// id của phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Mô tả phòng ban
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Tên của phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        #endregion

        #region Methods

        public Guid GetId()
        {
            return DepartmentId;
        }

        public bool isEqualId(Guid id)
        {
            return DepartmentId.Equals(id);
        }

        public void SetId(Guid id)
        {
            DepartmentId = id;
        } 

        #endregion
    }
}
