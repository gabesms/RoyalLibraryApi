namespace RoyalLibrary.WebAPI.Controllers.Util
{
    public class Pagination
    {
        public Pagination()
        {
            Top = 10;
            Skip = 0;
            AllRegisters = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AllRegisters { get; set; }
    }
}
